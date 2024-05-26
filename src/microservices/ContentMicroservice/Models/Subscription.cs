using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContentMicroservice.Models;

public class Subscription
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public int Price { get; set; } = 0;

    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}
