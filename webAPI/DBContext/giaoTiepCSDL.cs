using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webAPI.Data.DangNhap;
using webAPI.Data.HoaDon;
using webAPI.Data.Nguon;
using webAPI.Data.Sach;

namespace webAPI.DBContext
{
    public class giaoTiepCSDL : DbContext
    {
        public giaoTiepCSDL(DbContextOptions<giaoTiepCSDL> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<UserRole> userroles { get; set; }
        public DbSet<hoadon> hoadons { get; set; }
        public DbSet<tacgia> tacgias { get; set; }
        public DbSet<nhaxb> nhaxuatbans { get; set; }
        public DbSet<theloai> theloais { get; set; }
        public DbSet<sach> saches { get; set; }
        public DbSet<chitiethoadon> chitiethoadons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<theloai_sach>().HasKey(u => new { u.sachID, u.theloaiID });

            //Quan hệ 1 - nhiều (UserRole - User)
            modelBuilder.Entity<User>()
                .HasOne<UserRole>(s => s.Roles)
                .WithMany(g => g.users)
                .HasForeignKey(s => s.roleID)
                .OnDelete(DeleteBehavior.SetNull);

            //Quan hệ 1 - nhiều (user - hoadon)
            modelBuilder.Entity<hoadon>()
                .HasOne<User>(s => s.Users)
                .WithMany(g => g.hoadons)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            //Quan hệ 1 - nhiều (hoadon - chitiethoadon)
            modelBuilder.Entity<chitiethoadon>()
                .HasOne<hoadon>(s => s.hoadon)
                .WithMany(g => g.chitiethoadons)
                .HasForeignKey(s => s.hoadonID)
                .OnDelete(DeleteBehavior.SetNull);

            //Quan hệ 1 - nhiều (theloai - theloai_sach)
            modelBuilder.Entity<theloai_sach>()
                .HasOne<theloai>(s => s.theloai)
                .WithMany(g => g.theloai_Saches)
                .HasForeignKey(s => s.theloaiID)
                .OnDelete(DeleteBehavior.SetNull);

            //Quan hệ 1 - nhiều (sach - theloai_sach)
            modelBuilder.Entity<theloai_sach>()
                .HasOne<sach>(s => s.sach)
                .WithMany(g => g.theloai_Saches)
                .HasForeignKey(s => s.sachID)
                .OnDelete(DeleteBehavior.SetNull);

            //Quan hệ 1 - nhiều (sach - chitiethoadon)
            modelBuilder.Entity<chitiethoadon>()
                .HasOne<sach>(s => s.sach)
                .WithMany(g => g.chitiethoadons)
                .HasForeignKey(s => s.sachID)
                .OnDelete(DeleteBehavior.SetNull);

            //Quan hệ 1 - nhiều (tacgia - sach)
            modelBuilder.Entity<sach>()
                .HasOne<tacgia>(s => s.tacgia)
                .WithMany(g => g.saches)
                .HasForeignKey(s => s.tacgiaID)
                .OnDelete(DeleteBehavior.SetNull);

            //Quan hệ 1 - nhiều (nhaxb - sach)
            modelBuilder.Entity<sach>()
                .HasOne<nhaxb>(s => s.nhaxuatban)
                .WithMany(g => g.saches)
                .HasForeignKey(s => s.nhaxbID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
