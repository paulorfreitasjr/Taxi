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
using Taxi.Control;

namespace Taxi
{
    [Activity(Label = "Novo usuario")]
    public class Cadastro : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Apresentacao_CadastroUsuario);
            // Create your application here
        }
    }
}