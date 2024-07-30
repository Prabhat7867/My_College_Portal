using System;
using System.Collections.Generic;

namespace Students_Result.Models;

public partial class AdminCredential
{
    public int AdminId { get; set; }

    public string Password { get; set; } = null!;
}
