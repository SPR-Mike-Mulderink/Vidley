﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using Vidley.ViewModels;

namespace Vidley.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer1"},
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //Old ViewData Approach vvv
            //ViewData["Movie"] = movie;

            return View(viewModel);

            //Examples vvv
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" });
        }
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult IndexRandom(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        public ActionResult Index()
        {
            List<Movie> movies = null;
            movies = new List<Movie>
            {
                new Movie { Name = "007" },
                new Movie { Name = "Die Hard" },
                new Movie { Name = "Star Wars" }
            };
            //movies = null;

            if (movies == null)
            {
                var nullMovies = new List<Movie>
                {
                    new Movie { Name = "We don't have any Movies yet."}
                };

                var nullViewModel = new MoviesViewModel
                {
                    Movies = nullMovies
                };

                return View(nullViewModel);
            } 
            else
            {
                var moviesViewModel = new MoviesViewModel
                {
                    Movies = movies
                };

                return View(moviesViewModel);
            }
        }
    }
}