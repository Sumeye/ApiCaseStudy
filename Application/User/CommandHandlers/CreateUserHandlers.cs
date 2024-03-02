using Application.Dto;
using Application.User.Command;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.User.CommandHandlers
{
    public class CreateUserHandlers : IRequestHandler<CreateUser, UserApp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandlers(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserApp> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            UserApp mappedUser=_mapper.Map<UserApp>(request);
            UserApp createdUser = await _userRepository.CreateUserAsync(mappedUser);
            return createdUser;
        }
    }
}
