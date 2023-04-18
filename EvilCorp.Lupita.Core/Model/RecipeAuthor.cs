using System;
using System.Collections.Generic;

namespace EvilCorp.Lupita.Core.Model;

public partial class RecipeAuthor
{
    public int RecipeId { get; set; }

    public int AuthorId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
