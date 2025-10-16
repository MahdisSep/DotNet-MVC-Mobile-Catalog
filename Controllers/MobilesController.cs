using MvcMovie.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;


namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMobileContext _context;
         private readonly IWebHostEnvironment _environment;

        public MoviesController(MvcMobileContext context , IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

      public async Task<IActionResult> Index(decimal? mobilePrice ,string? searchString)
    {
        if (_context.Mobile == null)
        {
            return Problem("Entity set 'MvcMobileContext.Mobile'  is null.");
        }

        var mobiles =await _context.Mobile.ToListAsync();

        if (!String.IsNullOrEmpty(searchString))
        {
        
             mobiles = mobiles.Where(s => s.Name!.ToUpper().Contains(searchString.ToUpper())).ToList();
        }

        if(mobilePrice != null)
        {
            mobiles=mobiles.Where(x => x.Price <= mobilePrice).ToList();
        }

        var mobileModel = new MobileModel
        {
            Mobiles =  mobiles
        };

        return View(mobileModel);
}

    
        public async Task<IActionResult> Details(int? id)
        {
            try{
            if (id == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobile
                .FirstOrDefaultAsync(m => m.Id == id);


            var MobileViewModel = new MobileViewModel()
            {
                Name = mobile.Name,
                Color = mobile.Color,
                Description = mobile.Description,
                Price = mobile.Price,
                ExistingImage = mobile.MobileImage


            };

            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }
        catch(Exception)
        {
            throw;
        }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( MobileViewModel mobile)
        {
            
            
            
                string uniqueFileName = ProcessUploadedFile(mobile);
                Mobile m = new()
                {
                    Name = mobile.Name,
                    Color = mobile.Color,
                    Description = mobile.Description,
                    Price = mobile.Price,
                    MobileImage = uniqueFileName

                };

                _context.Add(m);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            
            return View(mobile);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobile.FindAsync(id);
            var mobileViewModel1 = new MobileViewModel()
            {
                Name = mobile.Name,
                Color = mobile.Color,
                Description = mobile.Description,
                Price = mobile.Price,
                ExistingImage = mobile.MobileImage
            };

            if (mobile == null)
            {
                return NotFound();
            }
            return View(mobileViewModel1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MobileViewModel mobile)
        {
            if (id != mobile.Id)
            {
                return NotFound();
            }

               var mobile1 = await _context.Mobile.FindAsync(mobile.Id);
                mobile1.Name = mobile.Name;
                mobile1.Color = mobile.Color;
                mobile1.Description = mobile.Description;
                mobile1.Price = mobile.Price;

                if (mobile.MobilePicture != null)
                {
                    if (mobile.ExistingImage != null)
                    {
                        string filePath = Path.Combine(_environment.WebRootPath,"Uploads", mobile.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }

                    mobile1.MobileImage = ProcessUploadedFile(mobile);
                }

                else
                {
                    mobile1.MobileImage = mobile.ExistingImage;
                }
                try
                {
                    _context.Update(mobile1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobileExists(mobile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            
            return View(mobile);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobile
                .FirstOrDefaultAsync(m => m.Id == id);

             var mobileViewModel1 = new MobileViewModel()
            {
                Name = mobile.Name,
                Color = mobile.Color,
                Description = mobile.Description, 
                Price = mobile.Price,
                ExistingImage = mobile.MobileImage 
            };

            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobileViewModel1);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
          {
            var mobile = await _context.Mobile.FindAsync(id);
            //string deleteFileFromFolder = "wwwroot\\Uploads\\";
            string deleteFileFromFolder=Path.Combine(_environment.WebRootPath, "Uploads");
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), deleteFileFromFolder,mobile.MobileImage);
            _context.Mobile.Remove(mobile);
            if (System.IO.File.Exists(CurrentImage))
            {
                System.IO.File.Delete(CurrentImage);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobileExists(int id)
        {
            return _context.Mobile.Any(e => e.Id == id);
        }

        private string ProcessUploadedFile(MobileViewModel mobile)
        {
            string uniqueFileName = null;
            string path = Path.Combine(_environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (mobile.MobilePicture != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + mobile.MobilePicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    mobile.MobilePicture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }


    }
}
