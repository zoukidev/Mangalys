[System.Serializable]
public class BasicInfoMessage : MangalysServer.Messages.Message
{
    public new int Protocol = 1;
    public string SpecialName { get; set; }

    public BasicInfoMessage() { }

    public BasicInfoMessage(string name)
    {
        this.SpecialName = name;
    }
}