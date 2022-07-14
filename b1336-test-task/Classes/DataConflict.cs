using b1336_test_task.Interfaces;
using b1336_test_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1336_test_task.Classes
{
    internal class DataConflict : IDataConflict
    {
        public IEnumerable<Conflict> GetConflictsByCode(IEnumerable<DeviceInfo> allDevicesInfo)
        {
            Dictionary<string, DeviceInfo> devicesInfoWithSameCodes = new Dictionary<string, DeviceInfo>();
            HashSet<string> brigadeCodes = new HashSet<string>();
            List<Conflict> conflictsWithSameCodeAndOnline = new List<Conflict>();

            foreach (var deviceInfo in allDevicesInfo)
            {
                //Получить все пары DeviceInfo, у которых есть общий Brigade Code
                var devInfoWithBrigadeCode = allDevicesInfo.Select(c => c)
                    .Where(c => c.Brigade.Code == deviceInfo.Brigade.Code).Count();

                if (devInfoWithBrigadeCode > 1 && !devicesInfoWithSameCodes.ContainsKey(deviceInfo.Device.SerialNumber))
                {
                    devicesInfoWithSameCodes.Add(deviceInfo.Device.SerialNumber, deviceInfo);

                    //Получить все Brigade Code без дублирования
                    if (!brigadeCodes.Contains(deviceInfo.Brigade.Code))
                    {
                        brigadeCodes.Add(deviceInfo.Brigade.Code);
                    }
                }
            }

            //Пройти по каждому Brigade Code 
            foreach (var brigadeCode in brigadeCodes)
            {
                //Получить все объекты с указанным Brigade Code
                var devInfosWithSameBrigadeCode = devicesInfoWithSameCodes.Select(c => c)
                    .Where(c => c.Value.Brigade.Code == brigadeCode).ToList();

                //Получить количество объектов из предыдущей выборки, значение свойства IsOnline у которых имеет true
                var devInfoOnline = devInfosWithSameBrigadeCode.Select(c => c).Where(c => c.Value.Device.IsOnline == true).Count();

                //Если хотя бы у одного объекта в выборке значение true
                if (devInfoOnline > 0)
                {
                    string[] serialNumbers = new string[devInfosWithSameBrigadeCode.Count()];

                    for (int i = 0; i < devInfosWithSameBrigadeCode.Count(); i++)
                    {
                        serialNumbers[i] = devInfosWithSameBrigadeCode[i].Value.Device.SerialNumber;
                    }

                    conflictsWithSameCodeAndOnline.Add(new Conflict()
                    {
                        BrigadeCode = brigadeCode,
                        DevicesSerials = serialNumbers
                    });
                }
            }

            //Возврат массива данных, отсортированного по коду бригады
            return conflictsWithSameCodeAndOnline.OrderBy(c => c.BrigadeCode);
        }
    }
}
