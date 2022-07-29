using image_upload.data;
using image_upload.Models;
using image_upload.ViewModal;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace image_upload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DataContext _dbobj;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, DataContext dbobj)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _dbobj = dbobj;

        }

        public IActionResult Index()
        {
            List<Imageclass> imgobj = _dbobj.Imageclasses.ToList();    
            return View(imgobj);
        }
        [HttpGet]
        public IActionResult ImageUploadfun()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImageUploadfun(ImageViewModal vm)
        {
           if(vm!=null)
            {
                var path = _webHostEnvironment.WebRootPath;
                var filepath = "Image/" + vm.Imagepath.FileName;
                var fullpath = Path.Combine(path, filepath);
                UploadFile(vm.Imagepath, fullpath);
                var data = new Imageclass()
                {
                    ImageName=vm.ImageName,
                    ImagePath=filepath
                };
                _dbobj.Add(data);
                _dbobj.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public void UploadFile(IFormFile file,string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}