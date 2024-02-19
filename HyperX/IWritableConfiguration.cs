namespace HyperX;

public interface IWritableConfiguration<out TConfiguration>
    where TConfiguration :
    class
{
    void Write(Action<TConfiguration> updateDelegate);
}
