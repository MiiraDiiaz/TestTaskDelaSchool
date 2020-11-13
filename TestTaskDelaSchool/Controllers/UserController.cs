using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestTaskDelaSchool.Models;
using TestTaskDelaSchool.Data;
using TestTaskDelaSchool.ViewModel;

namespace TestTaskDelaSchool.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        ContextDB _db;

        public UserController(ILogger<UserController> logger, ContextDB db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.Users.ToList());
        }
        /// <summary>
        /// Вывод учредителей
        /// </summary>
        [HttpGet]
        public IActionResult DetailsFounder(List<Founder> model,int id)
        {
            var founder = _db.Founders.Where(com => com.UserId == id);
            if (founder != null)
            {
                foreach (var item in founder)
                {
                    Founder founderUser = new Founder
                    {
                        Name = item.Name,
                        INN = item.INN
                    };
                    model.Add(founderUser);
                }
                return View(founder);
            }
            return NotFound();
        }

        #region Создание пользователя
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(UserFounderVM model)
        {
            User user = new User
            {
                Name = model.NameCompane,
                INN = model.INNCompany,
                TypeOfCompany = model.TypeOfCompany
            };
            _db.Users.Add(user);
            _db.SaveChanges();

            Founder founder = new Founder
            {
                UserId = user.Id,
                INN = model.INNFounder,
                Name = model.NameFounder
            };
            _db.Founders.Add(founder);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion

        #region Создание уредителя
        [HttpGet]
        public IActionResult CreateFounder(int id)
        {
            Founder founder = new Founder
            {
                UserId = id,
            };
            return View(founder);
        }

        [HttpPost]
        public IActionResult CreateFounder(Founder model)
        {
            Founder founder = new Founder
            {
                UserId = model.Id,
                INN = model.INN,
                Name = model.Name
            };
            _db.Founders.Add(founder);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        #endregion

        #region Изменение пользователя
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            User user = _db.Users.FirstOrDefault(p => p.Id == id);
            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(User user)
        {

            _db.Users.Update(user);
            _db.SaveChanges();

            return RedirectToAction("index");
        }
        #endregion

        #region Удаление пользователя
        [HttpPost]
        public IActionResult Delete(int id)
        {
            User user = _db.Users.FirstOrDefault(p => p.Id == id);
            _db.Users.Remove(user);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
