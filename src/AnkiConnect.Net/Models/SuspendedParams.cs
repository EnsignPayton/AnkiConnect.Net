﻿namespace AnkiConnect.Net.Models;

public class SuspendedParams
{
    [JsonPropertyName("card")]
    public ulong Card { get; set; }
}
