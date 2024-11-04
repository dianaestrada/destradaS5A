using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using destradaS5A.Models;
namespace destradaS5A.Views;

public partial class Editar : ContentPage
{
    public Editar(string name, int id)
	{
		InitializeComponent();   
        txtname.Text = name;
        lblId.Text = id.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        string newname = txtname.Text;
        int id = int.Parse(lblId.Text);

        if (id > 0)
        {
            Persona persona = new Persona { Id = id, Name = newname };
            App.person.UpdatePerson(persona);
            Navigation.PushAsync(new Views.Principal());
        }
        else
        {
            App.person.AddNewPerson(newname);
        }
    }
}