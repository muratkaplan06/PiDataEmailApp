namespace PiDataEmailApp.Entities
{
    public class EpostaGonderimDetay
    {
        public int Id { get; set; }
        public int? EpostaGonderimId { get; set; }
        public EpostaGonderim EpostaGonderim { get; set; }
        public int? KisiId { get; set; }
        public Kisi Kisi { get; set; }


    }
}
