using System;
using System.Collections.Generic;

namespace MaterialDemo.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string? Address { get; set; }

    public double? Salary { get; set; }
}
