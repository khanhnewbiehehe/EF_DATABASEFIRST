using System;
using System.Collections.Generic;

namespace EF_DATABASEFIRST.Models;

public partial class Sinhvien
{
    public string MaSv { get; set; } = null!;

    public string? TenSv { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? MaLop { get; set; }

    public virtual Lop? MaLopNavigation { get; set; }
}
