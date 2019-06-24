using System.Collections.Generic;

namespace MangalysClient.Managers.Process
{
    public class ProcessManager
    {
        public static List<ProcessLight> Processes = new List<ProcessLight>();

        public static ProcessLight[] GetProcessus()
        {
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcesses())
            {
                Processes.Add(new ProcessLight(process.Id, process.ProcessName, process.StartTime));
            }

            return Processes.ToArray();
        }
    }
}
