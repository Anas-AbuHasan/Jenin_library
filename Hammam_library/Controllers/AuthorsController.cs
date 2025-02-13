﻿using Jenin_library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jenin_library.Controllers
{
    public class AuthorsController : Controller
    {
        private LibraryContext _context { get; set; }
        public AuthorsController(LibraryContext ctx) => _context = ctx;
        public IActionResult Index()
        {
            var authors = _context.Authors.ToList();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
            {
                return RedirectToAction("Index", "Authors");
            }
            ViewBag.Books = _context.Books.Where(book => book.AuthorID == id).OrderBy(book => book.BookID).ToList();
            return View(author);
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (HttpContext.Session.GetString("username") == null)
                return RedirectToAction("Login", "Users");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Authors author)
        {
            if (HttpContext.Session.GetString("username") == null)
                return RedirectToAction("Login", "Users");
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index", "Authors");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
                return RedirectToAction("Login", "Users");

            var author = _context.Authors.Find(id);
            if (author != null)
                return View(author);
            return RedirectToAction("Index", "Authors");
        }
        [HttpPost]
        public IActionResult Edit(Authors author)
        {
            if (HttpContext.Session.GetString("username") == null)
                return RedirectToAction("Login", "Users");

            _context.Authors.Update(author);
            _context.SaveChanges();
            return RedirectToAction("Index", "Authors");
        }

        [HttpGet]
        public IActionResult Search(string searchKey)
        {
            if (string.IsNullOrEmpty(searchKey))
            {
                return RedirectToAction("Index", "Authors");
            }
            var authors = _context.Authors.Where(author => author.AuthorName.Contains(searchKey)).OrderBy(author => author.AuthorID).ToList();
            return View("Index", authors);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
                return RedirectToAction("Login", "Users");
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Remove(author);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Authors");


        }
    }
}
