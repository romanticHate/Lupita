using System;
using System.Collections.Generic;

namespace EvilCorp.Lupita.Core.Model;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }
}
