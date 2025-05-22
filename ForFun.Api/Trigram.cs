using System;
using System.Collections.Generic;

namespace ForFun.Api;

public partial class Trigram
{
    public string NumKey { get; set; } = null!;

    /// <summary>
    /// 2進位換算10進位
    /// </summary>
    public int? Num { get; set; }

    public string? NameZh { get; set; }

    public string? NameEn { get; set; }

    /// <summary>
    /// 下爻
    /// </summary>
    public int? FigureU { get; set; }

    /// <summary>
    /// 中爻
    /// </summary>
    public int? FigureM { get; set; }

    /// <summary>
    /// 上爻
    /// </summary>
    public int? FigureL { get; set; }

    /// <summary>
    /// 自然象徵
    /// </summary>
    public string? NatureZh { get; set; }

    /// <summary>
    /// 自然象徵
    /// </summary>
    public string? NatureEn { get; set; }

    /// <summary>
    /// 先天八卦方位
    /// </summary>
    public string? DirEarlierZh { get; set; }

    /// <summary>
    /// 先天八卦方位
    /// </summary>
    public string? DirEarlierEn { get; set; }

    /// <summary>
    /// 後天八卦方位
    /// </summary>
    public string? DirLaterZh { get; set; }

    /// <summary>
    /// 後天八卦方位
    /// </summary>
    public string? DirLaterEn { get; set; }

    /// <summary>
    /// 家族關係
    /// </summary>
    public string? FamilyZh { get; set; }

    /// <summary>
    /// 家族關係
    /// </summary>
    public string? FamilyEn { get; set; }

    /// <summary>
    /// 動物
    /// </summary>
    public string? AnimalZh { get; set; }

    /// <summary>
    /// 動物
    /// </summary>
    public string? AnimalEn { get; set; }

    /// <summary>
    /// 五行
    /// </summary>
    public string? PhaseZh { get; set; }

    /// <summary>
    /// 五行
    /// </summary>
    public string? PhaseEn { get; set; }

    /// <summary>
    /// 身體部位
    /// </summary>
    public string? BodyPartZh { get; set; }

    /// <summary>
    /// 身體部位
    /// </summary>
    public string? BodyPartEn { get; set; }

    /// <summary>
    /// 器官
    /// </summary>
    public string? OrganZh { get; set; }

    /// <summary>
    /// 器官
    /// </summary>
    public string OrganEn { get; set; } = null!;
}
