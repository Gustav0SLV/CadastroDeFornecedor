using CadastroDeFornecedor.Data;
using CadastroDeFornecedor.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeFornecedor.Repositorio
{
    public class FornecedorRepositorio : iFornecedorRepositorio
    {
        private readonly BancoContext _bancoContext;
        public FornecedorRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public FornecedorModel ListarPorID(int id)
        {
            return _bancoContext.Fornecedores.FirstOrDefault(x => x.Id == id);
        }
        public List<FornecedorModel> BuscarTodos()
        {
            return _bancoContext.Fornecedores.ToList();
        }
        public FornecedorModel Adicionar(FornecedorModel fornecedor)
        {
            
            _bancoContext.Fornecedores.Add(fornecedor);
            _bancoContext.SaveChanges();
            return fornecedor;
        }

        public FornecedorModel Atualizar(FornecedorModel fornecedor)
        {
            FornecedorModel fornecedorDB = ListarPorID(fornecedor.Id);

            if (fornecedorDB == null) throw new System.Exception("Houve um Erro na Atualização do Fornecedor! ");

            fornecedorDB.Nome = fornecedor.Nome;
            fornecedorDB.Cnpj = fornecedor.Cnpj;
            fornecedorDB.Especialidade = fornecedor.Especialidade;
            fornecedorDB.Cep = fornecedor.Cep;
            fornecedorDB.Endereco = fornecedor.Endereco;

            _bancoContext.Fornecedores.Update(fornecedorDB);
            _bancoContext.SaveChanges(); 
            
            return fornecedorDB;
        }

        public bool Apagar(int id)
        {
            FornecedorModel fornecedorDB = ListarPorID(id);

            if (fornecedorDB == null) throw new System.Exception("Houve um Erro na Deleção do Fornecedor! ");

            _bancoContext.Fornecedores.Remove(fornecedorDB);
            _bancoContext.SaveChanges();    
            return true;
        }
    }
}
