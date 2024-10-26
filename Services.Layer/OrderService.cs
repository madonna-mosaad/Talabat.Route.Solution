using Core.Layer.Models;
using Core.Layer.Order_Aggregate;
using Core.Layer.RepositoriesInterface;
using Core.Layer.ServiceInterfaces;
using Core.Layer.Specifications.SpecificationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Layer
{
    public class OrderService : IOrderServices
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;
        

        public OrderService(IBasketRepository basketRepository,IUnitOfWork unitOfWork)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<Order> CreateOrder(string BuyerEmail, string BasketId, int deliveryMethodId, Core.Layer.Order_Aggregate.Address address)
        {
            //in any businnes must be write peseudo code
            //pseudo code:
                         //get the basket from basketRepo
                         //get the selected BasketItem from DB from productRepo (using data from the result of the one step)
                         //create object from order
                         //create order in DB
                         //save in DB

            //get the basket from basketRepo
            var basket = await _basketRepository.GetAsync(BasketId);
            //get the selected BasketItems from DB from productRepo in List<orderItem>(using data from the result of the one step)
            //da 3lshan ataked an eldata ely gaya mn elfront hya ely f el DB
            var Items=new List<OrderItem>();

            if (basket?.Items?.Count!=0)
            {
                foreach(var item in basket.Items)
                {
                    var product = await _unitOfWork.RepositoryCreate<Product>().GetByIdAsync(item.ProductId);
                    if (product is null) return null;
                    var productOrderItem= new ProductOrderItem(product.Id,product.Name,product.PictureUrl);
                    var orderItem = new OrderItem(productOrderItem, product.Price, item.Quantity);
                    Items.Add(orderItem);
                }
            }
            //create object from order
            var subTotal= Items.Sum(i=>i.Price*i.Quantity);
            var deliveryMethod= await _unitOfWork.RepositoryCreate<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
            var order=new Order(BuyerEmail,address,deliveryMethod,Items,subTotal);

            //save in DB
             _unitOfWork.RepositoryCreate<Order>().Add(order);
            var result= await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;
            return order;
        }


        public async Task<IReadOnlyList<Order>> GetOrdersToSpecificUser(string BuyerEmail)
        {
            var orderRepo = _unitOfWork.RepositoryCreate<Order>();
            var spec = new OrderSpecificationsValues(BuyerEmail);
            var orders =await orderRepo.GetAllWithSpecAsync(spec);
            return orders;
        }

        public async Task<Order> GetSpecificOrderByIdToSpecificUser(string BuyerEmail, int OrderId)
        {
            var orderRepo = _unitOfWork.RepositoryCreate<Order>();
            var spec = new OrderSpecificationsValues(BuyerEmail,OrderId);
            var order = await orderRepo.GetByIdWithSpecAsync(spec);
            return order;
        }
    }
}
