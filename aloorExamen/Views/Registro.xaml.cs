namespace aloorExamen.Views;

public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();
	}

    public Registro(string usuario)
    {
        InitializeComponent();
        lblUsuario.Text = "USUARIO CONECTADO" + usuario;
    }

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {

    }
}