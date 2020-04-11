using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods.Model
{
    abstract class Character
    {
        public string Name { get; set; }
        public string Weapon { get; set; }
        public List<string> Backpack { get; set; }

        private string Level { get; set; }
    }
}
