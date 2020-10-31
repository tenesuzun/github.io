using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace VİBF.Models
{
    public class Form
    {
        [Required(ErrorMessage ="Bu alan doldurulmak zorundadır")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır")]
        [DataType(DataType.PhoneNumber)]
        public long Telefon { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır")]
        public long TCKN { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır")]
        [DataType(DataType.Date)]
        public DateTime Dgt { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır")]
        public string Cinsiyet { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır")]
        public string Ehliyet { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır")]
        public string Medeni_hal { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır")]
        public string Sicil { get; set; }

        [Required(ErrorMessage = "Bu alan doldurulmak zorundadır")]
        public IFormFile Cv { get; set; }
    }
}
