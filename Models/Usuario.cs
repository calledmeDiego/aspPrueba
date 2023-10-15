using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SustentacionASPNETCoreMVC.Models;

[Index(nameof(UserName), IsUnique = true)]
public partial class Usuario
{
    public int IdUser { get; set; } 
    public string NameComplete { get; set; }

    public string UserName { get; set; }
    public string PasswordUser { get; set; }
    public int? IdArea { get; set; }
    public DateTime? DateRegister { get; set; }

    public virtual Area OArea { get; set; }
}
