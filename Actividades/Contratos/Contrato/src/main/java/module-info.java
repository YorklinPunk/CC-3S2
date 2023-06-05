module com.example.contrato {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.example.contrato to javafx.fxml;
    exports com.example.contrato;
}