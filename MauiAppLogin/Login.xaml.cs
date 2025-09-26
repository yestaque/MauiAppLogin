namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		try
		{
			// Lista de usuários "mockados"
			List<DadosUsuario> lista_usuarios = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{
					Usuario = "jose",
					Senha = "123"
				},
				new DadosUsuario()
				{
					Usuario = "maria",
					Senha = "321"
				}
			};

			// Dados digitados
			DadosUsuario dados_digitados = new DadosUsuario()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

			// LINQ para verificar login
			if (lista_usuarios.Any(i =>
				dados_digitados.Usuario == i.Usuario &&
				dados_digitados.Senha == i.Senha))
			{
				// Salvar usuário logado no SecureStorage
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

				// Redirecionar para a página protegida
				App.Current.MainPage = new Protegida();
			}
			else
			{
				throw new Exception("Usuário ou senha incorretos.");
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}
	}
}
