using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RockManApi.Utils
{
    public class JsonLoader
    {
        public IEnumerable<T> Load<T>(string filePath)
        {   
            using (StreamReader reader = File.OpenText(filePath))
            {
                var json = reader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<T>>(json);

                return items;
            }            
        }        
    }
}