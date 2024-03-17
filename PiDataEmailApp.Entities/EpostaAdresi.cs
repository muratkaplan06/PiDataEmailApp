namespace PiDataEmailApp.Entities
{
    public class EpostaAdresi
    {
        public int Id { get; set; }
        public string Adres { get; set; }
        public string MailSunucuAdresi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public int Port { get; set; }
    }
}
