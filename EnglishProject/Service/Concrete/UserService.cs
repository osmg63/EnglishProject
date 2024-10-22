using AutoMapper;
using EnglishProject.Core.Repository.Abstract;
using EnglishProject.Data.DTOs;
using EnglishProject.Data.Entities;
using EnglishProject.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EnglishProject.Service.Concrete
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ConfigJwt _configJwt;

        public UserService(IUserRepository repository, IMapper mapper, IOptions<ConfigJwt> options)
        {
            _mapper = mapper;
            _repository = repository;
            _configJwt = options.Value;
        }

        public void AddUser(PostUserDto user)
        {
            var data = _mapper.Map<User>(user);
            data.Role = "Standart";
            _repository.Add(data);
        }
        public User KimlikDenetimi(UserLoginDto test)
        {
            var user = _repository.Get(x => x.Username == test.Username);

            if (user != null)
            {
                if (user.Password == test.Password)
                {
                    return user;
                }
            }

            return null;
        }
        public object Login(UserLoginDto userEntity)
        {
            var apiKullanici = KimlikDenetimi(userEntity);
            if (userEntity == null) return null;
            var token = TokenGenerator(apiKullanici);
            return token;

        }
        private object TokenGenerator(User apiKullanici)
        {
            if (_configJwt.Key == null)  throw new ArgumentNullException("Key değeri null olmaz");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configJwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimDizisi = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, apiKullanici.Username),
                new Claim(ClaimTypes.Role, apiKullanici.Role),
            };
            var token = new JwtSecurityToken(_configJwt.Issuer, _configJwt.Audience, claimDizisi,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }





        public void DeleteUser(PostUserDto user)
        {
            var data = _mapper.Map<User>(user);

            _repository.Delete(data);
        }
        public List<GetUserDto> GetAllUsers() {
            var data = _repository.GetAll();
            var a = _mapper.Map<List<GetUserDto>>(data);
            return a;
        }
        public GetUserDto GetUserById(int id)
        {
            var data = _repository.Get(x => x.Id == id);
            return _mapper.Map<GetUserDto>(data);
        }
        public GetUserDto GetUserByUserName(string Username)
        {
            var data = _repository.Get(x => x.Username == Username);
            return _mapper.Map<GetUserDto>(data);
        }





    }
}
