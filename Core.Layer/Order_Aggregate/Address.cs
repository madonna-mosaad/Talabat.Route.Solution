using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Order_Aggregate
{
    //this table has relation 1:1 with Order class and both is mandatory
    public class Address
    {
        public Address(string fName, string sName, string street, string city, string country)
        {
            FName = fName;
            SName = sName;
            Street = street;
            City = city;
            Country = country;
        }
        public Address() { }

        //doesnot has Id because its columns will add to Order table
        //first person can recieve the item
        public string FName { get; set; }
        //second person can recieve the item
        public string SName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
