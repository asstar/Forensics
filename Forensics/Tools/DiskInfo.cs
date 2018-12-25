using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forensics.Tools
{
    public class DiskInfo
    {
        //获取系统所在硬盘的序列号
        public static string GetSystemDiskNo()
        {
            ManagementClass cimObject = new ManagementClass("Win32_PhysicalMedia");
            ManagementObjectCollection moc = cimObject.GetInstances();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (ManagementObject mo in moc)
            {
                string tag = mo.Properties["Tag"].Value.ToString().ToLower().Trim();
                string hdId = (string)mo.Properties["SerialNumber"].Value ?? string.Empty;
                hdId = hdId.Trim();
                dict.Add(tag, hdId);
            }
            cimObject = new ManagementClass("Win32_OperatingSystem");
            moc = cimObject.GetInstances();
            string currentSysRunDisk = string.Empty;
            foreach (ManagementObject mo in moc)
            {
                currentSysRunDisk = Regex.Match(mo.Properties["Name"].Value.ToString().ToLower(), @"harddisk\d+").Value;
            }
            var results = dict.Where(x => Regex.IsMatch(x.Key, @"physicaldrive" + Regex.Match(currentSysRunDisk, @"\d+$").Value));
            if (results.Any()) return results.ElementAt(0).Value;
            return "";
        }

        public static string GetCurrentDiskNo()
        {
            string _driveLetter = Application.StartupPath.Substring(0, 2);//得到盘符
            string[] diskArray;
            string driveNumber;
            string driveLetter;
            string _serialNumber = "";
            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDiskToPartition");
            foreach (ManagementObject dm in searcher1.Get())
            {
                diskArray = null;
                string inValue = dm["Dependent"].ToString();
                int posFoundStart = 0;
                int posFoundEnd = 0;
                posFoundStart = inValue.IndexOf("\"");
                posFoundEnd = inValue.IndexOf("\"", posFoundStart + 1);
                driveLetter = inValue.Substring(posFoundStart + 1, (posFoundEnd - posFoundStart) - 1);
                inValue = dm["Antecedent"].ToString();
                string driveLetter2 = "";
                posFoundStart = 0;
                posFoundEnd = 0;
                posFoundStart = inValue.IndexOf("\"");
                posFoundEnd = inValue.IndexOf("\"", posFoundStart + 1);
                driveLetter2 = inValue.Substring(posFoundStart + 1, (posFoundEnd - posFoundStart) - 1);
                diskArray = driveLetter2.Split(',');
                driveNumber = diskArray[0].Remove(0, 6).Trim();
                if (driveLetter == _driveLetter)
                {
                    ManagementObjectSearcher disks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                    foreach (ManagementObject disk in disks.Get())
                    {
                        if (disk["Name"].ToString() == ("\\\\.\\PHYSICALDRIVE" + driveNumber) & disk["InterfaceType"].ToString() == "USB")
                        {
                            string[] splitDeviceId = disk["PNPDeviceID"].ToString().Split('\\');
                            string[] serialArray;
                            int arrayLen = splitDeviceId.Length - 1;
                            serialArray = splitDeviceId[arrayLen].Split('&');
                            _serialNumber = serialArray[0];
                        }
                    }
                }
            }
            return _serialNumber;
        }
    }
}
