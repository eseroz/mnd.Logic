using System;

namespace mnd.Logic.QueryModel
{
    public class SiparisDolulukGrupDto : IEquatable<SiparisDolulukGrupDto>
    {
        public int SevkYil { get; set; }
        public string CariKod { get; set; }
        public string KullanimAlanTipKod { get; set; }
        public string PlasiyerAdSoyad { get; set; }

        public bool Equals(SiparisDolulukGrupDto other)
        {
            if (SevkYil == other.SevkYil && CariKod == other.CariKod && KullanimAlanTipKod == other.KullanimAlanTipKod)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hashFirstName = KullanimAlanTipKod.GetHashCode();
            int hashLastName = CariKod.GetHashCode();

            return hashFirstName ^ hashLastName;
        }
    }
}