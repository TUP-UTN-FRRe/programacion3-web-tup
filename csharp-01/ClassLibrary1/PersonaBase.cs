namespace ClassLibrary1
{
    public class PersonaBase
    {
        private DateTime _fechaNacimiento;

        public int Edad { get; set; }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set
            {
                _fechaNacimiento = value;
                Edad = DateTime.Now.Year - _fechaNacimiento.Year;
            }
        }
    }
}
