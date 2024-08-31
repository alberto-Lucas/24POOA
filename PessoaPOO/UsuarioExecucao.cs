using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaPOO
{
    public class UsuarioExecucao
    {
        //Criar uma lista de objeto Usuario
        //Ou seja um local que pode possuir
        //varios usuarios
        private List<Usuario> 
            listaUsuario = new List<Usuario>();

        public void Adicionar(Usuario usuario)
        {
            listaUsuario.Add(usuario);
        }

        public void Remover(Usuario usuario)
        {
            listaUsuario.Remove(usuario);
        }

        //Método que vai retornar a lista
        public List<Usuario> ListarUsuarios()
        {
            return listaUsuario;
        }
    }
}
