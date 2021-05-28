using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Management;

namespace Program
{
    public class Character:IOdmienialny
    {

        public Character()
        {
        }

        public string Name{ get; set; }
        public string Short { get; set; }
        public bool Infight { get; set; }

        //  public Odmiana Odm
        //  { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Odmiana Odm { get; set; } = new Odmiana();
    }
}
