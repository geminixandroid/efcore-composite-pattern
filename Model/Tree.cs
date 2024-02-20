using System.Collections.Generic;
using System.Linq;

namespace EFGetStarted.Model;

public class Tree : ComponentBase
{
    public IReadOnlyCollection<ComponentBase> Components { get; set; } = new List<ComponentBase>();

    public void AddComponent(ComponentBase addedComponentBase)
    {
        var list = Components.ToList();

        if (list.Contains(addedComponentBase)) return;

        list.Add(addedComponentBase);

        Components = list;
    }
}