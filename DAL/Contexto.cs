using GestionLibros.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionLibros.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> opciones) : base(opciones) { }

    public DbSet<Libros> Libros { get; set; }
}
