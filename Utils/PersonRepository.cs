using destradaS5A.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace destradaS5A.Utils
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }
        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonRepository(string path)
        {
            dbPath = path;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre requerido");
                Persona person = new() { Name = name };
                result = conn.Insert(person);

                StatusMessage = string.Format("Dato insertado");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error" + ex.Message);
            }
        }
        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error" + ex.Message);
            }
            return new List<Persona>();
        }

        public void UpdatePerson(Persona person)
        {
            try
            {
                Init();
                conn.Update(person);
                StatusMessage = $"Se actualizó con exito {person.Name}.";

            }
            catch (Exception ex)
            {
                StatusMessage = $"Erros al actualizar{person.Name} : {ex.Message}";
            }
            }
            public void DeletePerson(int id)
            {
                try
                {
                    Init();
                    conn.Delete<Persona>(id);
                    StatusMessage = "Se elimino correctamente.";
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Error al eliminar:{ex.Message}";
                }
            }
    }
}
