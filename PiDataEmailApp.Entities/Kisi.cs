﻿namespace PiDataEmailApp.Entities
{
    public class Kisi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string? Telefon { get; set; }
        public string Eposta { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string EpostaAdresi { get; set; }
        public string Cinsiyet { get; set; }
        public string? Unvan { get; set; }
        public string? Isyeri { get; set; }
    }
}
