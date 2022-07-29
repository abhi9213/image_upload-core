using image_upload.Models;
using Microsoft.EntityFrameworkCore;

namespace image_upload.data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        public DbSet<Imageclass> Imageclasses { get; set; }
    }
}
