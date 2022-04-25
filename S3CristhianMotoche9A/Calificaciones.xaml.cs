using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S3CristhianMotoche9A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calificaciones : ContentPage
    {
        double notaP1;
        double notaP2;

        public Calificaciones()
        {
            InitializeComponent();
        }

        public Calificaciones(string strUser, string strPass)
        {
            if (strUser.Equals("estudiante2022") && strPass.Equals("uisrael2022"))
            {
                InitializeComponent();
            }
            else
            {
                _ = DisplayAlert("ERROR", "Usuaio o Clave Incorrectos!", "OK");
            }

        }

        private void BtnCalcular_Clicked(object sender, EventArgs e)
        {
            try
            {

                double notaFinal = notaP1 + notaP2;

                TxtNotaFinal.Text = notaFinal.ToString();

                _ = DisplayAlert("Resultado!", ValidarNotaFinal(notaFinal), "OK");


            }
            catch (Exception ex)
            {
                _ = DisplayAlert("ERROR", ex.Message, "Cerrar");
            }

        }

        private void CalcularPrimerParcial()
        {
            try
            {
                double notaS1 = Convert.ToDouble(TxtNotaS1.Text) * 0.3;

                double notaE1 = Convert.ToDouble(TxtNotaE1.Text) * 0.2;

                notaP1 = notaS1 + notaE1;

                TxtNotaP1.Text = notaP1.ToString();

            }
            catch (Exception ex)
            {
                _ = DisplayAlert("ERROR", ex.Message, "Cerrar");
            }

        }

        private void CalcularSegundoParcial()
        {
            try
            {
                double notaS2 = Convert.ToDouble(TxtNotaS2.Text) * 0.3;

                double notaE2 = Convert.ToDouble(TxtNotaE2.Text) * 0.2;

                notaP2 = notaS2 + notaE2;

                TxtNotaP2.Text = notaP2.ToString();

            }
            catch (Exception ex)
            {
                _ = DisplayAlert("ERROR", ex.Message, "Cerrar");
            }

        }


        /// <summary>
        /// Método que evalua el resultado de la nota final.
        /// </summary>
        /// <param name="notaFinal">Nota Final</param>
        /// <returns>Mensaje con el resultado.</returns>
        private string ValidarNotaFinal(double notaFinal)
        {
            string strResultado = string.Empty;

            if (notaFinal >= 7)
            {
                strResultado = "Aprobado!";
            }
            else
            {
                if (notaFinal >= 5)
                {
                    strResultado = "Supletorio!";
                }
                else
                {
                    strResultado = "Reprobado!";
                }

            }

            return strResultado;
        }


        /// <summary>
        /// Método para evaluar que la nota ingresada se encuentre entre 0 y 10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EvaluarRango_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(e.NewTextValue, out double valor))
            {
                if (valor < 0 || valor > 10)
                {
                    ((Entry)sender).Text = e.OldTextValue;

                }
            }
        }

        private void CalcularPrimerParcial_Unfocused(object sender, FocusEventArgs e)
        {
            CalcularPrimerParcial();
        }

        private void CalcularSegundoParcial_Focused(object sender, FocusEventArgs e)
        {
            CalcularSegundoParcial();
        }

    }
}