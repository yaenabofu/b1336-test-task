using b1336_test_task.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1336_test_task.Interfaces
{
    internal interface IDataAccesser
    {
        string Data
        {
            get; set;
        }
        string Data_URL
        {
            get; set;
        }
        string Load();
        void Send();
    }
}
