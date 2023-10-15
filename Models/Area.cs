using System;
using System.Collections.Generic;

namespace SustentacionASPNETCoreMVC.Models
{
    public partial class Area
    {
        public Area()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdArea { get; set; }
        public string NameArea { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
