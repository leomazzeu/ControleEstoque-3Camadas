using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CE.APP.ViewModels;

namespace CE.APP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CE.APP.ViewModels.ProdutoViewModel>? ProdutoViewModel { get; set; }
        public DbSet<CE.APP.ViewModels.EnderecoViewModel>? EnderecoViewModel { get; set; }
    }
}