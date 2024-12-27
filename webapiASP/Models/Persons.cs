using System.ComponentModel.DataAnnotations;

namespace webapiASP.Models;

public class Persons
{
    [Key]
    public int PersonsId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    
}