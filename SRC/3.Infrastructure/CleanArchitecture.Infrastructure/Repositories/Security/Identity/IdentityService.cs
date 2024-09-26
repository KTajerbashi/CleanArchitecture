using CleanArchitecture.Application.Providers.MapperProvider.Abstract;
using CleanArchitecture.Application.Repositories.Identity;
using CleanArchitecture.Application.Repositories.Identity.Models.DTOs;
using CleanArchitecture.Application.Repositories.Identity.Models.Responses;
using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;
using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static CleanArchitecture.Application.Repositories.Identity.Models.Responses.ServiceResponse;

namespace CleanArchitecture.Infrastructure.Repositories.Security.Identity;

public class IdentityService(
    UserManager<UserEntity> userManager,
    RoleManager<RoleEntity> roleManager,
    SignInManager<UserEntity> signInManager,
    IMapperAdapter mapperAdapter,
    CleanArchitectureDb context,
    IConfiguration configuration
    ) : IIdentityService
{
    public Task<GeneralResponse> FindUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<GeneralResponse> FindUserById(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<GeneralResponse> FindUserByUsername(string userName)
    {
        throw new NotImplementedException();
    }

    public List<RoleDTO> GetUserRoles(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse.LoginResponse> LoginAccount(LoginDTO model)
    {
        if (model == null)
            return new LoginResponse(false, null!, "Login container is empty");

        var getUser = await userManager.FindByNameAsync(model.UserName);
        if (getUser is null)
            return new LoginResponse(false, null!, "User not found");

        bool checkUserPasswords = await userManager.CheckPasswordAsync(getUser, model.Password);
        if (!checkUserPasswords)
            return new LoginResponse(false, null!, "Invalid email/password");
        var checkLogin = await signInManager.PasswordSignInAsync(getUser,model.Password,model.IsRemember,true);
        if (!checkLogin.Succeeded)
            return new LoginResponse(false, null!, "Invalid account");
        var getUserRole = await userManager.GetRolesAsync(getUser);

        var userSessionRoles = new UserSessionWithRoles(getUser.Id, getUser.UserName, getUser.Email, getUserRole.ToList());
        var userSession = new UserSession(getUser.Id, getUser.UserName, getUser.Email, getUserRole.First());

        string tokenRoles = GenerateTokenRoles(userSessionRoles);
        string token = GenerateToken(userSession);
        string result = $"[{token}],[{tokenRoles}]";
        return new LoginResponse(true, result!, "Login completed");
    }

    public Task<GeneralResponse> PasswordSignInAsync(UserDTO entity, string password, bool isRemember, bool failLockOutEnd)
    {
        throw new NotImplementedException();
    }

    public Task<GeneralResponse> ReadProfile(long userRoleId)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse.GeneralResponse> Register(RegisterDTO model)
    {
        if (model is null) return new GeneralResponse(false, "Model is empty");
        var newUser = new UserEntity()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PasswordHash = model.Password,
            UserName = model.Email,
            AvatarFile = model.AvatarFile,
            SignFile = model.SignFile,
            NationalCode = model.NationalCode,
        };
        var user = await userManager.FindByEmailAsync(newUser.Email);
        if (user is not null) return new GeneralResponse(false, "User registered already");

        var createUser = await userManager.CreateAsync(newUser!, model.Password);
        if (!createUser.Succeeded) return new GeneralResponse(false, "Error occurred.. please try again");

        //Assign Default Role : Admin to first registrar; rest is user
        var checkAdmin = await roleManager.FindByNameAsync("Admin");
        if (checkAdmin is null)
        {
            await roleManager.CreateAsync(new RoleEntity() { Name = "Admin" });
            await userManager.AddToRoleAsync(newUser, "Admin");
            return new GeneralResponse(true, "Account Created");
        }
        else
        {
            var checkUser = await roleManager.FindByNameAsync("User");
            if (checkUser is null)
                await roleManager.CreateAsync(new RoleEntity() { Name = "User", Key = Guid.NewGuid(), Title = "کاربر" });

            await userManager.AddToRoleAsync(newUser, "User");
            return new GeneralResponse(true, "Account Created");
        }
    }

    public Task SignOut()
    {
        return Task.FromResult(signInManager.SignOutAsync());
    }

    private string GenerateToken(UserSession user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, $"{user.Id}"),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
        var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private string GenerateTokenRoles(UserSessionWithRoles user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var RoleClaims =new List<Claim>();
        foreach (var item in user.Roles)
        {
            RoleClaims.Add(new Claim(ClaimTypes.Role, item));
        }
        var userClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, $"{user.Id}"),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
        };
        userClaims.AddRange(RoleClaims);
        var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
#region Comment

//public IdentityResult CreateAsync(CreateUserDTO model)
//{
//    var entity = new UserEntity
//    {

//    };
//    return new IdentityResult
//    {

//    };
//}


//public UserDTO FindUserById(long userId)
//{
//    var entity = _userManager.FindByIdAsync(userId.ToString()).Result;
//    var result = _mapperAdapter.Map<UserEntity,UserDTO>(entity);
//    return result;
//}

//public UserDTO FindUserByUsername(string userName)
//{
//    var entity = _userManager.FindByIdAsync(userName).Result;
//    var result = _mapperAdapter.Map<UserEntity,UserDTO>(entity);
//    return result;
//}

//public List<RoleDTO> GetUserRoles(long id)
//{
//    var result = _context.Database.SqlQueryRaw<RoleDTO>(@"
//SELECT R.*
//FROM Security.UserRoles UR 
//INNER JOIN Security.Roles R ON UR.RoleId = R.Id
//WHERE UR.UserId = @Id
//",new {Id = id});
//    return result.ToList();
//}

//public SignInResult Login(LoginDTO model)
//{
//    var entity = _userManager.FindByNameAsync(model.UserName).Result;
//    if (entity is null)
//        return null;
//    var logged = _signInManager.PasswordSignInAsync(entity,model.Password,model.IsRemember,true);
//    return logged.Result;
//}

//public SignInResult PasswordSignInAsync(UserDTO entity, string password, bool isRemember, bool failLockOutEnd)
//{
//    var res = _userManager.FindByNameAsync(entity.UserName).Result;
//    if (res is null)
//        return null;
//    return _signInManager.PasswordSignInAsync(res, password, isRemember, true).Result;
//}

//public ProfileView ReadProfile(long userRoleId)
//{
//    throw new NotImplementedException();
//}

//public IdentityResult Register(RegisterDTO model)
//{
//    var entity = new UserEntity
//    {
//        FirstName = model.FirstName,
//        LastName = model.LastName,
//        Email = model.Email,
//        UserName = model.Email,
//        AvatarFile = model.AvatarFile,
//        SignFile = model.SignFile,
//        NationalCode = model.NationalCode,
//        Key = Guid.NewGuid()
//    };
//    var result = _userManager.CreateAsync(entity,model.Password);
//    return result.Result;
//}

//public void SignOut()
//{
//    _signInManager.SignOutAsync();
//}

//Task<ServiceResponse.GeneralResponse> FindUserByEmail(string email)
//{
//    var entity = _userManager.FindByEmailAsync(email).Result;
//    var result = _mapperAdapter.Map<UserEntity,UserDTO>(entity);

//}

//Task<ServiceResponse.GeneralResponse> IIdentityService.FindUserById(long userId)
//{
//    throw new NotImplementedException();
//}

//Task<ServiceResponse.GeneralResponse> IIdentityService.FindUserByUsername(string userName)
//{
//    throw new NotImplementedException();
//}

//Task<ServiceResponse.LoginResponse> IIdentityService.Login(LoginDTO model)
//{
//    throw new NotImplementedException();
//}

//Task<ServiceResponse.GeneralResponse> IIdentityService.PasswordSignInAsync(UserDTO entity, string password, bool isRemember, bool failLockOutEnd)
//{
//    throw new NotImplementedException();
//}

//Task<ServiceResponse.GeneralResponse> IIdentityService.ReadProfile(long userRoleId)
//{
//    throw new NotImplementedException();
//}

//Task<ServiceResponse.GeneralResponse> IIdentityService.Register(RegisterDTO model)
//{
//    throw new NotImplementedException();
//}

#endregion