using System.ComponentModel.DataAnnotations;

namespace ListWebsite.Models;

public class ToDo
{
    public int Id { get; set; }

    [Required(ErrorMessage="This field is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage="The Text must be between 3-20 characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage="This field is required")]
    public string? Type { get; set; }

    [Required(ErrorMessage="This field is required")]
    [Range(0, 10, ErrorMessage="The Priority must be between 1-10")]
    public decimal? Priority { get; set; }

    [Required(ErrorMessage="This field is required")]
    [ValidateDate(ErrorMessage="The Date can not be in the past")]
    public DateTime DueDate { get; set; }
}