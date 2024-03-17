using PiDataEmailApp.Entities;

namespace PiDataEmailApp.Business.Models;

public class EpostaGonderimModel
{
    public string Konusu { get; set; }
    public string Icerigi { get; set; }
    public List<Kisi> KisiListesi { get; set; }
    public string GonderenEpostaAdresi { get; set; }
}