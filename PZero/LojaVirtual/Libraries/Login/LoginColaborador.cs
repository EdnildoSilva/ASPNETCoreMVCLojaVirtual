using LojaVirtual.Models;
using System;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginColaborador
    {
        private string _Key = "Login.Colaborador";
        private Sessao.Sessao _sessao;
        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador colaborador)
        {
            //Serializar
            string colaboradorJSON = JsonConvert.SerializeObject(colaborador);
            //Armazenar dados na sessao.
            _sessao.Cadastrar(_Key, colaboradorJSON);
        }

        public Colaborador GetColaborador()
        {
            //Recuperar dados da sessao.
            if (_sessao.Existe(_Key))
            {
                string colaboradorJSON = _sessao.Consultar(_Key);
                //Deserializar
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJSON);
            }
            return null;
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
