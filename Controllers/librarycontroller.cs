using libraryrestapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.SqlServer;



namespace libraryrestapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class librarycontroller : ControllerBase
    {
       [HttpGet]
        public IEnumerable<Book> Get()

        {
            using (var context = new LibraryContext())
            {
                //to get list of all the employees

                //return context.Books.ToList();

                // to get a list of employees by id 

                // return context.Books.Where(auth => auth.BookId == 5).ToList();
                //for adding some date in books table
                //  Book book = new Book();
                //  book.BookId = 9;
                //  book.Title = "IndianEconomy";

                //  context.Books.Add(book);
                //  context.SaveChanges();

                // return context.Books.ToList();


                //
                //return context.Books.Where(auth => auth.Title == "IndianEconomy").ToList();

                //to update any itens in the table
                //   Book book = context.Books.Where(auth => auth.Title == "IndianEconomy").FirstOrDefault();
                // book.PubYear = 2017;

                //context.SaveChanges();

                //remove any book item
                Book book = context.Books.Where(auth => auth.Title == "IndianEconomy").FirstOrDefault();
                context.Books.Remove(book);
                context.SaveChanges();



                return context.Books.Where(auth => auth.Title == "IndianEconomy").ToList();

            }
        }
    }
}
