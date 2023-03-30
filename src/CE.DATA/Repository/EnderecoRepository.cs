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
    public class EnderecoRepository : Repository<Endereco>, IEnderecoFornecedor
    {

        public EnderecoRepository(CEDbContext context) : base(context) 
        {
        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await _context.Enderecos
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId);
        }
    }
}
