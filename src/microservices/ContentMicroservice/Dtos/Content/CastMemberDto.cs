using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ContentMicroservice.Dtos.Content;

public class CastMemberDto
{
    public string EmployeeFullName { get; set; } = null!;
    public string RoleName { get; set; } = null!;
}