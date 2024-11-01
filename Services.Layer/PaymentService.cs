using Core.Layer.Models;
using Core.Layer.Order_Aggregate;
using Core.Layer.RepositoriesInterface;
using Core.Layer.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Layer
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IConfiguration configuration ,IBasketRepository basketRepository, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CustomerBasket?> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeKeys:SecretKey"];
            var basket =await _basketRepository.GetAsync(basketId);
            if (basket == null) return null;
            
            var deliveryMethod =await _unitOfWork.RepositoryCreate<DeliveryMethod>().GetByIdAsync(basket.DeliveryMethodId);
            decimal ShippingPrice = deliveryMethod.Cost;

            if (basket.Items.Count > 0)
            {
                foreach (var item in basket.Items)
                {
                    var product =await _unitOfWork.RepositoryCreate<Core.Layer.Models.Product > ().GetByIdAsync(item.ProductId);
                    if (product.Price != item.Price)
                    {
                        item.Price = product.Price;
                    }
                }

            }
            var subTotal=basket.Items.Sum(item=>item.Price);

            //create paymentIntent
            PaymentIntent paymentIntent;
            var service = new PaymentIntentService();
            if (string.IsNullOrEmpty(basket.PaymentId))
            {
                var options = new PaymentIntentCreateOptions()
                {
                    Amount = (long)subTotal * 100 + (long)ShippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                paymentIntent =await service.CreateAsync(options);
                basket.PaymentId = paymentIntent.Id;
                basket.ClientSecret=paymentIntent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)subTotal * 100 + (long)ShippingPrice * 100
                };
                paymentIntent = await service.UpdateAsync(basket.PaymentId,options);
                basket.PaymentId = paymentIntent.Id;
                basket.ClientSecret = paymentIntent.ClientSecret;
            }
            await _basketRepository.SetAsync(basket);
            return basket;
        }
    }
}
