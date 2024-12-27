using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapiASP.Models;

public class Prices
{
    [Key]
    public long PricesId { get; set; }

    public long ProgramCode { get; set; }
    public string ProgramName { get; set; }
    public double MinutePrice { get; set; }
    [JsonIgnore]
    public ICollection<RegistrationProgram>? registrationPrograms { get; set; }
}