using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_App.Data;
using mnd.Logic.BC_App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_App
{
    public class DxLayoutService
    {
        public static List<DxGridLayout> LayoutListeGetir(string grupAd, string kulllaniciId = null)
        {
            AppDataContext dc = new AppDataContext();

            var sonuc = dc.Set<DxGridLayout>()
                .Where(c => c.GrupAd == grupAd)
                .Where(c => c.KullaniciId == kulllaniciId || kulllaniciId == null)
                .Select(c => new DxGridLayout { Id = c.Id, Baslik = c.Baslik })
                .ToList();

            return sonuc;
        }

        public static DxGridLayout XmlDataGetirFromId(int id)
        {
            AppDataContext dc = new AppDataContext();

            var sonuc = dc.DxGridLayouts.Where(c => c.Id == id)
               .FirstOrDefault();

            return sonuc;
        }

        public static void KaydetLayout(int id, string xml_text)
        {
            AppDataContext dc = new AppDataContext();

            var sonuc = dc.DxGridLayouts.Where(c => c.Id == id)
               .FirstOrDefault();

            sonuc.XmlData = xml_text;

            dc.SaveChanges();

            dc.Dispose();
        }

        public static void EkleLayout(DxGridLayout layout)
        {
            AppDataContext dc = new AppDataContext();

            var sonuc = dc.DxGridLayouts.Add(layout);

            dc.SaveChanges();

            dc.Dispose();
        }

        public static void YenidenAdlandir(int dxLayoutId, string text)
        {
            AppDataContext dc = new AppDataContext();

            var sonuc = dc.DxGridLayouts.Find(dxLayoutId);
            sonuc.Baslik = text;

            dc.SaveChanges();

            dc.Dispose();
        }
    }
}