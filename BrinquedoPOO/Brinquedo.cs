using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedoPOO
{
    public class Brinquedo
    {
        //-Produto
        //-Categoria
        //-Idade Mínima
        //-Retorna concatenação do Código de Barras, Descrição e Categoria
        //-Retorna concatenação do Código de Barras, Descrição, Categoria e Nome Fabricante

        public Produto Produto { get; set; }
        public string Categoria { get; set; }
        public int IdadeMin { get; set; }

        public string CodBarrasDescCat
        {
            get
            {
                return
                    Produto.CodBarrasDesc + " - " +
                    Categoria;
            }
        }

        public string CodBarrasDescCatFabricante
        {
            get
            {
                return
                    CodBarrasDescCat + " - " +
                    Produto.Fabricante.Nome;
            }
        }
    }
}
