using System.ComponentModel.DataAnnotations;

namespace CorePlugin.Plugin.Dtos;

#warning This is just a sample. Replace it with your own.
public class SampleDto
{
    [Required] public string Description { get; set; } = null!;
}
