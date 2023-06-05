public class TaxCalculator {
    public double calculateTax(double value) {
        //PRE CONDICION value < 0
        // VALOR  DE ENTRADA VALUE MAYOR QUE O IGUAL QUE 0
        if (value < 0) {
            throw new RuntimeException("...");
        }
        double taxValue = 0;

        //POST CONDICION 
        //VALOR DE RETORNO DEL PROGAMA DEVUELVE UN DOUBLE MAYOR O IGUAL QUE 0
        if(taxValue < 0) {
            throw new RuntimeException("...");
        }
        return taxValue;

    }
}
