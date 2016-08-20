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
using Taxi.DataBase;
using MySql.Data.MySqlClient;
using System.Data;

namespace Taxi.Model
{
    class Modelo_Usuario : Conexao_Model
    {
        public int Codigo { get { return _codigo; } set { _codigo = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
        public string Sobrenome { get { return _sobrenome; } set { _sobrenome = value; } }
        public string Telefone { get { return _telefone; } set { _telefone = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Foto { get { return _foto; } set { _foto = value; } }
        public string Data { get { return _data; } set { _data = value; } }
        public bool IsLogado { get { return _isLogado; } set { _isLogado = value; } }
        
        private int _codigo = 0;
        private string _nome = string.Empty;
        private string _sobrenome = string.Empty;
        private string _telefone = string.Empty;
        private string _email = string.Empty;
        private string _foto = string.Empty;
        private string _data = string.Empty;
        private bool _isLogado = false;

        public Modelo_Usuario()
        {

        }

        public Modelo_Usuario(int codigo, string nome, string sobrenome, string email, string foto, string data)
        {
            _codigo = codigo;
            _nome = nome;
            _sobrenome = sobrenome;
            _email = email;
            _foto = foto;
            _data = data;
        }

        public bool ConsultarUsuario(string login, string senha)
        {
            Conectar();

            if (IsConectado())
            {
                var command = new MySqlCommand("SELECT codigo_pes, nome_pes, sobren_pes, email_pes, fone_pes, datnas_pes, foto_pes " +
                    "FROM usuario inner join pessoa on codigo_pes = codpes_usu where email_pes = @email and senha_usu = @senha", Conexao);

                var paramEmail = new MySqlParameter("@email", MySqlDbType.VarChar);
                paramEmail.Value = login;
                var paramSenha = new MySqlParameter("@senha", MySqlDbType.VarChar);
                paramSenha.Value = senha;
                command.Parameters.Add(paramEmail);
                command.Parameters.Add(paramSenha);

                var reader = command.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                Console.WriteLine("Linhas retornadas: " + dt.Rows.Count.ToString());

                if (dt.Rows.Count > 0)
                {
                    Desconectar();
                    var codigo = 0;
                    var nome = string.Empty;
                    var sobrenome = string.Empty;
                    var email = string.Empty;
                    var telefone = string.Empty;
                    var data = string.Empty;
                    var foto = string.Empty;
                    //DateTime data = new DateTime();
                    //byte[] foto = null;

                    if (dt.Rows[0].ItemArray[0] != null)
                        _codigo = (int) dt.Rows[0].ItemArray[0];

                    if (dt.Rows[0].ItemArray[1] != null)
                        _nome = dt.Rows[0].ItemArray[1].ToString();

                    if (dt.Rows[0].ItemArray[2] != null)
                        _sobrenome = dt.Rows[0].ItemArray[2].ToString();

                    if (dt.Rows[0].ItemArray[3] != null)
                        _email = dt.Rows[0].ItemArray[3].ToString();

                    if (dt.Rows[0].ItemArray[4] != null)
                        _telefone = dt.Rows[0].ItemArray[4].ToString();

                    if (dt.Rows[0].ItemArray[5] != null)
                    {
                        _data = dt.Rows[0].ItemArray[5].ToString();
                    }

                    if(dt.Rows[0].ItemArray[6] != null)
                    {
                        _foto = dt.Rows[0].ItemArray[6].ToString();
                    }

                    _isLogado = true;
                    
                    return true;
                }
                
                Desconectar();
            }

            return false;
        }
    }
}