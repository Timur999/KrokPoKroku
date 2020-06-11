using System;


namespace System
{
    public class SystemData
    {
        public void GetUserName()
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("USERNAME"));
        }
        public void GetComputerName()
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("COMPUTERNAME"));
        }
        public void GetProcessorArchitecture()
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));
        }
        public void GetVisualStudioVersion()
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("VisualStudioVersion"));
        }
    }
}
