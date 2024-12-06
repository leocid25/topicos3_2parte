using ClinVet.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection.Emit;

namespace ClinVet.Persistence
{
    public class ClinVetDbContext
    {
        public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
        public List<Encontro> Encontros { get; set; } = new List<Encontro>();
        public List<Pet> Pets { get; set; } = new List<Pet>();
        public List<Proprietario> Proprietarios { get; set; } = new List<Proprietario>();
        public List<Tratamento> Tratamentos { get; set; } = new List<Tratamento>();
        public List<Veterinario> Veterinarios { get; set; } = new List<Veterinario>();
        public Veterinario Veterinario { get; set; } = new Veterinario();
    }
}

//namespace ClinVet.Persistence
//{
   
//    public class ClinVetDbContext
//    {
//        public List<Agendamento> Agendamentos {  get; set; }
//        public List<Encontro> Encontros { get; set; }
//        public List<Pet> Pets { get; set; }
//        public List<Proprietario> Proprietarios { get; set; }
//        public List<Tratamento> Tratamentos { get; set; }
//        public List<Veterinario> Veterinarios { get; set; }
//        public Veterinario Veterinario { get; set; }

//        public ClinVetDbContext() {
//            Agendamentos = new List<Agendamento>();
//            Encontros = new List<Encontro>();
//            Pets = new List<Pet>();
//            Proprietarios = new List<Proprietario>();
//            Tratamentos = new List<Tratamento>();
//            Veterinarios = new List<Veterinario>();
//            Veterinario = new Veterinario();
//        }

//    }
    //public class ClinVetDbContext(DbContextOptions<ClinVetDbContext> options) : DbContext(options)
    //{
    //    public DbSet<Pet> Pets { get; set; }
    //    public DbSet<Proprietario> Proprietarios { get; set; }
    //    public DbSet<Veterinario> Veterinarios { get; set; }
    //    public DbSet<Encontro> Encontros { get; set; }
    //    public DbSet<Tratamento> Tratamentos { get; set; }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        modelBuilder.Entity<Pet>()
    //           .HasRequired(p => p.Proprietario)
    //           .WithMany(o => o.Pets)
    //           .HasForeignKey(p => p.ProprietarioId)
    //           .WillCascadeOnDelete(false);

    //        modelBuilder.Entity<Encontro>()
    //         .HasRequired(a => a.Pet)
    //         .WithMany(p => p.Encontros)
    //         .HasForeignKey(a => a.PetId)
    //         .WillCascadeOnDelete(false);

    //        modelBuilder.Entity<Encontro>()
    //          .HasRequired(a => a.Veterinario)
    //          .WithMany(v => v.Encontros)
    //          .HasForeignKey(a => a.VeterinarioId)
    //          .WillCascadeOnDelete(false);

    //        modelBuilder.Entity<Tratamento>()
    //           .HasRequired(t => t.Encontro)
    //           .WithMany(a => a.Tratamentos)
    //           .HasForeignKey(t => t.EncontroId)
    //           .WillCascadeOnDelete(false);

    //        modelBuilder.Entity<Agendamento>()
    //           .HasRequired(s => s.Veterinario)
    //           .WithMany(v => v.Agendamentos)
    //           .HasForeignKey(s => s.VeterinarioId)
    //           .WillCascadeOnDelete(false);

    //        modelBuilder.Entity<Agendamento>()
    //        .Property(e => e.DataInicio)
    //        .HasColumnType("datetime");

    //        modelBuilder.Entity<Agendamento>()
    //            .Property(e => e.DataFim)
    //            .HasColumnType("datetime");

    //    }
    //}
//}
