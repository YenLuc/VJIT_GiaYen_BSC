using BSC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSC.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Create()
        {
            BigSchoolContext context = new BigSchoolContext();
            Course objCourse = new Course();
            objCourse.ListCategory = context.Categories.ToList();

            return View(objCourse);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Course obj)
        {
            BigSchoolContext context = new BigSchoolContext();

            //kho xet
            //ModelState.Remove("LecturerId");
            //if(!ModelState.IsValid)
            //{
            //    obj.ListCategory = context.Categories.ToList();
            //    return View("Create", obj);
            //}

            // Không xét valid LectureId vì bằng user đăng nhập
            ModelState.Remove("LecturerId");
            if (!ModelState.IsValid)
            {
                obj.ListCategory = context.Categories.ToList();
                return View("Create", obj);
            }

            //lay id
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            obj.LectureId = user.Id;

            //add
            context.Courses.Add(obj);
            context.SaveChanges();

            //tro ve
            return RedirectToAction("Index", "Home");
        }
    }

}