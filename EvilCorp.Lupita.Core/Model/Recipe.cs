using System;
using System.Collections.Generic;

namespace EvilCorp.Lupita.Core.Model;

public partial class Recipe
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Instructions { get; set; } = null!;

    public string? Cuisine { get; set; }

    public string? Course { get; set; }

    public int? PrepTime { get; set; }

    public int? CookTime { get; set; }
}
