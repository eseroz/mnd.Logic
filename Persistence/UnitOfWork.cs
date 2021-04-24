using mnd.Logic.BC_Satis._Teklif;
using mnd.Logic.Persistence.Repositories;
using mnd.Logic.Services.SiparisService;
using System;

namespace mnd.Logic.Persistence
{
    public class UnitOfWork : IDisposable
    {
        public PandapContext _context;

        public KullaniciRepository KullaniciRepo { get; }
        public SiparisRepository SiparisRepo { get; }
        public SiparisDisplayService SiparisDtoRepo { get; }

        public SiparisLookUpRepository SiparisLookUpRepo { get; set; }
        public NetsisRepository NetsisRepo { get; set; }
        public PlanlamaRepository PlanlamaRepo { get; set; }
        public SiparisKalemRepository SiparisKalemRepo { get; set; }
        public AppRepository AppRepo { get; set; }
        public AppEntityLogRepository EntiyLogRepo { get; }
        public DuyurularRepository DuyurularRepo { get; }
        public ReceteRepository ReceteRepo { get; }

        public KaliteRepository KaliteRepo { get; }
        public OperasyonRepository OperasyonRepo { get; }
        public OrtakDilRepository OrtakDilRepo { get; set; }

        public SevkiyatEmirRepository SevkiyatEmirRepo { get; set; }

        public NavMenuRepository NavMenuRepo { get; set; }
        public PandapCariRepository PandapCariRepo { get; set; }

        public RaporTanimRepository RaporTanimRepo { get; set; }

        public BankaRepository BankaRepo { get; set; }

        public MuhasebeRepository MuhasebeRepo { get; set; }

        public UlkeRepository UlkeRepo { get; set; }
     

        public UnitOfWork()
        {
            _context = new PandapContext();

            MuhasebeRepo = new MuhasebeRepository(_context);

            KullaniciRepo = new KullaniciRepository(_context);
            SiparisRepo = new SiparisRepository(_context);
            SiparisLookUpRepo = new SiparisLookUpRepository(_context);
            NetsisRepo = new NetsisRepository(_context);

            PlanlamaRepo = new PlanlamaRepository(_context);
            SiparisKalemRepo = new SiparisKalemRepository(_context);
            AppRepo = new AppRepository(_context);
            EntiyLogRepo = new AppEntityLogRepository();

            DuyurularRepo = new DuyurularRepository(_context);

            ReceteRepo = new ReceteRepository(_context);

            KaliteRepo = new KaliteRepository(_context);


            OperasyonRepo = new OperasyonRepository(_context);

            SiparisDtoRepo = new SiparisDisplayService();

            OrtakDilRepo = new OrtakDilRepository(_context);

            SevkiyatEmirRepo = new SevkiyatEmirRepository(_context);

            NavMenuRepo = new NavMenuRepository(_context);

            PandapCariRepo = new PandapCariRepository(_context);

            RaporTanimRepo = new RaporTanimRepository(_context);

            BankaRepo = new BankaRepository(_context);

            UlkeRepo = new UlkeRepository(new BC_App.Data.AppDataContext());

        }

        public int Commit()
        {
            int x = _context.SaveChanges();
            return x;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool DegisiklikVarMi()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}