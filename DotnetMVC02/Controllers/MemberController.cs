using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetMVC02.Models;

namespace DotnetMVC02.Controllers
{
    public class MemberController : Controller
    {
        static List<Member> member = new List<Member>()
        {
            new Member()
            {
                FirstName = "Anh",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(1997,1,17),
                PhoneNumber = "123456789",
                BirthPlace = "Ha Noi",
                IsGraduated = true,
                StartDate = new DateTime(2020,6,10),
                EndDate = new DateTime(2020,6,20)
            }
        };
            
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            
            return View(member);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member member)
        {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }
        return View(member);
        }
        //
        public IActionResult Edit(string firstName,string lastName){
            Member e = member.SingleOrDefault(x=> x.FirstName == firstName&&x.LastName == lastName);
            return View(e);
        }
        [HttpPost]
        public IActionResult Edit(Member e){
            Member a = member.SingleOrDefault(x=> x.FirstName == e.FirstName&&x.LastName == e.LastName);
            if(a!=null){
                a.FirstName=e.FirstName;
                a.LastName=e.LastName;
                a.DateOfBirth=e.DateOfBirth;
                a.Gender=e.Gender;
                a.PhoneNumber=e.PhoneNumber;
                a.BirthPlace=e.BirthPlace;
                return RedirectToAction("Index");
            }
            return View(e);
        }

        //

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}