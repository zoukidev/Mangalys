using System;

namespace MangalysClient.Managers.Process
{
    public class ProcessLight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }

        public ProcessLight(int id, string name, DateTime startTime)
        {
            Id = id;
            Name = name;
            StartTime = startTime;
        }
    }
}
