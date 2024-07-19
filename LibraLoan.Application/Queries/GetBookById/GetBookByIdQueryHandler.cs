using LibraLoan.Application.ViewModels;
using LibraLoan.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Application.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDetailsViewModel>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDetailsViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetByIdAsync(request.Id);

            if (books == null) return null;

           return new BookDetailsViewModel(
                books.Id,
                books.Title,
                books.Author,
                books.Status,
                books.ISBN,
                books.PublishedYear,
                books.Client?.Name,
                books.LoanDate.ToString("dd/MM/yyyy HH:mm:ss")
                
                );
        }
    }
}
