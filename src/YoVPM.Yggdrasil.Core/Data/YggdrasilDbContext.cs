using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using YoVPM.Yggdrasil.Core.Models.Entity;

namespace YoVPM.Yggdrasil.Core.Data;

public class YggdrasilDbContext(DbContextOptions<YggdrasilDbContext> options) : DbContext(options)
{
    public DbSet<PackageEntity> Packages { get; set; }
    public DbSet<PackageVersionEntity> PackageVersions { get; set; }
    public DbSet<PackageRepositoryEntity> Repositories { get; set; }

    public DbSet<PackageVersionDependencyEntity> PackageVersionDependencies { get; set; }
    public DbSet<PackageVersionSampleEntity> PackageVersionSamples { get; set; }

    public DbSet<FileEntity> Files { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileEntity>();

        modelBuilder.Entity<PackageVersionDependencyEntity>();
        modelBuilder.Entity<PackageVersionSampleEntity>();
        modelBuilder.Entity<PackageLegacyFileOrFolderEntity>();

        var packageVersionTypeBuilder = modelBuilder.Entity<PackageVersionEntity>();

        packageVersionTypeBuilder.HasOne(e => e.File)
            .WithMany()
            .HasForeignKey(e => e.FileId)
            .IsRequired();

        packageVersionTypeBuilder
            .HasMany(e => e.Dependencies)
            .WithOne()
            .IsRequired();
        packageVersionTypeBuilder
            .HasMany(e => e.VpmDependencies)
            .WithOne()
            .IsRequired();
        packageVersionTypeBuilder
            .HasMany(e => e.GitDependencies)
            .WithOne()
            .IsRequired();

        packageVersionTypeBuilder
            .HasMany(e => e.LegacyFiles)
            .WithOne()
            .IsRequired();
        packageVersionTypeBuilder
            .HasMany(e => e.LegacyFolders)
            .WithOne()
            .IsRequired();

        packageVersionTypeBuilder
            .HasMany(e => e.Samples)
            .WithOne()
            .IsRequired();

        // Don't make package entity vpm id unique, as some "developers" publish same package in multiple repositories
        modelBuilder.Entity<PackageEntity>()
            .HasMany(e => e.Versions)
            .WithOne(e => e.Package)
            .HasForeignKey(e => e.PackageId)
            .IsRequired();

        var repositoryTypeBuilder = modelBuilder.Entity<PackageRepositoryEntity>();

        repositoryTypeBuilder
            .HasMany(e => e.Packages)
            .WithOne(e => e.Repository)
            .HasForeignKey(e => e.RepositoryId)
            .IsRequired();

        repositoryTypeBuilder
            .HasIndex(e => e.VpmId)
            .IsUnique();
    }
}
