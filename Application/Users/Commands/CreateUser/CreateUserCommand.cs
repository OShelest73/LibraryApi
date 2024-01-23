using Application.Dtos.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(RegisterDto RegisterDto) : IRequest;
