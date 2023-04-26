using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class CadastroTurmaDbContext : DbContext
    {
        public CadastroTurmaDbContext()
        {

        }
        public CadastroTurmaDbContext(DbContextOptions<CadastroTurmaDbContext> opt) : base(opt)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<AlunoTurma> AlunosTurmas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=MAGNATI-10865-F;" +
                       "Initial Catalog=CursoIdiomas;" +
                       "Integrated Security=True;" +
                       "Connect Timeout=30;" +
                       "Encrypt=False;" +
                       "TrustServerCertificate=False;" +
                       "ApplicationIntent=ReadWrite;" +
                       "MultiSubnetFailover=False");
            }
        }
    }
}
