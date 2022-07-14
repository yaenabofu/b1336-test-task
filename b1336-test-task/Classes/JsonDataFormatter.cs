using b1336_test_task.Interfaces;
using b1336_test_task.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1336_test_task.Classes
{
    internal class JsonDataFormatter :
       IDataFormatter
    {
        public IEnumerable<DeviceInfo> Deserialize(string json)
        {
            var fromJson = JsonConvert.DeserializeObject<IEnumerable<DeviceInfo>>(json);

            return fromJson;
        }

        public string Serialize(IEnumerable<Conflict> devInfData)
        {
            string json = JsonConvert.SerializeObject(devInfData, Formatting.Indented);

            return json;
        }
    }
}
