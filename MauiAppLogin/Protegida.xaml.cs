namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		string? usuario_logado = null;

		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuario.logado");
			lbl_boasvindas.Text = $"Bem-vindo (a) {usuario_logado}";
		});
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		bool confirmacao = await DisplayAlert("Tem Certeza?", "Sair", "Sim", "N�o");

		if (confirmacao)
		{
			SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new Login();
		}
    }
}