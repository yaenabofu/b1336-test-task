using b1336_test_task.Classes;
using b1336_test_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1336_test_task.Interfaces
{
    internal interface IDataConflict
    {
        IEnumerable<Conflict> GetConflictsByCode(IEnumerable<DeviceInfo> deviceInfo);
    }
}
