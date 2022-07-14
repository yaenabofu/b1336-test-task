using b1336_test_task.Classes;
using b1336_test_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1336_test_task.Interfaces
{
    internal interface IDataFormatter
    {
        string Serialize(IEnumerable<Conflict> unformattedData);
        IEnumerable<DeviceInfo> Deserialize(string formattedData);
    }
}
