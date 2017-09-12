﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using studreg_test.Models;

namespace studreg_test.Views
{
    public class CoursesController : Controller
    {
        private studregModel db = new studregModel();

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Available).Include(c => c.ClassTime).Include(c => c.Professor);
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Available, "CourseId", "CourseId");
            ViewBag.CourseId = new SelectList(db.ClassTime, "CourseId", "CourseId");
            ViewBag.CourseId = new SelectList(db.Professor, "ProfId", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,ProfId,CourseName,Credits,Description")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Available, "CourseId", "CourseId", courses.CourseId);
            ViewBag.CourseId = new SelectList(db.ClassTime, "CourseId", "CourseId", courses.CourseId);
            ViewBag.CourseId = new SelectList(db.Professor, "ProfId", "Name", courses.CourseId);
            return View(courses);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Available, "CourseId", "CourseId", courses.CourseId);
            ViewBag.CourseId = new SelectList(db.ClassTime, "CourseId", "CourseId", courses.CourseId);
            ViewBag.CourseId = new SelectList(db.Professor, "ProfId", "Name", courses.CourseId);
            return View(courses);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,ProfId,CourseName,Credits,Description")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Available, "CourseId", "CourseId", courses.CourseId);
            ViewBag.CourseId = new SelectList(db.ClassTime, "CourseId", "CourseId", courses.CourseId);
            ViewBag.CourseId = new SelectList(db.Professor, "ProfId", "Name", courses.CourseId);
            return View(courses);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Courses courses = db.Courses.Find(id);
            db.Courses.Remove(courses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
