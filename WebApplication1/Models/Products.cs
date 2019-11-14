using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;



namespace WebApplication1.Models
{
    public class Entry
    {
        public string data {get;set;}
        public string id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
    }

    public class Products
    {
        public Products() { }


        public string getEntityUsingId(string Key)
        {

            string jsonFilePath = @".\Models\Products.json";
            string json = File.ReadAllText(jsonFilePath);

            List<Entry> allEntity = JsonConvert.DeserializeObject<List<Entry>>(json);


            bool flag = false;
            string type = "Not Found!";
            Array size = allEntity.ToArray();
                
            for(int i=0; i< size.Length; i++)
            {
                if(allEntity[i].id == Key)
                {
                    type= "{ id: "+ allEntity[i].id +", \n name: " + allEntity[i].name+", \n price : "+ allEntity[i].price+" \n}";
                }

                if(i == size.Length - 1)
                {
                    flag = true;
                }
            }
            if(flag == true)
            {

                return type;
            }

            return "";
            
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

                Filesupport save = new Filesupport();
                save.addNewValueToFile(guid, this.Name, this.Price);

                return guid.ToString();
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
