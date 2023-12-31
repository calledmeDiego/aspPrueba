﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustentacionASPNETCoreMVC.Models;

public partial class Area
{
    public Area()
    {
        Usuarios = new HashSet<Usuario>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdArea { get; set; }
    public string NameArea { get; set; }
    
    public virtual ICollection<Usuario> Usuarios { get; set; }
}
