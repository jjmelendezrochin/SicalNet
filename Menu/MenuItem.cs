using System.Collections.Generic;

namespace UserInterface.Menu
{
    public class MenuItem
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public string Url { get; set; }

        public string Role { get; set; }

        public string Icon { get; set; }

        public string Target { get; set; }

        public List<MenuItem> Children { get; set; }

        public MenuItem()
        {
            Children = new List<MenuItem>();
        }
        
    }
}