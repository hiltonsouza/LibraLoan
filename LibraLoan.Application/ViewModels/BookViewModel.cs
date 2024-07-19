using LibraLoan.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Application.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, string iSBN, string publishedYear, BooksStatusEnum status)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublishedYear = publishedYear;
            Status = status;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public string PublishedYear { get; private set; }
        public BooksStatusEnum Status { get; private set; }
    }
}
