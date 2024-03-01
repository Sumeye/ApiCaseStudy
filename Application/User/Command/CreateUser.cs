using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Command
{
    public class CreateUser : IRequest<Users>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
