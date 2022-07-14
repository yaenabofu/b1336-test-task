using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b1336_test_task.Models
{
	public class Device
	{
		public string SerialNumber { get; set; }
		public bool IsOnline { get; set; }

		public override string ToString()
		{
			return "SerialNumber: " + SerialNumber + ", IsOnline: " + IsOnline;
		}
	}
}
