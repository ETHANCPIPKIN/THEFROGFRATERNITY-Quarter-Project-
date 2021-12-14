using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrogFraternityBeta.Data;
using Microsoft.EntityFrameworkCore;
using FrogFraternityBeta.Models;

namespace FrogFraternityBeta.Controllers
{
    /*
    *
    *
    * ForumController controls the posts and the main index of the forum.  
    *
    */
    public class ForumController : Controller
    {
        // this gives us access to the sql database
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
            Post p = _context
                .Posts
                .Where(s => s.PostId == id)
                .SingleOrDefault();

            return View(p);
        }

        // GET: ForumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                Post post1 = new Post()
                {
                    Username = HttpContext.Session.GetString("Username"),
                    Title = post.Title,
                    Content = post.Content,
                    PostTime = DateTime.Now
                };
                _context.Add(post1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: ForumController/Edit/5
        public IActionResult Edit(int id)
        {
            Post p = _context
                .Posts
                .Where(s => s.PostId == id)
                .SingleOrDefault();

            return View(p);
        }

        // POST: ForumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Post p)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post()
                {
                    PostId = p.PostId,
                    Username = HttpContext.Session.GetString("Username"),
                    Title = p.Title,
                    Content = p.Content,
                    PostTime = DateTime.Now
                };
                _context.Update(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }

        // GET: ForumController/Delete/5
        public IActionResult Delete(int id)
        {
            // TODO: Ensure the username of the person trying to delete
            //         is the username of the creator of the post
            Post p = _context
                .Posts
                .Where(s => s.PostId == id)
                .SingleOrDefault();

            return View(p);
        }

        // TODO: ERROR OCCURS, LOOK UP LATER
        // POST: ForumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            Post p = _context
                .Posts
                .Where(s => s.PostId == id)
                .SingleOrDefault();

            _context.Remove(p);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}