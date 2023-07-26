using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;



//add bussiness and dataAccess
using BussinessLogic;
using DataAccess;
using DataAccess.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        
        UsersDAL usersDAL = new UsersDAL();

        // GET: User
        public ActionResult Index()
        {  
            return View();
        }

        //GET UserList
        public ActionResult UserList()
        {

            UsersBL usersBL = new UsersBL();
            List<Users> usersFromDAL = usersBL.GetUsers();
            return View(usersFromDAL);

        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult RegisterSubmit(Users newUser)
        {

            if (ModelState.IsValid)
            {
                usersDAL.AddUser(newUser);
                return View("RegisterSubmit", newUser);
            }
            else
            {
                return View("Register", newUser);
            }
        }
    }
}