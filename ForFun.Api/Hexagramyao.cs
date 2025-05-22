using System;
using System.Collections.Generic;

namespace ForFun.Api;

public partial class Hexagramyao
{
    public string NumKey { get; set; } = null!;

    public int Sort { get; set; }

    /// <summary>
    /// 陰/陽
    /// </summary>
    public int? Figure { get; set; }

    public string? DescZh { get; set; }

    public string? DescEn { get; set; }
}
