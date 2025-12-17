using AdmissionComittee.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdmissionComittee.Context
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class ApplicantContext : DbContext
    {
        /// <summary>
        /// Таблица абитуриентов
        /// </summary>
        public DbSet<Applicant> Applicants { get; set; } = null!;

        /// <summary>
        /// Создание бд
        /// </summary>
        public ApplicantContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=das;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}
