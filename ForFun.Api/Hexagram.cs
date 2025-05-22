using System;
using System.Collections.Generic;

namespace ForFun.Api;

public partial class Hexagram
{
    public string NumKey { get; set; } = null!;

    public string NameZh { get; set; } = null!;

    public string AbbrZh { get; set; } = null!;

    public string? NameEn { get; set; }

    public string? AbbrEn { get; set; }

    public int? Sort { get; set; }

    /// <summary>
    /// 上爻
    /// </summary>
    public int Up { get; set; }

    /// <summary>
    /// 下爻
    /// </summary>
    public int Bottom { get; set; }

    public string MeaningZh { get; set; } = null!;

    public string? MeaningEn { get; set; }

    public string DescZh { get; set; } = null!;

    public string? DescEn { get; set; }
}
