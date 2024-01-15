using System.Linq;
using EFGetStarted;
using EFGetStarted.Model;

using var db = new MyDbContext();

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

db.Add(tree1);
db.SaveChanges();

var treeList = db.Trees.ToList();
var leaves = db.Leaves.ToList();
var components = db.Components.ToList();