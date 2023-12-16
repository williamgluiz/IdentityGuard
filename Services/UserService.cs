using AutoMapper;
using IdentityGuard.Data.DTO.Login;
using IdentityGuard.Data.DTO.User;
using IdentityGuard.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityGuard.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Register(CreateUserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            var result = await _userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
                throw new ApplicationException("Operation failed!");
        }

        internal async Task<string> Login(LoginUserDTO loginUserDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUserDTO.Username, loginUserDTO.Password, false, false);

            if (!result.Succeeded)
                throw new ApplicationException("Unauthenticated!");

            var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == loginUserDTO.Username.ToUpper());

            var token = _tokenService.GenerateToken(user);

            return token;
        }
    }
}
