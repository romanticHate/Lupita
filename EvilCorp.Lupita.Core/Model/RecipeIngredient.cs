using System;
using System.Collections.Generic;

namespace EvilCorp.Lupita.Core.Model;

public partial class RecipeIngredient
{
    public int RecipeId { get; set; }

    public int IngredientId { get; set; }

    public int? MeasureId { get; set; }

    public decimal? Amount { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Measure? Measure { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;
}
