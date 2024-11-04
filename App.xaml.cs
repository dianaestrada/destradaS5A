using destradaS5A.Utils;

namespace destradaS5A
{
    public partial class App : Application
    {
        public static PersonRepository person{  get; set; }
        public App(PersonRepository personRepository)
        {
            InitializeComponent();

            MainPage = new NavigationPage( new Views.Principal());
            person = personRepository;
        }
    }
}
