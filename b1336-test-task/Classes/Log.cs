using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1336_test_task.Classes
{
    internal class Log
    {
        private string message;
        private StatusType statusType;
        private LogType logType;
        private DateTime date;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public DateTime Date
        {
            get { return DateTime.Now; }
            private set { date = value; }
        }
        public LogType LogType
        {
            get { return logType; }
            set { logType = value; }
        }
        public StatusType StatusType
        {
            get { return statusType; }
            set { statusType = value; }
        }

        public Log(StatusType StatusType, LogType LogType, string Message)
        {
            this.StatusType = StatusType;
            this.LogType = LogType;
            this.Date = DateTime.Now;
            this.Message = Message;
        }
        public Log(StatusType StatusType, LogType LogType)
        {
            this.StatusType = StatusType;
            this.LogType = LogType;
            this.Date = DateTime.Now;
            this.Message = "NO_MESSAGE";
        }

        public Log()
        {
            this.StatusType = StatusType.error;
            this.LogType = LogType.deserialize;
            this.Date = DateTime.Now;
            this.Message = "NO_MESSAGE";
        }

        public override string ToString()
        {
            return $"{date} | {LogType}: {StatusType} ({Message})";
        }
    }
}
