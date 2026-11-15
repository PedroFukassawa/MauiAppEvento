namespace MauiAppEvento.View;

public partial class EventoCadastrado : ContentPage
{
	public EventoCadastrado()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new CadastroEvento());
        }

        catch (Exception ex)
        {
            DisplayAlertAsync("Erro", ex.Message, "OK");
        }
    }
}