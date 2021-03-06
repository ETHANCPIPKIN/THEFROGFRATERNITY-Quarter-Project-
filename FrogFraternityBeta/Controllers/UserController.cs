using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrogFraternityBeta.Data;
using FrogFraternityBeta.Models;
using Microsoft.AspNetCore.Http;

namespace FrogFraternityBeta.Controllers
{

    //UserController controls user creation, edits, kand other functions for users

    public class UserController : Controller
    {

        //This gives us access to the sql Database
        private readonly ForumContext _context;

        public UserController(ForumContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }
       
        // GET: User/Details/5
        // User details is more for the owner of the account than other people, it lets
        // them preview / links to edit their information and profile on the forum 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: USER/LOGIN
        // Login checks to make sure that a user isn't already in a session
        // before sending them to the login page
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("UserId").HasValue)
            {
                return RedirectToAction("Index", "Forum");
            }
            return View();
        }


        // POST: user/login
        // when the user logs in with a matching account, variables are set
        // in the session to coordinate with the rest of the site 
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            User acct = await _context
                .Users
                .Where(s => s.UserName == model.Username)
                .SingleOrDefaultAsync();
            if (acct == null)
            {
                return View(model);
            }

            HttpContext.Session.SetString("Username", acct.UserName);
            HttpContext.Session.SetString("color", acct.fontColor);
            HttpContext.Session.SetInt32("UserId", acct.UserId);

            return RedirectToAction("Index", "Forum");

        }

        // GET: User/Register
        public IActionResult Register()
        {
            return View();
        }
        // POST: User/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel reg)
        {
            if (ModelState.IsValid)
            {
                User User = new User()
                {
                    Email = reg.Email,
                    Password = reg.Password,
                    UserName = reg.Username,
                    fontColor = "#FFFFFF",
                };
                _context.Users.Add(User);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return View(reg);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Email,UserName,Password,fontColor,profilePic")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);

                    HttpContext.Session.SetString("Username", user.UserName);
                    HttpContext.Session.SetString("color", user.fontColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Forum");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
