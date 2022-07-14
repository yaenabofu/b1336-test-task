using b1336_test_task.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1336_test_task.Classes
{
    internal class ConsoleLogger : ILogger
    {
        private ConsoleColor backgroundColor;
        private ConsoleColor foregroundColor;
        public ConsoleColor BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }
        public ConsoleColor ForegroundColor
        {
            get { return foregroundColor; }
            set { foregroundColor = value; }
        }
        public ConsoleLogger(ConsoleColor BackgroundColor, ConsoleColor ForegroundColor)
        {
            this.BackgroundColor = BackgroundColor;
            this.ForegroundColor = ForegroundColor;
        }
        public ConsoleLogger()
        {
            this.BackgroundColor = ConsoleColor.Black;
            this.ForegroundColor = ConsoleColor.White;
        }
        public void Print(Log log)
        {
            ChangeColor(backgroundColor, foregroundColor);
            string logMessage = log.ToString();
            Console.WriteLine(logMessage);
            ChangeColor(ConsoleColor.Black, ConsoleColor.White);
        }

        public void ChangeColor(ConsoleColor BackgroundColor, ConsoleColor ForegroundColor)
        {
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForegroundColor;
        }
    }
}
