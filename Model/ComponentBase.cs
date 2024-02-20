namespace EFGetStarted.Model
{
    public abstract class ComponentBase
    {
        // ReSharper disable once EmptyConstructor
        protected ComponentBase()
        {
        }

        public Tree ParentTree { get; set; }
         
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}