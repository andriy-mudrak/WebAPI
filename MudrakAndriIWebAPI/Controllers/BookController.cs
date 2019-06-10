using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MudrakAndriIWebAPI.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class BookController: Controller
    {
        private IBookService iBookService;

        public BookController( IBookService iBookService )
        {
            this.iBookService = iBookService;
        }


        /// <summary>
        /// Load information about all books
        /// </summary>
        /// <returns>Information about all books</returns>
        /// <response code="200">Returns information about all books</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about books is null</response>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        [ProducesResponseType( typeof( Exception ), StatusCodes.Status400BadRequest )]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<BookDTO> books = iBookService.GetAllBooks();

                if ( books == null )
                    return NotFound();

                return StatusCode( 200, books );
            }
            catch ( Exception e )
            {
                return BadRequest( e );
            }
        }


        /// <summary>
        /// Load information about specific book
        /// </summary>
        /// <param name="bookId">book id for searching </param>
        /// <returns>Information about specific book</returns>
        /// <response code="200">Returns information about specific book</response>
        /// <response code="400">If url which you are sending is not valid</response>
        /// <response code="404">If the information about book is null</response>
        [HttpGet( "{bookId}" )]
        [Produces( "application/json" )]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        [ProducesResponseType( typeof( Exception ), StatusCodes.Status400BadRequest )]
        public IActionResult Get( int bookId )
        {
            try
            {
                BookDTO book = iBookService.GetBook( bookId );

                if ( book == null )
                    return NotFound();

                return StatusCode( 200, book );
            }
            catch ( Exception e )
            {
                return BadRequest( e );
            }
        }


        /// <summary>
        /// Post information about specific book
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Create
        ///     {
        ///        "title": "Harry Potter",
        ///        "author": "J. K. Rowling",
        ///     }
        ///
        /// </remarks>
        /// <param name="book">Object of book for publication</param>
        /// <response code="200">The POST request has been successfully processed</response>
        /// <response code="400">If url which you are sending is not valid</response>
        [HttpPost]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( typeof( Exception ), StatusCodes.Status400BadRequest )]
        public IActionResult Create( [FromBody] BookDTO book )
        {
            try
            {
                iBookService.CreateBook( book );
                return StatusCode( 200 );
            }
            catch ( Exception e )
            {
                return BadRequest( e );
            }
        }

        /// <summary>
        /// Put information about specific book
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///   
        ///     PUT /Update
        ///     {
        ///        "id":"1"    
        ///        "title": "New Harry Potter",
        ///        "author": "New J. K. Rowling",
        ///     }
        /// Where "id" already exists 
        /// </remarks>
        /// <param name="book">Object of book for updating</param>
        /// <response code="200">The PUT request has been successfully processed</response>
        /// <response code="400">If url which you are sending is not valid</response>
        [HttpPut]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( typeof( Exception ), StatusCodes.Status400BadRequest )]
        public IActionResult Update( [FromBody] BookDTO book )
        {
            try
            {
                iBookService.UpdateBook( book );
                return StatusCode( 200 );
            }
            catch ( Exception e )
            {
                return BadRequest( e );
            }
        }

        /// <summary>
        /// Delete information about specific book
        /// </summary>
        /// <param name="bookId">book id for deleting</param>
        /// <response code="200">The DELETE request has been successfully processed</response>
        /// <response code="400">If url which you are sending is not valid</response>
        [HttpDelete( "{bookId}" )]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( typeof( Exception ), StatusCodes.Status400BadRequest )]
        public IActionResult Delete( int bookId )
        {
            try
            {
                iBookService.DeleteBook( bookId );
                return StatusCode( 200 );
            }
            catch ( Exception e )
            {
                return BadRequest( e );
            }
        }
    }

}