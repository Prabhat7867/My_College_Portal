using System;
using System.Collections.Generic;

namespace Students_Result.Models;

public partial class StudentDetail
{
    public int RollNo { get; set; }

    public string Name { get; set; } = null!;

    public string FathersName { get; set; } = null!;

    public string MothersName { get; set; } = null!;

    public int Standard { get; set; }

    public string Dob { get; set; } = null!;

    public int PassedYear { get; set; }
}
