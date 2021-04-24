using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_App.Domain;
using mnd.Logic.BC_Satis._Seyahat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_App.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<DxGridLayout> DxGridLayouts { get; set; }
        public DbSet<IsMerkezi> IsMerkezleri { get;  set; }

        public DbSet<MailLog> MailLogs { get; set; }
        public DbSet<MailTanim> MailTanims { get;  set; }
        public DbSet<UlkeSabit> Ulkes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var yol = GlobalSettings.Default.SqlCnnString;

            optionsBuilder.UseSqlServer(yol);
            optionsBuilder.EnableDetailedErrors(true);

            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("App");

            modelBuilder.Entity<UlkeSabit>().ToTable(nameof(UlkeSabit));
            modelBuilder.Entity<Kullanici>().ToTable(nameof(Kullanici));
            modelBuilder.Entity<DxGridLayout>().ToTable(nameof(DxGridLayout));

            modelBuilder.Entity<IsMerkezi>().ToTable(nameof(IsMerkezi));

            modelBuilder.Entity<MailLog>().ToTable(nameof(MailLog));

            modelBuilder.Entity<MailTanim>().ToTable(nameof(MailTanim));

            base.OnModelCreating(modelBuilder);
        }
    }
}