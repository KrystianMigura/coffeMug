using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WebApplication1.Models
{
    class modelUpdate
    {
        modelUpdate() { }
        public string name { get; set; }
        public decimal price { get; set; }
    }

    public class Filesupport
    {
        public Filesupport() { }

        public string id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }

        public string loadJsonFile()
        {
            string jsonFilePath = @".\Models\Products.json";
            string json = File.ReadAllText(jsonFilePath);
            return json;

        }
        public void addNewValueToFile(Guid guid, string name, decimal price)
        {
            string json = loadJsonFile();
          
            List<Filesupport> jsonvalue = JsonConvert.DeserializeObject<List<Filesupport>>(json);
            var employeelist = JsonConvert.DeserializeObject<List<Filesupport>>(json);

            employeelist.Add(new Filesupport()
            {
                id = "" + guid + "",
                name = name,
                price = price
            }); ;

            string jsonFilePath = @".\Models\Products.json";
            json = JsonConvert.SerializeObject(employeelist);
            File.WriteAllText(jsonFilePath, json);

        }

        public string removeSelectValue(Guid guid)
        {
            string json = loadJsonFile();
            string jsonFilePath = @".\Models\Products.json";
            List<Filesupport> jsonvalue = JsonConvert.DeserializeObject<List<Filesupport>>(json);
            var employeelist = JsonConvert.DeserializeObject<List<Filesupport>>(json);

            Array size = employeelist.ToArray();
            string id = guid.ToString();
            string callback = "";
            int arrSize = size.Length ;
            
            for(int j = 0; j < arrSize; j++)
            {

                if (employeelist[j].id == id)
                {
                    employeelist.RemoveAt(j);
                    arrSize--;
                }

            }
            
            json = JsonConvert.SerializeObject(employeelist);
            File.WriteAllText(jsonFilePath, json);
            return callback;
        }


        public void ProductUpdateInputModel(Guid guid, Models.Filesupport modelUpdate)
        {
            string json = loadJsonFile();
            string jsonFilePath = @".\Models\Products.json";
            List<Filesupport> jsonvalue = JsonConvert.DeserializeObject<List<Filesupport>>(json);
            var employeelist = JsonConvert.DeserializeObject<List<Filesupport>>(json);

           
            Array size = employeelist.ToArray();
            int sizeArray = size.Length;
            string id = guid.ToString();
            string callback = "";
            for (int j = 0; j < sizeArray; j++)
            {
                if (employeelist[j].id == id)
                {                   
                    try
                    {
                        if (modelUpdate.name != null && modelUpdate.name.Length < 50)
                        {
                            employeelist[j].name = modelUpdate.name;
                            callback += "name Updated. ";
                        }
                        else
                        {
                            callback += "name value is incorrect!";
                        }
                    
                    }catch(System.NullReferenceException err)
                    {
                        callback += "value not found!";
                    }


                    if(modelUpdate.price.ToString().Length > 0)
                    if (modelUpdate.price > 0 && modelUpdate.price.GetType() == typeof(decimal))
                    {
                        employeelist[j].price = Decimal.Truncate(modelUpdate.price);
                        callback += "price Updated.";
                    }
                    else
                    {
                        callback += "price value is incorrect";
                    }
                }
            }

            json = JsonConvert.SerializeObject(employeelist);
            File.WriteAllText(jsonFilePath, json);

        }
    }


}
