using System;
using System.Linq;
using EF_DATABASEFIRST.Models;

namespace EF_DATABASEFIRST
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tạo một đối tượng DbContext
            using (var context = new EfDatabasefirstContext())
            {
                // Lấy tất cả sinh viên từ cơ sở dữ liệu thuộc khoa CNTT và có độ tuổi từ 18 đến 20
                var sinhviens = context.Sinhviens
                    .Where(s => s.MaLopNavigation != null && s.MaLopNavigation.MaKhoaNavigation != null && s.MaLopNavigation.MaKhoaNavigation.MaKhoa == "CNTT" && s.NgaySinh != null)
                    .Where(s => s.NgaySinh.Value.Year >= DateTime.Now.Year - 20 && s.NgaySinh.Value.Year <= DateTime.Now.Year - 18)
                    .ToList();

                // In ra thông tin của các sinh viên
                foreach (var sinhvien in sinhviens)
                {
                    Console.WriteLine($"Mã sinh viên: {sinhvien.MaSv}");
                    Console.WriteLine($"Tên sinh viên: {sinhvien.TenSv}");
                    Console.WriteLine($"Ngày sinh: {sinhvien.NgaySinh:dd/MM/yyyy}");
                    Console.WriteLine($"Mã lớp: {sinhvien.MaLop}");
                    Console.WriteLine();
                }
            }
        }
    }
}
