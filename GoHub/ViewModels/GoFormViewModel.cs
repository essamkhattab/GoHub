using GoHub.Controllers;
using GoHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace GoHub.ViewModels
{
    public class GoFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public String Venue { get; set; }

        [Required]
        [FutureDate]
        public String Date { get; set; }

        [Required]
        [ValidTime]
        public String Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {  
                Expression<Func<GosController, ActionResult >> update =
                    (c => c.Update(this));

                Expression<Func<GosController, ActionResult >> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;


            }

        }

       

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
            //return DateTime.Parse(string.Format("{0} {1}", Date, Time));

        }
    }
}


