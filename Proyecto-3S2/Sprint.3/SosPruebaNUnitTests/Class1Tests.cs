using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SosPruebaNUnit.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        //PRUEBA CUANDO ES O 
        public void insertarLetterOTest()
        {
            string result = Class1.insertLetter("O");
            Assert.AreEqual("O", result);
        }

        [TestMethod()]
        //PRUEBA CUANDO ES S 
        public void insertarLetterSTest()
        {
            string result = Class1.insertLetter("S");
            Assert.AreEqual("S", result);
        }

        [TestMethod()]
        //PRUEBA CUANDO ES LETRA INVALIDA 
        public void insertarInvalidLetterTest()
        {
            string result = Class1.insertLetter("X");
            Assert.AreEqual("Letra inválida", result);
        }
    }
}