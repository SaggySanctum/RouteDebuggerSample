using Microsoft.AspNet.Mvc;
using System;

namespace Sample
{
   
    [Area("Inventory")]
    public class MakeController : Controller
    {
        public ActionResult Model(int id)
        {
            return View("Model");
        }
    }
}