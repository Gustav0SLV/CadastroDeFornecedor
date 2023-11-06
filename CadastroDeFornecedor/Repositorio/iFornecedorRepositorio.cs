using CadastroDeFornecedor.Models;
using System.Collections.Generic;

namespace CadastroDeFornecedor.Repositorio
{
    public interface iFornecedorRepositorio
    {
        FornecedorModel ListarPorID(int id);
        List<FornecedorModel> BuscarTodos();
        FornecedorModel Adicionar(FornecedorModel fornecedor);
        FornecedorModel Atualizar(FornecedorModel fornecedor);

        bool Apagar(int id); 
    }
}
