using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CadastroClientes.Dominio.Entidades
{
    public class Cliente : EntityBase
    {
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }
        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Sexo { get; set; }
        public string Cep { get; set; }
        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }
        [Display(Name = "Número")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        [Display(Name = "UF")]
        public string Uf { get; set; }
        public string Cidade { get; set; }
    }
}
