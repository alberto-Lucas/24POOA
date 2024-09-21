using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjetoPOO_Teste.Models
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }
        public string Telefone { get; set; }

        [NotMapped]
        public string IdNomeCliente
        {
            get
            {
                return Id_Cliente.ToString() + " - " + Nome;
            }
        }

    }

    public class ClienteCollection : List<Cliente>
    {
    }
}
