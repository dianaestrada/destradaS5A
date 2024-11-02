
using destradaS5A.Models;

namespace destradaS5A.Views;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.person.AddNewPerson(txtname.Text);
        lblStatus.Text = App.person.StatusMessage;
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";

        List<Persona> people = App.person.GetAllPerson();
        ListaPersonas.ItemsSource = people;

    }
    //eliminar y actualizar tarea
}