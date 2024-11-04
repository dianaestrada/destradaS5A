
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

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var delete = sender as Button;
        var persona = delete.BindingContext as Persona;

        bool validar = await DisplayAlert("Confirmacion", $"¿Estás seguro de borrar a {persona.Name}?", "si", "no");

        if (validar)
        {
            App.person.DeletePerson(persona.Id);
            await DisplayAlert("Confirmar", App.person.StatusMessage, "Aceptar");
            btnMostrar_Clicked(sender, e);
        }
    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        var update = sender as Button;
        var persona = update.BindingContext as Persona;
        Navigation.PushAsync(new Views.Editar(persona.Name, persona.Id));
    }
}