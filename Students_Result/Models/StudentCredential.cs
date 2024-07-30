using System;
using System.Collections.Generic;

namespace Students_Result.Models;

public partial class StudentCredential
{
    public int RollNo { get; set; }

    public string Password { get; set; } = null!;
}
