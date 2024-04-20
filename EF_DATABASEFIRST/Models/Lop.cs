using System;
using System.Collections.Generic;

namespace EF_DATABASEFIRST.Models;

public partial class Lop
{
    public string MaLop { get; set; } = null!;

    public int? SiSo { get; set; }

    public string? MaKhoa { get; set; }

    public virtual Khoa? MaKhoaNavigation { get; set; }

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}
