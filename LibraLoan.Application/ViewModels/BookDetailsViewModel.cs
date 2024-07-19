using LibraLoan.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Application.ViewModels
{
    public class BookDetailsViewModel
    {
        public BookDetailsViewModel(int id, string title, string author, BooksStatusEnum status, string isbn, string publishedYear, string? clientName, string? loanDate)
        {
            Id = id;
            Title = title;
            Author = author;
            Status = status;
            ISBN = isbn;
            PublishedYear = publishedYear;
            ClientName = clientName;
            LoanDate = loanDate;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public BooksStatusEnum Status { get; private set; }
        public string ISBN { get; private set; }
        public string PublishedYear { get; private set; }
        public string? ClientName { get; private set; }
        public string? LoanDate { get; private set; }
    }
}
