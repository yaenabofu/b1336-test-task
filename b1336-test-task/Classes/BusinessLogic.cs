using b1336_test_task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1336_test_task.Classes
{
    internal class BusinessLogic
    {
        private readonly IDataAccesser dataAccesser;
        private readonly IDataFormatter dataFormatReadWriter;
        private readonly IDataConflict dataConflict;
        private readonly ILogger logger;

        public BusinessLogic(IDataAccesser IDataAccesser, IDataFormatter IDataFormatReadWriter,
           IDataConflict IDataConflict, ILogger ILogger)
        {
            this.dataAccesser = IDataAccesser;
            this.dataFormatReadWriter = IDataFormatReadWriter;
            this.dataConflict = IDataConflict;
            this.logger = ILogger;
        }
        public void ExecuteTask()
        {
            string json = dataAccesser.Load();

            Log log = new Log();

            if (json != null)
            {
                log.StatusType = StatusType.success;
            }
            else
            {
                log.StatusType = StatusType.error;
            }

            log.LogType = LogType.load;

            logger.Print(log);

            var fromJson = dataFormatReadWriter.Deserialize(json);
            log = new Log();
            log.LogType = LogType.deserialize;
            log.StatusType = StatusType.success;

            logger.Print(log);


            var data = dataConflict.GetConflictsByCode(fromJson);
            log = new Log();
            log.LogType = LogType.request;
            log.StatusType = StatusType.success;
            logger.Print(log);

            json = dataFormatReadWriter.Serialize(data);
            log = new Log();
            log.LogType = LogType.serialize;
            log.StatusType = StatusType.success;
            logger.Print(log);

            dataAccesser.Data_URL = "Conflicts.json";
            dataAccesser.Data = json;
            dataAccesser.Send();
            log = new Log();
            log.StatusType = StatusType.success;
            log.LogType = LogType.send;
            logger.Print(log);
        }
    }
}
