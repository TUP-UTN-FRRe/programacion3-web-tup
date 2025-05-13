namespace ClassLibrary1
{
    public class PersonaBase
    {
        private DateTime _fechaNacimiento;

        public int Edad { get; private set; }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set
            {
                _fechaNacimiento = value;

                Edad = DateTime.Now.Year - _fechaNacimiento.Year;

                if (DateTime.Now.DayOfYear < _fechaNacimiento.DayOfYear)
                {
                    Edad--;
                }
            }
        }

        public string Nombre { get; set; }

         
        private string _apellido;
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }


        public string Saludar(string mensaje) {
            
            return $"Hola {mensaje}";
        }
    }
}
