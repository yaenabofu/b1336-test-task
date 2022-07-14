using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1336_test_task.Models
{
    public class DeviceInfo
    {
        public Device Device { get; set; }
        public Brigade Brigade { get; set; }

        public override string ToString()
        {
            return "Code: " + Brigade.Code + ", " + Device;
        }
    }
}
