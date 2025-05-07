namespace aloorExamen.Views;

public partial class Login : ContentPage
{

    private readonly string[] usuarios = { "andy", "jeol", "loor" };
    private readonly string[] contrasenas = { "moviles", "2025 ", "2025_1" };

    public Login()
	{
		InitializeComponent();
	}

    string usuariof = "";
    string contrasenaf = "";

    public Login(string usuario, string contrasena)
    {
        InitializeComponent();
        this.usuariof = usuario;
        this.contrasenaf = contrasena;
    }

    private async void btnIncioSesion_Clicked(object sender, EventArgs e)
    {
        string user = txtUsuario.Text;
        string pass = txtContrasena.Text;

        bool encontrado = false;
        int indice = -1;

        for (int i = 0; i < usuarios.Length; i++)
        {
            if (usuarios[i].Equals(user, StringComparison.OrdinalIgnoreCase) && contrasenas[i] == pass)
            {
                encontrado = true;
                indice = i;
                break;
            }
        }

        if (encontrado)
        {
            await DisplayAlert("Bienvenido", $"Hola {usuarios[indice]}!", "OK");
            await Navigation.PushAsync(new Views.Registro(usuarios[indice]));
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
        }

    }
    private void btnRegistro_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Desarrollado Por", "Ing. Andy Loor", "ok");

    }
}