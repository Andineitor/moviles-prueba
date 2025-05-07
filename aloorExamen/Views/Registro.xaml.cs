namespace aloorExamen.Views;

public partial class Registro : ContentPage
{
    private const decimal COSTO_TOTAL = 300m;
    public string Usuario { get; set; }

    public Registro()
    {
        InitializeComponent();
    }

    public Registro(string username)
    {
        InitializeComponent();
        lblUsuario.Text = $"Bienvenido, {username}!";
    }

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        if (!decimal.TryParse(txtMonto.Text, out var inicial) || inicial < 0)
        {
            DisplayAlert("Error", "Ingrese un monto inicial válido.", "OK");
            return;
        }

        if (inicial >= COSTO_TOTAL)
        {
            DisplayAlert("Error", $"El monto inicial debe ser menor a {COSTO_TOTAL:F2}.", "OK");
            return;
        }

        var resto = COSTO_TOTAL - inicial;
        var cuotaBase = resto / 3;
        var costoAdicional = COSTO_TOTAL * 0.05m;
        var cuotaConInteres = cuotaBase + costoAdicional;
        txtMontoMensual.Text = cuotaConInteres.ToString("F2");
    }

    private void btnResumen_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text) ||
            vaPicker.SelectedItem == null ||
            CiudadPicker.SelectedItem == null ||
            string.IsNullOrWhiteSpace(txtMonto.Text) ||
            string.IsNullOrWhiteSpace(txtMontoMensual.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos antes de continuar.", "OK");
            return;
        }

        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        string voltaje = vaPicker.SelectedItem?.ToString() ?? "";
        string ciudad = CiudadPicker.SelectedItem?.ToString() ?? "";
        DateTime fecha = FechaDatePicker.Date;

        if (!decimal.TryParse(txtMonto.Text, out decimal montoInicial) ||
            !decimal.TryParse(txtMontoMensual.Text, out decimal cuotaMensual))
        {
            DisplayAlert("Error", "Valores numéricos inválidos.", "OK");
            return;
        }

        try
        {
            Navigation.PushAsync(new Resumen(nombre, apellido, voltaje, ciudad, fecha, montoInicial, cuotaMensual));
        }
        catch (Exception ex)
        {
            DisplayAlert("Error inesperado", ex.Message, "OK");
        }
    }
}
