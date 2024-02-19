using System.Collections.Concurrent;

namespace HyperX;

public class SubscriptionCollection :
    ConcurrentDictionary<object, List<WeakReference>>;
