using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.BC_PandapForms.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_PandapForms
{
    public class PandapFormsDbContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<FormTanim> FormTanims { get; set; }

        public DbSet<FormGunluk> FormGunluks { get; set; }

        public DbSet<FormYatayData> YatayDatas { get; set; }

        public DbSet<FormSoru> FormSorus { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var yol = GlobalSettings.Default.SqlCnnString;

            yol = yol.Replace("MNDAPPDB", "PandapForm");
            optionsBuilder.UseSqlServer(yol);
            optionsBuilder.EnableDetailedErrors(true);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}
