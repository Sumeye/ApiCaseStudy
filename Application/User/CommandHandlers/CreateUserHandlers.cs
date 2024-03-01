using Application.User.Command;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.User.CommandHandlers
{
    public class CreateUserHandlers : IRequestHandler<CreateUser, Users>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandlers(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Users> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            Users mappedUser=_mapper.Map<Users>(request);
            Users createdUser = await _userRepository.AddAsync(mappedUser);
            return createdUser;
        }
    }
}
