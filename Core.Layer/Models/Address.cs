using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    public class Address
    {
        //relation 1:1 and this is the mindatory so this table has the FK
        public int Id { get; set; }
        //first person can recieve the item
        public string FName { get; set; }
        //second person can recieve the item
        public string SName { get; set; } 
        public string Street {  get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string UsersId {  get; set; }//FK
    }
}
