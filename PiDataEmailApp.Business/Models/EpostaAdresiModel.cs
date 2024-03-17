using System.ComponentModel.DataAnnotations;

namespace PiDataEmailApp.Business.Models;

public class EpostaAdresiModel
{
    [Required(ErrorMessage = "Adres alanı boş geçilemez")]
    [StringLength(100, ErrorMessage = "Adres alanı en fazla 100 karakter olmalıdır")]
    [EmailAddress(ErrorMessage = "Geçersiz mail adresi")]
    public string Adres { get; set; }
    [Required(ErrorMessage = "Mail sunucu adresi alanı boş geçilemez")]
    [StringLength(100, ErrorMessage = "Mail sunucu adresi alanı en fazla 100 karakter olmalıdır")]
    public string MailSunucuAdresi { get; set; }
    [Required(ErrorMessage = "Kullanıcı adı alanı boş geçilemez")]  
    [StringLength(100, ErrorMessage = "Kullanıcı adı alanı en fazla 100 karakter olmalıdır")]
    public string KullaniciAdi { get; set; }
    [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
    [StringLength(100, ErrorMessage = "Şifre alanı en fazla 100 karakter olmalıdır")]
    public string Sifre { get; set; }
    [Required(ErrorMessage = "Port alanı boş geçilemez")]
    public int Port { get; set; }
}