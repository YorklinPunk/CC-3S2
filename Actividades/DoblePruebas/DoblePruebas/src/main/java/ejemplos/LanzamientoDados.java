package ejemplos;
import java.util.random.RandomGenerator;
public class LanzamientoDados {
    private final int NUMERO_LADOS = 6;

    private final NumerosAleatorios rnd;
    public LanzamientoDados(NumerosAleatorios r){ //SE AGREGÓ UN CONSTRUCTOR
        this.rnd = r;
    }
    //private final RandomGenerator rnd = RandomGenerator.getDefault();

    // Completa
    public String asText() {
        int lanzado = rnd.nextInt(NUMERO_LADOS) + 1;

        return String.format("Sacastes un %d", lanzado);
    }
}
