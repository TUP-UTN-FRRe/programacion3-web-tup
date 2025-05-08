using ClassLibrary1;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var alumno = new Alumno();
            alumno.FechaNacimiento = new DateTime(2000, 1, 1);

            Assert.True(alumno.Edad == 25, "La edad no es correcta.");


        }
    }
}
