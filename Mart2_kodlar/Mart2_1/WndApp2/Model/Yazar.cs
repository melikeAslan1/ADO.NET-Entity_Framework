namespace WndApp2.Model
{
    class Yazar
    {
        public int YazarID { get; set; }
        public string YazarAdi { get; set; }
        public string YazarSoyad { get; set; }

        public string YazarAdSOYAD { get => YazarAdi + " " + YazarSoyad; }
    }
}
