using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        private string _Key = "Login.Cliente";
        private Sessao.Sessao _sessao;
        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            //Serializar
            string clienteJSON = JsonConvert.SerializeObject(cliente);
            //Armazenar dados na sessao.
            _sessao.Cadastrar(_Key, clienteJSON);
        }

        public Cliente GetCliente()
        {
            //Recuperar dados da sessao.
            if (_sessao.Existe(_Key))
            {
                string clienteJSON = _sessao.Consultar(_Key);
                //Deserializar
                return JsonConvert.DeserializeObject<Cliente>(clienteJSON);
            }
            return null;
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
