using System.Management;
using System;

namespace ExamSys.Util
{
    public class Hardware
    {
      
        /// <summary>
        /// 获得机器号
        /// </summary>
        public static string MachineID
        {
            get
            {
                try
                {
                    string mid = CpuID + DiskVolumeSerialNumber;// +MacAddress;

                    if (string.IsNullOrEmpty(mid))
                        return "";
                    
                    if (mid.Length >= 11)
                        return mid.Substring(11, mid.Length-11);

                    return mid;
                }
                catch
                {
                    return "";
                }
            }
        }

    


        //取CPU编号
        private static String CpuID
        {
            get
            {
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();

                String strCpuID = null;
                foreach (ManagementObject mo in moc)
                {
                    strCpuID = mo.Properties["ProcessorId"].Value.ToString();
                    break;
                }
                return strCpuID;

            }
        }

        private static  string MacAddress
        {
            get
            {
                ManagementClass mc;
                ManagementObjectCollection moc;
                mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                moc = mc.GetInstances();
                string str = "";
                foreach (ManagementObject mo in moc)
                {
                    if (mo["IPEnabled"] == null)
                        continue;

                    if ((bool)mo["IPEnabled"] == true)
                        str = mo["MacAddress"].ToString();

                }
                return str.Replace(":", "");
            }
        }

        /// <summary>
        /// 取得设备硬盘的卷标号
        /// </summary>
        /// <returns></returns>
        private static string DiskVolumeSerialNumber
        {
            get
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
                disk.Get();
                return disk.GetPropertyValue("VolumeSerialNumber").ToString();
            }
        }

       
    }
}