using System;
using System.Collections.Generic;

namespace EF_SQLServer.Models.EF;

public partial class DeptInfo
{
    public int DeptNo { get; set; }

    public string? DeptName { get; set; }

    public string? DeptLocation { get; set; }
}
