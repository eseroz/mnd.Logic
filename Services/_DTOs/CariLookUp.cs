namespace mnd.Logic.Services._DTOs
{
    public class CariLookUp
    {
        public string CariKod { get; set; }
        public string CariIsim { get; set; }

        // combobox yada list için datasource değişince
        // entity instansları yenilendiğinde selectedvalue çalışmıyor.
        // equal override edilip ilgili Id ler eşleştirilirse sorun çözülüyor
        public override bool Equals(object obj)
        {
            var x = obj as CariLookUp;

            if (x == null) return false;

            if (ReferenceEquals(x, this)) return true;

            return x.CariKod == this.CariKod;
        }

        public override int GetHashCode()
        {
            return (this.CariKod + this.CariIsim + "xyz").GetHashCode();
        }
    }
}