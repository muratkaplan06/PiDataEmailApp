namespace PiDataEmailApp.Entities
{
    public class EpostaGonderimDetay
    {
        public int Id { get; set; }
        public Guid? EpostaGonderimId { get; set; }
        public EpostaGonderim EpostaGonderim { get; set; }
        public int? KisiId { get; set; }
        public Kisi Kisi { get; set; }
        public DateTime GonderimTarihi { get; set; }
        public bool GonderimDurumu { get; set; } = false;
    }
}
