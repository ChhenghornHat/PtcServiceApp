using System.ComponentModel.DataAnnotations;

namespace PtcServiceApp.Models;

public class Role
{
    [Key]
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public bool Active { get; set; }
    public string CreatedDate { get; set; }
    public string UpdatedDate { get; set; }
}

public class PostRole
{
    public string RoleName { get; set; }
    public int Active { get; set; }
}

public class GetUserRoleById
{
    [Key]
    public int RoleId { get; set; }
    public string RoleName { get; set; }
}

public class PostUpdateRole
{
    [Key]
    public int RoleId { get; set; }
    public string RoleName { get; set; }
}

public class EditRoleActive
{
    [Key]
    public int RoleId { get; set; }
    public int Active { get; set; }
}