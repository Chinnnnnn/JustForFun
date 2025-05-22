using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ForFun.Api;

public partial class OwnDevContext : DbContext
{
    //private string _connStr = "";
    public OwnDevContext()
    {
    }

    public OwnDevContext(DbContextOptions<OwnDevContext> options)
        : base(options)
    {
    }

    //public OwnDevContext(string connStr) => _connStr = connStr;

    public virtual DbSet<Hexagram> Hexagrams { get; set; }

    public virtual DbSet<Hexagramyao> Hexagramyaos { get; set; }

    public virtual DbSet<Trigram> Trigrams { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySQL(_connStr);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hexagram>(entity =>
        {
            entity.HasKey(e => e.NumKey).HasName("PRIMARY");

            entity.ToTable("hexagrams");

            entity.Property(e => e.NumKey)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.AbbrEn).HasMaxLength(10);
            entity.Property(e => e.AbbrZh)
                .HasMaxLength(2)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Bottom)
                .HasDefaultValueSql("'-1'")
                .HasComment("下爻");
            entity.Property(e => e.DescEn).HasMaxLength(255);
            entity.Property(e => e.DescZh)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.MeaningEn).HasMaxLength(255);
            entity.Property(e => e.MeaningZh)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NameEn).HasMaxLength(20);
            entity.Property(e => e.NameZh)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Up)
                .HasDefaultValueSql("'-1'")
                .HasComment("上爻");
        });

        modelBuilder.Entity<Hexagramyao>(entity =>
        {
            entity.HasKey(e => new { e.NumKey, e.Sort }).HasName("PRIMARY");

            entity.ToTable("hexagramyaos");

            entity.Property(e => e.NumKey)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.DescEn).HasMaxLength(255);
            entity.Property(e => e.DescZh).HasMaxLength(255);
            entity.Property(e => e.Figure).HasComment("陰/陽");
        });

        modelBuilder.Entity<Trigram>(entity =>
        {
            entity.HasKey(e => e.NumKey).HasName("PRIMARY");

            entity.ToTable("trigrams");

            entity.Property(e => e.NumKey)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.AnimalEn)
                .HasMaxLength(10)
                .HasComment("動物");
            entity.Property(e => e.AnimalZh)
                .HasMaxLength(1)
                .HasComment("動物");
            entity.Property(e => e.BodyPartEn)
                .HasMaxLength(10)
                .HasComment("身體部位");
            entity.Property(e => e.BodyPartZh)
                .HasMaxLength(1)
                .HasComment("身體部位");
            entity.Property(e => e.DirEarlierEn)
                .HasMaxLength(10)
                .HasComment("先天八卦方位");
            entity.Property(e => e.DirEarlierZh)
                .HasMaxLength(2)
                .HasComment("先天八卦方位");
            entity.Property(e => e.DirLaterEn)
                .HasMaxLength(10)
                .HasComment("後天八卦方位");
            entity.Property(e => e.DirLaterZh)
                .HasMaxLength(2)
                .HasComment("後天八卦方位");
            entity.Property(e => e.FamilyEn)
                .HasMaxLength(15)
                .HasComment("家族關係");
            entity.Property(e => e.FamilyZh)
                .HasMaxLength(2)
                .HasComment("家族關係");
            entity.Property(e => e.FigureL).HasComment("上爻");
            entity.Property(e => e.FigureM).HasComment("中爻");
            entity.Property(e => e.FigureU).HasComment("下爻");
            entity.Property(e => e.NameEn).HasMaxLength(10);
            entity.Property(e => e.NameZh).HasMaxLength(1);
            entity.Property(e => e.NatureEn)
                .HasMaxLength(10)
                .HasComment("自然象徵");
            entity.Property(e => e.NatureZh)
                .HasMaxLength(1)
                .HasComment("自然象徵");
            entity.Property(e => e.Num).HasComment("2進位換算10進位");
            entity.Property(e => e.OrganEn)
                .HasMaxLength(10)
                .HasComment("器官");
            entity.Property(e => e.OrganZh)
                .HasMaxLength(1)
                .HasComment("器官");
            entity.Property(e => e.PhaseEn)
                .HasMaxLength(10)
                .HasComment("五行");
            entity.Property(e => e.PhaseZh)
                .HasMaxLength(1)
                .HasComment("五行");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
