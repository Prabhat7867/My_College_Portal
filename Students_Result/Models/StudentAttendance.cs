using System;
using System.Collections.Generic;

namespace Students_Result.Models;

public partial class StudentAttendance
{
    public int RollNo { get; set; }

    public string Name { get; set; } = null!;

    public string Date { get; set; } = null!;

    public string IsPresent { get; set; } = null!;
}
