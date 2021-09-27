using System;
using System.Linq;
using EFGetStarted.Model;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
           
            using (var db = new MyDbContext())
            {
                Tree tree1 = new Tree()
                {
                    Name = "Tree1"
                };

                Tree tree2 = new Tree()
                {
                    Name = "Tree2"
                };
              
                Leaf leaf1 = new Leaf()
                {
                    Name = "Leaf1"
                };
                Leaf leaf2 = new Leaf()
                {
                    Name = "Leaf2",
                };
                tree1.AddComponent(tree2);
                tree1.AddComponent(leaf1);
                tree2.AddComponent(leaf2);

                db.Add(tree1);
                db.SaveChanges();

        
                var treeList = db.Trees.ToList();
                var leaves = db.Leaves.ToList();
                var components = db.Components.ToList();

                
            }
        }
    }
}
