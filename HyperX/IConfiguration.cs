namespace HyperX;

public interface IConfiguration<out TConfiguration>
    where TConfiguration :
    class
{
    TConfiguration Value { get; }
}
