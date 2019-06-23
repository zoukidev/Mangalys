[System.Serializable]
public class BasicVideoMessage : MangalysServer.Messages.Message
{
    public new int Protocol = 2;
    public byte[] Image { get; set; }

    public BasicVideoMessage() { }

    public BasicVideoMessage(byte[] image)
    {
        Image = image;
    }
}

