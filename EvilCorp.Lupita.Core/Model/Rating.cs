using System;
using System.Collections.Generic;

namespace EvilCorp.Lupita.Core.Model;

public partial class Rating
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Value { get; set; }
}
