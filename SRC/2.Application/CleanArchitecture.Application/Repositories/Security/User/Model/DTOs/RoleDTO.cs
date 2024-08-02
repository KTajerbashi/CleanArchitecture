using CleanArchitecture.Application.BaseApplication.Models.DTOs;

namespace CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;

public class RoleDTO : ModelDTO
{
    public string Name { get; set; }
    public string Key { get; set; }
    public long Id { get; set; }

}
