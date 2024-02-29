namespace HyperX.DateTime;

public class DateTimeViewModel : 
    ValueViewModel<DateTimeOffset>
{
    public DateTimeViewModel(IServiceProvider serviceProvider, 
        IServiceFactory serviceFactory, 
        IPublisher publisher,
        ISubscriber subscriber,
        IDisposer disposer) : base(serviceProvider, serviceFactory, publisher, subscriber, disposer)
    {
        Value = DateTimeOffset.Now;
    }
}
