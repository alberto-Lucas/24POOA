using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedoPOO
{
    public class BrinquedoExecucao
    {
        //-Adicionar: Recebe objeto como parâmetros
        //-Remover: Recebe objeto como parâmetros
        //-Listar: Retorna a lista de objetos
        private List<Brinquedo> listaBrinquedos =
            new List<Brinquedo>();

        public void Adicionar(Brinquedo brinquedo)
        {
            listaBrinquedos.Add(brinquedo);
        }

        public void Remover(Brinquedo brinquedo)
        {
            listaBrinquedos.Remove(brinquedo);
        }

        public List<Brinquedo> Listar()
        {
            return listaBrinquedos;
        }
    }
}
