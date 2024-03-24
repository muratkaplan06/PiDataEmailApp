namespace PiDataEmailApp.Business.Models
{
    public class EpostaGonderimDetayModel
    {
        public Guid EpostaGonderimId { get; set; }
        public int KisiId { get; set; }
        public DateTime GonderimTarihi { get; set; }
        public bool GonderimDurumu { get; set; }
    }
}
