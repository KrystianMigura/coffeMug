using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WebApplication1.Models
{
    public class Filesupport
    {
        public Filesupport() { }

        public string id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }

        public string loadJsonFile()
        {
            string jsonFilePath = @".\Models\json.json";
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
            });

            string jsonFilePath = @".\Models\json.json";
            json = JsonConvert.SerializeObject(employeelist);
            File.WriteAllText(jsonFilePath, json);

        }

        public void removeSelectValue(Guid guid)
        {
            string json = loadJsonFile();
            string jsonFilePath = @".\Models\json.json";
            List<Filesupport> jsonvalue = JsonConvert.DeserializeObject<List<Filesupport>>(json);
            var employeelist = JsonConvert.DeserializeObject<List<Filesupport>>(json);

            Array size = employeelist.ToArray();
            int sizeArray = size.Length;
            string id = guid.ToString();
            for(int j = 0; j < 50; j++)
            {
               if(employeelist[j].id == id)
                {
                    employeelist.RemoveAt(j);
                }
            }
            

            json = JsonConvert.SerializeObject(employeelist);
            File.WriteAllText(jsonFilePath, json);
        }
    }
}
