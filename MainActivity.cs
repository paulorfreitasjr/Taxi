using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Taxi
{
    [Activity(Label = "Taxi", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Apresentacao_Login);

            // Get our button from the layout resource,
            // and attach an event to it
            var btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            var tvNovaConta = FindViewById<TextView>(Resource.Id.tvNovoConta);

            btnLogin.Click += delegate { ValidarLogin(); };

            tvNovaConta.Click += (sender, e) =>
            {
                var cadastro = new Intent(this, typeof(Cadastro));
                StartActivity(cadastro);
            };
        }

        protected void ValidarLogin()
        {
            var controleLogin = new Control.Controle_Login();
            var tvLogin = FindViewById<EditText>(Resource.Id.etLogin);
            var tvSenha = FindViewById<EditText>(Resource.Id.etSenha);
            var isLogado = controleLogin.ValidarLogin(tvLogin.Text, tvSenha.Text);
            var builder = new AlertDialog.Builder(this);
            builder.SetMessage(string.Format("Nome: {0}\nSobrenome: {1}\nEmail: {2}\nFone: {3}\nData nascimento: {4}\nFoto: {5}", controleLogin.Usuario.Nome,
                controleLogin.Usuario.Sobrenome, controleLogin.Usuario.Email, controleLogin.Usuario.Telefone, controleLogin.Usuario.Data, controleLogin.Usuario.Foto));
            builder.SetNeutralButton("Ok", (s,e) => { /* */});
            builder.Create().Show();
        }
    }
}

