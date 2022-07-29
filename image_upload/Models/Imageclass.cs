using System.ComponentModel.DataAnnotations;

namespace image_upload.Models
{
    public class Imageclass
    {[Key]
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
