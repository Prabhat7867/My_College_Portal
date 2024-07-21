using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Students_Result.Models;

public partial class Y2024
{
    [Key]
    [Required]
    public int RollNo { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int PassedYear { get; set; }

    [Required]
    public int Hindi { get; set; }

    [Required]
    public int English { get; set; }

    [Required]
    public int Physics { get; set; }

    [Required]
    public int Chemistry { get; set; }

    [Required]
    public int Maths { get; set; }

}
