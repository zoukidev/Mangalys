namespace MangalysProtocol.Messages
{
    [System.Serializable()]
    public class BasicInfoMessage : Message
    {
        public new int Protocol = 1;

        public string MachineName { get; set; }
        public string UserName { get; set; }

        public BasicInfoMessage() { }

        public BasicInfoMessage(string machinename, string username)
        {
            MachineName = machinename;
            UserName = username;
        }
    }
}
