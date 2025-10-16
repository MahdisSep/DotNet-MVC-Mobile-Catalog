using Microsoft.AspNetCore.Mvc;
namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{
    // public methods are an http end points
   public IActionResult Index()
{
    return View();
}
    // 
   // GET: /HelloWorld/Welcome/ 
  // Requires using System.Text.Encodings.Web;
public IActionResult Welcome(string name, int numTimes = 1) //default is 1
{
    //return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");

    //htmlencoder.default.encode ==> to protect the app from malicious input
        ViewData["Message"] = "Hello " + name;
        ViewData["NumTimes"] = numTimes;

        return View();
    
}
}