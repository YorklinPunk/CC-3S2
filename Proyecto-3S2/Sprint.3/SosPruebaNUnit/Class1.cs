namespace SosPruebaNUnit
{
    public class Class1
    {
        public static string insertLetter(string letter)
        {
            if (letter == "S" || letter == "O")
            {
                return letter;
            }
            return "Letra inválida";
        }
    }
}
