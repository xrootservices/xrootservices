﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xRootServices.Data;
using xRootServices.Models;
using xRootServices.Models.ViewModels;

namespace xRootServices.Controllers
{
    public class Blogs : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly ApplicationDbContext _context;

        public Blogs(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Blogs
        //public async Task<IActionResult> Index()
        //{
        //    var posts = await _context.Blogs
        //        .Where(b => b.IsPublished)
        //        .OrderByDescending(b => b.DatePublished)
        //        .Select(b => new BlogListItemViewModel
        //        {
        //            Id = b.Id,
        //            Title = b.Title,
        //            Slug = b.Slug,
        //            CoverImageUrl = b.CoverImageUrl,
        //            DatePublished = b.DatePublished
        //        })
        //        .ToListAsync();

        //    return View(posts);
        //}
        [HttpGet("/blog/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return BadRequest();
            }

            var blog = await _context.Blogs
                .Include(b => b.Author) 
                .FirstOrDefaultAsync(b => b.slug == slug);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 12; // blogs per page

            var totalBlogs = await _context.Blogs.CountAsync();

            var blogs = await _context.Blogs
                .OrderByDescending(b => b.created_at)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new BlogListItemViewModel
                {
                    Id = b.Id,
                    Title = b.title,
                    Slug = b.slug,
                    CoverImageUrl = b.cover_image_url,
                    DatePublished = b.date_published
                })
                .ToListAsync();

            var viewModel = new BlogListViewModel
            {
                Blogs = blogs,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalBlogs / (double)pageSize)
            };

            return View(viewModel);
        }

    }
}
