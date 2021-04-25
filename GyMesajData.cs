using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;

namespace mnd.Logic
{
    public class GyMesajRepository
    {
        GyMesajDbContext _dc = new GyMesajDbContext();

        public GyMesajRepository()
        {

        }

        public void Kaydet()
        {
            _dc.SaveChanges();
        }

        public ObservableCollection<Mesaj> MesajlariGetirFromEntityRef(Guid entityRowGuid)
        {
            var m = _dc.Mesajlar.Where(c => c.RefEntityGuid == entityRowGuid).ToObservableCollection();
            return m;
        }


        public void MesajEkle(Mesaj mesaj)
        {
            _dc.Add(mesaj);
            _dc.SaveChanges();

            if (mesaj.DokumanIcerik == null) return;

            var commandText = $"update MNDAPPFS.App.Mesaj set DokumanIcerik='{mesaj.DokumanIcerik.Trim()}' where Id={mesaj.Id}";

            _dc.Database.ExecuteSqlCommand(commandText);
        }

        public string DokumanIcerikGetir(int id)
        {
            var connection = (SqlConnection)_dc.Database.GetDbConnection();

            var commandText = $"select DokumanIcerik from MNDAPPFS.App.Mesaj where Id={id}";

            var command = connection.CreateCommand();
            command.CommandText = commandText;

            if (connection.State == ConnectionState.Closed) connection.Open();

            var sonuc = command.ExecuteScalar();

            if (sonuc != DBNull.Value)
                return (string)sonuc;
            else
                return null;
        }


        public Dictionary<Guid, MesajOkunmaDurum> MesajSayilariGetir(string kullaniciId)
        {
            var dc1 = new GyMesajDbContext();

            var x = dc1.Mesajlar;

            var KullaniciTumMesajSayilari = dc1.Mesajlar
                .Select(c => new { RowGuid = c.RefEntityGuid, OkunmaSayisi = c.Okuyanlar.Contains(kullaniciId) ? 0 : 1 })
                .AsNoTracking()
                .ToList();


            var sonuc = KullaniciTumMesajSayilari
                .GroupBy(o => new { o.RowGuid })
                .Select(g => new
                {
                    g.Key.RowGuid,
                    ToplamMesajSayisi = g.Count(),
                    OkunmamisMesajSayisi = g.Sum(c => c.OkunmaSayisi)
                })

                 .ToDictionary(g => g.RowGuid, g => new MesajOkunmaDurum(g.ToplamMesajSayisi, g.OkunmamisMesajSayisi));


            return sonuc;

        }


    }

    public class GyBindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;



        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

    }

    public class Mesaj : GyBindableBase
    {
        private string _mesajIcerik;
        private string _gonderen;
        private string _dokumanIcerik;
        private DateTime _mesajtarihi;
        private bool _gidenMi;
        private string _dokumanAdi;
        private string _okuyanlar;
        private bool _seciliMi;

        [Key]
        public int Id { get; set; }

        public Guid RefEntityGuid { get; set; }

        public string Gonderen
        {
            get => _gonderen;
            set => SetProperty(ref _gonderen, value);
        }

        public string DokumanAdi
        {
            get => _dokumanAdi;
            set => SetProperty(ref _dokumanAdi, value);
        }

        [NotMapped]
        public bool GidenMi
        {
            get => _gidenMi;
            set => SetProperty(ref _gidenMi, value);
        }

        public string MesajIcerik
        {
            get => _mesajIcerik;
            set => SetProperty(ref _mesajIcerik, value);
        }

        public DateTime MesajTarihi
        {
            get => _mesajtarihi;
            set => SetProperty(ref _mesajtarihi, value);
        }

        [NotMapped]
        public bool EkVarMi => !String.IsNullOrEmpty(_dokumanAdi);


        [NotMapped]
        public string DokumanIcerik
        {
            get => _dokumanIcerik;
            set => SetProperty(ref _dokumanIcerik, value);
        }

        public string Okuyanlar
        {
            get => _okuyanlar;
            set => _okuyanlar = value;
        }

        [NotMapped]
        public bool SeciliMi { get => _seciliMi; set => SetProperty(ref _seciliMi, value); }
    }

    public struct MesajOkunmaDurum
    {
        public MesajOkunmaDurum(int t_mesaj, int okunmamis_t_mesaj)
        {
            ToplamMesajSayisi = t_mesaj;
            OkunmamisMesajSayisi = okunmamis_t_mesaj;
        }

        public int ToplamMesajSayisi { get; set; }
        public int OkunmamisMesajSayisi { get; set; }
    }

    public class GyMesajDbContext : DbContext
    {
        public DbSet<Mesaj> Mesajlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var yol = GlobalSettings.Default.SqlCnnString;

                yol = yol.Replace("MNDAPPDB", "MNDAPPFS");
                optionsBuilder.UseSqlServer(yol);
                optionsBuilder.EnableDetailedErrors(true);


                base.OnConfiguring(optionsBuilder);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mesaj>().ToTable(nameof(Mesaj), "App");
            base.OnModelCreating(modelBuilder);
        }

    }



}
