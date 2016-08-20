using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Taxi.Model;

namespace Taxi.Control
{
    class Controle_Login
    {
        private string _login = string.Empty;
        private string _senha = string.Empty;
        private Modelo_Usuario _usuario = null;

        public string Login { get { return _login; } set { _login = value; } }
        public string Senha { get { return _senha; } set { _senha = value; } }
        public Modelo_Usuario Usuario { get { return _usuario; } set { _usuario = value; } }

        public bool ValidarLogin(string login, string senha)
        {
            var usuarioLogado = new Modelo_Usuario();
            var valido = usuarioLogado.ConsultarUsuario(login, senha);

            if (valido)
                _usuario = usuarioLogado;

            return valido;
        }
    }
}