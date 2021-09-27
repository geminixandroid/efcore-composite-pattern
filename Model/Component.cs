using System;
using System.Collections.Generic;

namespace EFGetStarted.Model
{
    public abstract class Component
    {
        public Component()
        {
        }

        public Tree ParentTree { get; set; }
         
        public int Id { get; set; }
        public string Name { get; set; }
    }
}