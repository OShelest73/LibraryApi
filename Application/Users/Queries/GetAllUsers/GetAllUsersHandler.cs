using Application.Dtos.User;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly IUserRepository _user;
    private readonly IMapper _mapper;

    public GetAllUsersHandler(IUserRepository user, IMapper mapper)
    {
        _user = user;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _user.GetAllUsers();
        //mapper for mapper's sake
        var usersDto = _mapper.Map<List<User>, List<UserDto>>(users);

        return usersDto;
    }
}
