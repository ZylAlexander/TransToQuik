namespace TransToQuik.Interfaces;

public interface IQuikHandler<in T>
{
    void OnReply(T result);
}

