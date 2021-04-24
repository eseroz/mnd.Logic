using mnd.Logic.BC_Satis.Data_LookUp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urun = mnd.Logic.BC_Satis.Data_LookUp.Model.Urun;
using mnd.Logic.BC_Satis.Data_LookUp;
using mnd.Logic.Model.Stok;
using mnd.Logic.Model.App;
using mnd.Logic.Persistence;
using System.Collections.ObjectModel;
using mnd.Logic.BC_Satis._Seyahat;

namespace mnd.Logic.BC_Satis.Repositories
{
    public class LookUpDataService
    {
        public List<AlasimTip> AlasimTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result=dc.AlasimTipleri.ToList();
           

            dc.Dispose();

            return result;

            

        }


        public List<AmbalajTip> AmbalajTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.AmbalajTipleri.ToList();


            dc.Dispose();

            return result;
        }

        public List<BirimTip> BiriTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.BirimTipleri.ToList();


            dc.Dispose();

            return result;
        }

        public List<DovizTip> DovizTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.DovizTipleri.ToList();


            dc.Dispose();

            return result;
        }

        public List<KulcePrimTip> KulcePrimTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.KulcePrimTipleri.ToList();


            dc.Dispose();

            return result;
        }
        public List<KullanimAlanTip> KullanimAlanTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.KullanimAlanTipleri.ToList();


            dc.Dispose();

            return result;
        }

        public List<LmeTip> LmeTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.LmeTipleri.ToList();


            dc.Dispose();

            return result;
        }

        public List<MasuraTip> MasuraTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.MasuraTipleri.ToList();


            dc.Dispose();

            return result;
        }

        public List<OdemeTip> OdemeTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.OdemeTipleri.ToList();


            dc.Dispose();

            return result;
        }

        public List<SatisTip> SatisTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.SatisTipleri.ToList();


            dc.Dispose();

            return result;
        }


        public List<GumrukTip> GumrukTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.GumrukTipleri.ToList();


            dc.Dispose();

            return result;
        }

        public ObservableCollection<Banka> BankaHesaplariGetir() {
            var uw = new UnitOfWork();
            var result = uw.BankaRepo.BankalariGetir();
            var newResult = new ObservableCollection<Banka>();

            foreach (var banka in result)
            {
                banka.BankaHesapListeAd = banka.BankaAd + "-" + banka.HesapSahibi + " " + banka.ParaCinsi;
                newResult.Add(banka);
            }


            uw.Dispose();
            return newResult;
        }



        public List<SertlikTip> SertlikTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.SertlikTipleri.ToList();


            dc.Dispose();

            return result;
        }

        public List<TeslimTip> TeslimTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.TeslimTipleri.ToList();


            dc.Dispose();

            return result;
        }

        public List<YuzeyTip> YuzeyTipleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.YuzeyTipleri.ToList();


            dc.Dispose();

            return result;
        }


        public List<TBLIHRSTK> UrunleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.Urunler.ToList();


            dc.Dispose();

            return result;
        }

        public List<TasimaSekli> TasimaSekilleriGetir()
        {
            var dc = new _SatisLookUpDbContext();
            var result = dc.TasimaSekilleri.ToList();


            dc.Dispose();

            return result;

        }

    }
}
