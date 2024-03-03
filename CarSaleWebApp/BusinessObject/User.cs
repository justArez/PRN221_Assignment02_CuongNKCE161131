using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class User
{
    public string Userid { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public string Roleid { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Role Role { get; set; } = null!;

    public User() { }

    public User(string userId, string username, string password) {
        this.Userid = userId;
        this.Username = username;
        this.Password = password;
        this.IsActive = true;
        this.Roleid = "2";
    }
}
