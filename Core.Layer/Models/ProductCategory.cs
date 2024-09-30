using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    public class ProductCategory : ModelBase
    {
        public string Name { get; set; }
        //doesnot need to write Navigtional prop (many) because i won't use it in my code
        // public ICollection<Product> Products { get; set; } = new HashSet<Product>();    
    }
}
