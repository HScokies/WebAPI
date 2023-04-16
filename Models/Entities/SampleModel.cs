using System.ComponentModel.DataAnnotations;
namespace WebAPI.Models.Entities
{
    public class SampleModel
    {
       [Key]
       public int id {get; set;}
       public string modelName {get; set;} = null!;
       public string modelDescription {get; set;} = null!;
    }
}