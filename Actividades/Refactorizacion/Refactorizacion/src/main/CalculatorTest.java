package main;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;


public class CalculatorTest {
    private static Calculadora calculadora;

    @BeforeAll
    public static void init(){
        calculadora = new Calculadora();
    }
    @Test
    public void whenCalculatorInitializedThenReturnTrue() {

        assertTrue(calculadora.getStatus());
    }
    @Test
    public void whenAdditionTwoNumberThenReturnCorrectAnswer() {

        assertEquals( 5, calculadora.addition(2,3));
    }
    @Test
    public void whenDivisionThenReturnCorrectAnswer() {
        assertEquals(2, calculadora.division(8, 4));
    }
    @Test
    public void whenDivisionByZeroThenThrowException() {
        Throwable exception = assertThrows(IllegalArgumentException.class, () -> {
            calculadora.division(5, 0);
        });
        assertEquals("No se puede divisor por cero", exception.getMessage());
    }
    @Test
    public void whenMultiplicationBThenThrowReturnCorrectAnswer() {
        assertEquals(32, calculadora.multiplication(8, 4));
    }
    @Test
    public void whenSquareRootThenThrowReturnCorrectAnswer() {
        assertEquals(4, calculadora.squareRoot(16));
    }
    //PRUEBA CUANDO LA RAIZ CUADRADA ES DE UN NUMERO NEGATIVO
    @Test
    public void whenSquareRootThenThrowException() {
        Throwable exception = assertThrows(IllegalArgumentException.class, () -> {
            calculadora.squareRoot(-5);
        });
        assertEquals("No se puede operar la raiz cuadrada a un numero negativo", exception.getMessage());
    }
    @Test
    public void whenDFactorialThenReturnCorrectAnswer() {
        assertEquals(120, calculadora.factorial(5));
    }
    //PRUEBA CUANDO ES EL FACTORIAL DE UN NUMERO NEGATIVO
    @Test
    public void whenDFactorialThenThrowException() {
        Throwable exception = assertThrows(IllegalArgumentException.class, () -> {
            calculadora.factorial(-5);
        });
        assertEquals("No se puede operar el factorial a un numero negativo", exception.getMessage());
    }

}

