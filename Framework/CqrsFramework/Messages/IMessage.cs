namespace CqrsFramework.Messages
{
    public interface IMessage
    {
        string MessageType { get; set; }
    }
}
