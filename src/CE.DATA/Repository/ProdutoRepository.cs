using CE.BUSINESS.Interfaces;
using CE.BUSINESS.Models;
using CE.DATA.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.DATA.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CEDbContext context) : base(context)
        {
        }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await _context.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await _context.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
