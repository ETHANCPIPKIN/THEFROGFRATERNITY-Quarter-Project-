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
            try
            {
                if (ModelState.IsValid)
                {
                    Post post1 = new Post()
                    {
                        Username = "Guest",
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
            catch
            {
                return View();
            }
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
                    Username = "Guest",
                    Title = p.Title,
                    Content = p.Content,
                    PostTime = DateTime.Now
                };
                _context.Update(p);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(p); 
            }

        // GET: ForumController/Delete/5
        public IActionResult Delete(int id)
        {
            Post p = _context
                .Posts
                .Where(s => s.PostId == id)
                .SingleOrDefault();

            return View(p);
        }

        // POST: ForumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            // TODO: Ensure the username of the person trying to delete is the username of the creator of the post
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
