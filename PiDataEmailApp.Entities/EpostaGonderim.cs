namespace PiDataEmailApp.Entities;

public class EpostaGonderim
{
    public int Id { get; set; }
    public string Konusu { get; set; }
    public string Icerigi { get; set; }
    public List<Kisi> KisiListesi { get; set; }
    public string GonderenEpostaAdresi { get; set; }
}