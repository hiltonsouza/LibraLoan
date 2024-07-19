using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Application.Commands.LoanBook
{
    public class LoanBookCommand : IRequest<Unit>
    {
        public LoanBookCommand(int bookId, int userId)
        {
            BookId = bookId;
            UserId = userId;
        }

        public int BookId { get; private set; }
        public int UserId { get; private set; } 
    }
}
