using b1336_test_task.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1336_test_task.Classes
{
    internal class FileDataAccesser : IDataAccesser
    {
        private string data;
        private string file_path;
        public FileDataAccesser(string File_path)
        {
            this.Data_URL = File_path;
        }
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        public string Data_URL
        {
            get { return file_path; }
            set { file_path = value; }
        }
        public string Load()
        {
            if (string.IsNullOrEmpty(this.Data_URL) || string.IsNullOrEmpty(this.Data_URL))
            {
                return null;
            }

            using (StreamReader streamReader = new StreamReader(this.Data_URL))
            {
                this.Data = streamReader.ReadToEnd();

                return this.Data;
            }
        }

        public void Send()
        {
            using (FileStream fileStream = new FileStream(this.Data_URL, FileMode.OpenOrCreate))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(this.Data);
                }
            }
        }
    }
}
