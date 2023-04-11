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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(CEDbContext context): base(context)
        {
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await _context.Fornecedores.AsNoTracking()
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await _context.Fornecedores
                .AsNoTracking()
                .Include(p => p.Produtos)
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
