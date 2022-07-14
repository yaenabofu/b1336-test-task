using b1336_test_task.Classes;
using System;

namespace b1336_test_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger consoleLogger = new ConsoleLogger();
            DataConflict dataConflict = new DataConflict();
            FileDataAccesser fileDataAccesser = new FileDataAccesser("Devices.json");
            JsonDataFormatter jsonDataFormatter = new JsonDataFormatter();

            BusinessLogic businessLogic = new BusinessLogic(fileDataAccesser, jsonDataFormatter, dataConflict, consoleLogger);
            businessLogic.ExecuteTask();
        }
    }
}
