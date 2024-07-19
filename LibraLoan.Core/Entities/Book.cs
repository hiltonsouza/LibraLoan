using LibraLoan.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string iSBN, string publishedYear)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublishedYear = publishedYear;
            Status = BooksStatusEnum.Available;
        }

        public string Title { get; private set; }
        public string Author {  get; private set; }
        public string ISBN { get; private set; }
        public BooksStatusEnum Status { get; private set; }
        public string PublishedYear { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReceiveDate { get; private set; }
        public int? UserId { get; private set; }
        public User Client { get; private set; }

        public void Loan(int idClient)
        {
            if (Status == BooksStatusEnum.Available)
            {
                Status = BooksStatusEnum.CheckedOut;
                LoanDate = DateTime.Now;
                UserId = idClient;
            }
        }

        public void Receive()
        {
            if(Status == BooksStatusEnum.CheckedOut && UserId != 0)
            {
                Status = BooksStatusEnum.Available;
                ReceiveDate = DateTime.Now;
                UserId = null;
            }
        }
        public bool Delete()
        {
            if(Status == BooksStatusEnum.Available && !UserId.HasValue)
                return true;

            return false;
        }
    }
}
