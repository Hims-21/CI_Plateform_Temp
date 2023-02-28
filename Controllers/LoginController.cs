using Microsoft.AspNetCore.Mvc;
using Registration.Datamodel.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Registration.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly EmployeeDbContext _db;

        public LoginController(ILogger<LoginController> logger, EmployeeDbContext db)
        {
            _logger= logger;
            _db= db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [Route("/Login/Registration" , Name ="Register")]
        public IActionResult Registration(User obj)
        {
            var userData = new User()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                PhoneNumber = obj.PhoneNumber,
                Password = obj.Password,
                CityId = 1,
                CountryId = 1,
            };
            _db.Users.Add(userData);
            _db.SaveChanges();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    }
}
