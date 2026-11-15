using MauiAppEvento.Model;
using System.Globalization;

namespace MauiAppEvento.View;

public partial class CadastroEvento : ContentPage
{
	public CadastroEvento()
	{
		InitializeComponent();

        dtpck_inicio.MinimumDate = DateTime.Today;
        dtpck_inicio.MaximumDate = DateTime.Today.AddMonths(3);

        dtpck_termino.MinimumDate = DateTime.Today.AddDays(1);
        dtpck_termino.MaximumDate = DateTime.Today.AddMonths(4);

        BindingContext = new Evento();
    }
    private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        dtpck_termino.MinimumDate = e.NewDate?.AddDays(1);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        {
            try
            {
                if (!decimal.TryParse(
                txt_custoparticipante.Text,
                NumberStyles.Number,
                CultureInfo.GetCultureInfo("pt-BR"),
                out decimal Custo))
                {
                    DisplayAlertAsync(

                        "Ops!",
                        "Digite um custo por participante válido.",
                        "OK");

                    return;
                }

                Evento h = new()
                {
                    QntParticipantes = Convert.ToInt32(stp_participantes.Value),
                    DataInicio = dtpck_inicio.Date.Value,
                    DataTermino = dtpck_termino.Date.Value,
                    CustoPorParticipante = Custo,
                    NomeEvento = txt_evento.Text,
                    LocalEvento = txt_local.Text,
                };

                Navigation.PushAsync(new EventoCadastrado
                {
                    BindingContext = h
                });
            }
            catch (Exception ex)
            {
                DisplayAlertAsync("Ops!", ex.Message, "OK");
            }
        }
    }
}