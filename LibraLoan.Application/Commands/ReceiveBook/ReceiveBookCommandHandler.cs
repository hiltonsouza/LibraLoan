using LibraLoan.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Application.Commands.ReceiveBook
{
    public class ReceiveBookCommandHandler : IRequestHandler<ReceiveBookCommand, string>
    {
        private LibraLoanDbContext _libraLoanDbContext;

        public ReceiveBookCommandHandler(LibraLoanDbContext libraLoanDbContext)
        {
            _libraLoanDbContext = libraLoanDbContext;
        }

        public async Task<string> Handle(ReceiveBookCommand command, CancellationToken cancellationToken)
        {
            var book = _libraLoanDbContext.Books.SingleOrDefault(p => p.Id == command.Id);

            book.Receive();

            await  _libraLoanDbContext.SaveChangesAsync();

            DateTime dateTime = DateTime.Now;

            TimeSpan overDue = book.LoanDate.Subtract(dateTime);

            var message = overDue.TotalDays > 0 ? Resources.Messages.Overdue : Resources.Messages.BookOnTime;

            return message;
        }
    }
}
