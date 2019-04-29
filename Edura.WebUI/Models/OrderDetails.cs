using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace Edura.WebUI.Models
{
    public class OrderDetails
    {
        [Required(ErrorMessage = "Lütfen adres tanımı giriniz.")]
        public string AdresTanimi { get; set; }

        [Required(ErrorMessage = "Lütfen adres giriniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen semt giriniz.")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Lütfen telefon giriniz.")]
        public string Telefon { get; set; }
    }
}