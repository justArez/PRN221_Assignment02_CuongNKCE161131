﻿using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Role
{
    public string Roleid { get; set; } = null!;

    public string Rolename { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
