using System.Linq;
using EFGetStarted;
using EFGetStarted.Model;

using var dbContext = new ComponentsDbContext();

var tree1 = new Tree
{
    Name = "Tree1"
};
var tree2 = new Tree
{
    Name = "Tree2"
};
var leaf1 = new Leaf
{
    Name = "Leaf1"
};
var leaf2 = new Leaf
{
    Name = "Leaf2"
};

tree1.AddComponent(tree2);
tree1.AddComponent(leaf1);
tree2.AddComponent(leaf2);

dbContext.Add(tree1);
dbContext.SaveChanges();

var treeList = dbContext.Trees.ToList();
var leaves = dbContext.Leaves.ToList();
var components = dbContext.Components.ToList();