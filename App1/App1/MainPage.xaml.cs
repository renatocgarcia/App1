using App1.Servico;
using App1.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //Validações
            try
            {
                string cep = CEP.Text.Trim();
                if (IsValidCEP(cep))
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCep(cep);
                    if(end != null)
                    {
                        RESULT.Text = string.Format("Endereço: {3}, {0}, {1}, {2}", end.Localidade, end.Uf, end.Logradouro, end.Bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO: ", "CEP não encontrado! ", "OK");
                    }

                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Erro:", ex.Message, "OK");
            }

        }

        private Boolean IsValidCEP(string cep)
        {
            
            /*
            if(cep.Length != 8)
            {
                throw new ArgumentException("CEP Inválido! O CEP deve ter 8 caracteres");
            }
            */
            int NovoCep = 0;
            if(!int.TryParse(cep, out NovoCep))
            {
                throw new ArgumentException("CEP Inválido! O CEP deve conter somente números");
            }

            return true;
        }
    }
}
