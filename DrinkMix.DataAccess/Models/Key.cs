using System;
using System.Collections;
using System.Collections.Generic;

namespace DrinkMix.DataAccess.Models;

public partial class Key
{
    public string Id { get; set; } = null!;

    public int Version { get; set; }

    public DateTime Created { get; set; }

    public string? Use { get; set; }

    public string Algorithm { get; set; } = null!;

    public BitArray IsX509certificate { get; set; } = null!;

    public BitArray DataProtected { get; set; } = null!;

    public string Data { get; set; } = null!;
}
