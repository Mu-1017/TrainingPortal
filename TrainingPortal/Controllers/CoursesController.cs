﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingPortal.Models;

namespace TrainingPortal.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly TrainingDataContext _context;

        public CoursesController(TrainingDataContext context)
        {
            _context = context;
        }

        // GET: Courses
        [AllowAnonymous]
        public async Task<IActionResult> Index(long? id)
        {
         if (id == null)
            {
                return NotFound();
            }

            ViewBag.Category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);

            List<Course> model = await _context.Course?.Where(x => x.CategoryId == id)?.ToListAsync();
            return base.View(model);
        }

        // GET: Courses/Create
        public IActionResult Create(long id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            ViewBag.Category = category;
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Key,Title,Author,Source,CategoryId,Description,Posted")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = course.CategoryId });
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CourseId,Title,Author,Source,CategoryId,Description,Posted")] Course course)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Index), new { id = course.CategoryId });
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = course.CategoryId });
        }

        private bool CourseExists(long id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }
    }
}
