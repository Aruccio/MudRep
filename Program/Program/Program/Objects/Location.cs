using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Location
    {


        public Location() { }

        public Location(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string Short { get; set; }

        public string Long { get; set; }

        public List<string[]> Exits { get; set; }
        public List<string[]> Things { get; set; }

        public List<NPC> NPCs { get; set; }

        public List<Character> Characters { get; set; }

        public List<Itemy> Items { get; set; }

    }
}
