using System.ComponentModel.DataAnnotations;

namespace MultiShop.UI.Models
{
    public class FileUploadViewModel
    {
        public string ProductId { get; set; } = "deneme";
        [Required(ErrorMessage = "En az 1 dosya yüklemelisiniz.")]
        [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "Sadece resim dosyası (jpg, jpeg, png) yükleyebilirsiniz.")]
        public IFormFileCollection? Files { get; set; }
    }
}
