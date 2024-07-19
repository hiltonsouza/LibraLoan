using LibraLoan.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookViewModel>>
    {
        public GetAllBooksQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
