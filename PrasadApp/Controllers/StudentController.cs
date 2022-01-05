using PrasadApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrasadApp.Controllers
{
    public class StudentController : Controller
    {
        mvcDBEntities dbobj = new mvcDBEntities();
        // GET: Student
        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Table_1 model)
        {
            if(ModelState.IsValid)
            {
                Table_1 tbobj = new Table_1();               
                tbobj.Name = model.Name;
                tbobj.Email = model.Email;
                tbobj.Phone = model.Phone;
                tbobj.Address = model.Address;

                dbobj.Table_1.Add(tbobj);
                dbobj.SaveChanges();
            }
            ModelState.Clear();
            return View("Student");
        }

        public ActionResult StudentList()
        {
            var res = dbobj.Table_1.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbobj.Table_1.Where(x=>x.Id==id).First();
            dbobj.Table_1.Remove(res);
            dbobj.SaveChanges();
            var list = dbobj.Table_1.ToList();
            return View("StudentList", list);
        }
    }
}