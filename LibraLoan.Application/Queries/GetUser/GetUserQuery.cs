﻿using LibraLoan.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
