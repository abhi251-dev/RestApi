using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movierestapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movierestapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class moviecontroller : ControllerBase
    {
      

        [HttpGet]
        public IEnumerable<Actor> Get()
        {
            using (var context = new MOVIEContext())
            {
                // return context.Actors.ToList();


                /*for returning a list of any actor by id
               return context.Actors.Where(mov => mov.ActId == 303).ToList();*/

                /*for adding a new actor in actors table 

                Actor act = new Actor();
                act.ActId = 311;
                act.ActName = "abhinav";

                     context.Actors.Add(act);
                context.SaveChanges();
                return context.Actors.ToList();*/

                // return context.Actors.Where(mov => mov.ActId == 311).ToList();

                /*for updating the value of name abhinav to pathak
                Actor act = context.Actors.Where(mov => mov.ActName == "abhinav").FirstOrDefault();
                act.ActName = "Pathak";
                context.SaveChanges();*/

               // return context.Actors.ToList();
              
                
                
                
                //now trying to delete (remove) one value from table actor
                Actor act = context.Actors.Where(mov => mov.ActName == "Pathak").FirstOrDefault();
               context.Actors.Remove(act);

                context.SaveChanges();

                return context.Actors.ToList();


            }
        }
    }
}
