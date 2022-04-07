using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnogiASP.Data;
using TechnogiASP.Models;

namespace TechnogiASP.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            List<UserModel> users = new List<UserModel>();
            UserDAO userDAO = new UserDAO();

            users = userDAO.FetchAll();

            return View("Index", users);
        }

        public ActionResult Details(int id)
        {
            UserDAO userDAO = new UserDAO();
            UserModel user = userDAO.FetchOne(id);

            return View("Details", user);
        }

        public ActionResult Create()
        {
            return View("UserForm");
        }

        public ActionResult ProcessCreate(UserModel userModel)
        {
            UserDAO userDAO = new UserDAO();

            userDAO.CreateUpdate(userModel);

            return View("Details", userModel);
        }

        public ActionResult Edit(int id)
        {
            UserDAO userDAO = new UserDAO();
            UserModel user = userDAO.FetchOne(id);

            return View("UserForm", user);
        }

        public ActionResult Delete(int id)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.Delete(id);

            List<UserModel> users = userDAO.FetchAll();

            return View("Index", users);
        }

        public ActionResult SearchForName(string searchPhrase)
        {
            List<UserModel> users = new List<UserModel>();
            UserDAO userDAO = new UserDAO();

            users = userDAO.SearchForName(searchPhrase);

            return View("Index", users);
        }
    }
}