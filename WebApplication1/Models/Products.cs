using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Products
    {
        public Products() { }

        public string returnList(int param)
        {
            return "jakis absurd :D  "+ param ;
        }

        public string[] returnAllEntity()
        {
           return new string[] {"data", "1", "2", "3" };
        }

        public string blabla()
        {
            return "QPA";
        }
    }

    public class model
    {
        public model() { }
        public string Name { get; set; }
        public string Id { get; set; }
        public decimal Price { get; set; }

        public string ProductCreateInputModel()
        {
            bool _Name = checkName(this.Name);
            bool _Price = checkPrice(this.Price);
            Guid guid = generateGuid();

            if (_Name == true && _Price == true && guid != null)
            {
                string value = "Id :" + guid + " | " + "Name :" + this.Name + " | " + "Price :" + this.Price + "?";
                return value;
            }
            else
            {
                return "400	Bad Request";
            }
            

        }

        private bool checkName(string _name)
        {
            return (_name != null) ? true : false;
        }
        private bool checkPrice(decimal _price)
        {
            string a = _price.ToString();    
            int index1 = a.IndexOf(',');
            if (index1 == -1 && _price > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private Guid generateGuid()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid;
        }

    }
}
