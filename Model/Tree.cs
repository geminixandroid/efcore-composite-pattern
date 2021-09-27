using System.Collections.Generic;
using System.Linq;

namespace EFGetStarted.Model
{
    public class Tree: Component
    {
        
        public IReadOnlyCollection<Component> Components { get; set; } = new List<Component>();
        public void AddComponent(Component addedComponent)
        {
            var list = Components.ToList();
            if (!list.Contains(addedComponent))
            {
                list.Add(addedComponent);
                Components = list;
            }
        }
    }
}