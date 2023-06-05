import java.math.BigDecimal;
import java.util.HashMap;
import java.util.Map;

public class Bascket {
    private BigDecimal totalValue = BigDecimal.ZERO;
    private Map<Product, Integer> basket = new HashMap<>();

    public void add(Product product, int qtyToAdd) {
        //PRECONDICION
        //VALIDACION PARA LA CANTIDAD SOLICITADA SEA MAYOR QUE 0 O MAYOR DE LO QUE
        //HAY EN ALMACÉN
        assert product != null : "...";
        assert qtyToAdd > 0 : "...";
        BigDecimal oldTotalValue = totalValue;

        assert basket.containsKey(product) : "...";
        assert totalValue.compareTo(oldTotalValue) == 1 : "...";

        //assert totalValue.compareTo(BigDecimal.ZERO) >= 0 :
        //        "...";

        assert invariant() : "El valor total no puede ser negativo .";
        /*AFIRMACION VERDADERA QUE AYUDA AL FUNCIONAMIENTO DEL OBJETO

        VALIDACIÓN DE QUE EL PRODUCTO EXISTA EN EL ALMACEN

        POSTCONDICIO
        AÑADIR OTRA VEZ EL MISMO PRODUCTO SOLO SUMA LA CANTIDAD Y NO SE CREA OTRO
        CAMPO EN LA LISTA DEL CARRITO DE COMPRAS */
    }
    public void remove(Product product) {
        //PRECONDICION
        //QUE EL PRODUCTO A ELIMINAR DEL CARRITO DE COMPRAS EXISTA EN EL CARRITO DE COMPRAS
        assert product != null : "...";
        assert basket.containsKey(product) : "...";
        //POSTCONDICION
        //RETORNA LA NUEVA LISTA DEL CARRITO DE COMPRAS
        assert !basket.containsKey(product) : "...";
        //assert totalValue.compareTo(BigDecimal.ZERO) >= 0 :
        //      "El valor total no puede ser negativo .";

        assert invariant() : "El valor total no puede ser negativo .";
    }

    private boolean invariant() {
        return totalValue.compareTo(BigDecimal.ZERO) >= 0;
    }
}
