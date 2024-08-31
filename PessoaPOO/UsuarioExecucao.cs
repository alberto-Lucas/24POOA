using System.Collections.Generic;

namespace PessoaPOO
{
    public class UsuarioExecucao
    {
        private List<Usuario> listaUsuario = new List<Usuario>();

        public void Adicionar(Usuario usuario)
        {
            listaUsuario.Add(usuario);
        }

        public void Remover(Usuario usuario)
        {
            listaUsuario.Remove(usuario);
        }

        public List<Usuario> ListarUsuarios()
        {
            return listaUsuario;
        }

        //---------------------------------------------------------------------
        //Metodo responsavel por pesquisar o usuario 
        //na listagem recebendo o nome do usuario por parametro
        public List<Usuario> Pesquisar(string nome)
        {
            //---------------------------------------------------------------------
            //Primeira coisa preciso criar uma nova lista de usuario
            //que vai armazenar o retorno do meu filtro
            //Como se fosse o retorno do meu SELECT no banco de dados
            List<Usuario> listaPesquisa = new List<Usuario>();

            //---------------------------------------------------------------------
            //Neste caso eu vou realizar um pesquisa na lista de Usuario
            //verificar se existe um nome que contenha o valor que eu digitei no campo
            //e retorno todos os valores encontrados na nova lista de pesquisa
            //semelhante a um SELECT * FROM usuario WHERE nome LIKE "%nome%"

            //---------------------------------------------------------------------
            //Neste caso é utilizado o método FindAll para pesquisar todos os registro
            //Ou seja o FinAll retorna uma lista de valores encontrados
            //Utilizamos o comando lambida (=>) serve para força um apontamento em memoria
            //assim criamos a variavel x q sera a instancia para cada item da lista
            //ou seja irei verificar um atribudo na minha instancia utilizando 
            //o metodo contains usado para verificar se o valor contem uma parte do texto por parametro
            //no nosso caso se o atribudo nome contem uma parte do valo digitado
            //neste caso vemos da seguinte forma
            //verificamos se a instancia x => possui um registro no atribudo 
            //que contenha uma parte do valor digitado
            //se encontrar esse X será o retorno do nosso item

            //---------------------------------------------------------------------
            //x vai receber o resultado da consulta
            //Esse processo é realizado item a item de forma autoamtica
            listaPesquisa = listaUsuario.FindAll(x => x.Pessoa.Nome.Contains(nome));

            //---------------------------------------------------------------------
            //Informação IMPORTANTE!!!!!!!!!
            //Caso o parametro estiver vazio é retornado todos os registro da lista

            //---------------------------------------------------------------------
            //Por fim retornamos uma nova listagem 
            return listaPesquisa;
        }
    }
}
