using System.Collections;

namespace HyperX;

public class ComponentHostCollection :
   IComponentHostCollection

{
    private readonly List<IComponentHost> hosts = [];

    public void Add(IComponentHost host)
    {
        hosts.Add(host);
    }

    public IEnumerator<IComponentHost> GetEnumerator() =>
        hosts.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        hosts.GetEnumerator();
}
