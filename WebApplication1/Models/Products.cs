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
        //przeniesc do innego pliku i stworzyc klase
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
         
            //ladowanie pliku w innym pliku z klasa!
            string jsonFilePath = @".\Models\json.json";
            string json = File.ReadAllText(jsonFilePath);


            List<Entry> test = JsonConvert.DeserializeObject<List<Entry>>(json);

            //odwolanie do klasy w ktorym jest ladowanie z pliku itd.... 
            string callback ="";
            bool flag = false;
            string type = "nie znaleziono";
            Array size = test.ToArray();
                
            for(int i=0; i< size.Length; i++)
            {
                if(test[i].id == Key)
                {
                    type= "{ id: "+ test[i].id +", \n name: " +test[i].name+", \n price : "+test[i].price+" \n}";
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

        public string returnList(int param)
        {
            return "ASDF";

        }

        public string returnAllEntity()
        {
            return "asdfasdfasdf";
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
