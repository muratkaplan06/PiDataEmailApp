using PiDataEmailApp.Entities;

namespace PiDataEmailApp.Business.Models;

public class EpostaGonderimModel
{
    public string Konu { get; set; }
    public string Icerik { get; set; }
    public string GonderenEmail { get; set; }
    public int EpostaAdresiId { get; set; }
    public int[] KisiListesiIds { get; set; }
}