﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IActionResult Index()
        {
           
            return View("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(WishList.Models.Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var selectedItem = _context.Items.FirstOrDefault(p => p.Id == Id);
            _context.Remove(selectedItem);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
