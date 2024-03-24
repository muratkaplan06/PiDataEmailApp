namespace PiDataEmailApp.Entities;

public class EpostaGonderim
{
    public Guid Id { get; set; }
    public string Konusu { get; set; }
    public string Icerigi { get; set; }
    public string GonderenEpostaAdresi { get; set; }
    public int EpostaAdresiId { get; set; }
    public EpostaAdresi EpostaAdresi { get; set; }
}