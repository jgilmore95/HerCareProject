 using System;
 using System.Collections.Generic;
 using System.Diagnostics;
 using System.Linq;
 using System.Threading.Tasks;
 using Microsoft.AspNetCore.Mvc;
using her_care.Models;
 namespace her_care.Controllers {
 public class MonetaryController : Controller
    {
       public ActionResult Index()
        {            
            return View();
        }
 
        [HttpGet] 
        public ActionResult Create() 
        { 
            return View(); 
        } 

        [HttpPost] 
        public ActionResult Create(int[] departments) 
        { 
            return View(); 
        } 
    }
 }
 