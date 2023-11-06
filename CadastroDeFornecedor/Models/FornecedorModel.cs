using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeFornecedor.Models
{
    public class FornecedorModel
    {    
        public int Id { get; set; }
        
        [Required(ErrorMessage = "É Obrigatório informar um Nome")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "É obrigatório informar um CNPJ")]
        public long Cnpj { get; set; }
       
        public string Especialidade { get; set; }

        [Required(ErrorMessage = "É obrigatório informar um CEP")]
        public int Cep { get; set; }
       
        [Required(ErrorMessage = "É Obrigatório informar um Endereço")]
        public string Endereco { get; set; }
    }
}
