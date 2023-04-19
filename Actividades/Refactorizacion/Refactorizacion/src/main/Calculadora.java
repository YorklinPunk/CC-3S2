package main;

import org.junit.jupiter.api.BeforeAll;

public class Calculadora {
    private boolean status;
    public boolean getStatus() {
        return status = true;
    }
    public int addition(int a, int b) {
        return a + b;
    }
    public int division(int a, int b) {
        if (b == 0) {
            throw new IllegalArgumentException("No se puede divisor por cero");
        } else {
            return a / b;
        }
    }
    public int multiplication(int a, int b) {
        return a * b;
    }
    public double squareRoot(int a) {
        if (a < 0) {
            throw new IllegalArgumentException("No se puede operar la raiz cuadrada a un numero negativo");
        } else {
            return Math.sqrt(a);
        }
    }
    public int factorial (int a) {
        if (a < 0) {
            throw new IllegalArgumentException("No se puede operar el factorial a un numero negativo");
        } else {
            if (a==0){
                return 1;
            }
            else{
                return a * factorial(a-1);
            }
        }
    }
}


