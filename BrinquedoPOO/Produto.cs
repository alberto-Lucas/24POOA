using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedoPOO
{
    public class Produto
    {
        //-Código de Barras
        //-Descrição
        //-Preço
        //-Fabricante
        //-Retorna concatenação do Código de Barras e Descrição

        public string CodBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Fabricante Fabricante { get; set; }
        public string CodBarrasDesc
        {
            get
            {
                return CodBarras + " - " + Descricao;
            }
        }
    }
}
