namespace aloorExamen.Views;

public partial class Resumen : ContentPage
{
	public Resumen()
	{
		InitializeComponent();
	}
    public Resumen(string usuario)
    {
        InitializeComponent();
        lblUsuario.Text = "USUARIO CONECTADO" + usuario;
    }
}