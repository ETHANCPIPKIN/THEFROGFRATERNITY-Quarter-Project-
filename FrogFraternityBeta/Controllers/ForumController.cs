using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrogFraternityBeta.Data;
using Microsoft.EntityFrameworkCore; 

namespace FrogFraternityBeta.Controllers
{
    public class ForumController : Controller
    {

        private readonly ForumContext _context;
        public ForumController(ForumContext context)
        {
            _context = context; 
        }
        // GET: ForumController

        public async Task<ActionResult> Index()
        {
            return View(await _context.Posts.ToListAsync());
        }

        // GET: ForumController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ForumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ForumController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ForumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ForumController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ForumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
