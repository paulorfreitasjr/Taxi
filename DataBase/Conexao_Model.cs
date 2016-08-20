using System.Data;
using MySql.Data.MySqlClient;
using System;

namespace Taxi.DataBase
{
    class Conexao_Model
    {
        private static Conexao_Model conexaoModelo = new Conexao_Model();
        private MySqlConnection _conexao = new MySqlConnection();
        private string _server = "192.168.0.14";
        private string _database = "taxi";
        private string _usuario = "root";
        private string _senha = "123456";

        public MySqlConnection Conexao { get { return _conexao; } set { _conexao = value; } }
        public string Server { get { return _server; } set { _server = value; } }
        public string Database { get { return _database; } set { _database = value; } }
        public string Usuario { get { return _usuario; } set { _usuario = value; } }
        public string Senha { get { return _senha; } set { _senha = value; } }

        public Conexao_Model() { }

        public static Conexao_Model getInstancia()
        {
            return conexaoModelo;
        }

        public MySqlConnection getConexao()
        {
            string conn = string.Format("Server={0};Database={2};Uid={3};Pwd={4}", Server, Database, Usuario, Senha);
            return new MySqlConnection(conn);
        }

        public void Conectar()
        {
            try
            {
                getInstancia().getConexao().Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public bool IsConectado()
        {
            if (_conexao != null && _conexao.State == ConnectionState.Open)
                return true;
            else
                return false;
        }

        public void Desconectar()
        {
            if (_conexao != null && _conexao.State == ConnectionState.Open)
                _conexao.Close();
        }

        public MySqlDataAdapter Consultar(string stringSql)
        {
            if (_conexao != null && _conexao.State == ConnectionState.Open)
            {
                var adapter = new MySqlDataAdapter(stringSql, _conexao);
                return adapter;
            }

            return null;
        }

        public int Inserir(string stringSql)
        {
            if (_conexao != null && _conexao.State == ConnectionState.Open)
            {
                var command = _conexao.CreateCommand();
                command.CommandText = stringSql;
                var resultado = command.ExecuteNonQuery();

                if (resultado > -1)
                {
                    return (int)command.LastInsertedId;
                }
                else
                    return -1;
            }

            return -1;
        }
    }
}