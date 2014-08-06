using Microsoft.AspNet.Mvc;
using System;

namespace Sample
{
    public class InventoryController : Controller
    {
        public ActionResult Car(int id)
        {
            return View("Car");
        }
    }
}