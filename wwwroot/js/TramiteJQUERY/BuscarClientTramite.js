$(document).ready(function () {
    $("#buscarCliente").on('click', function () {
        buscarClient();
    });
    if (parseInt($("#idTramiteDocumentario").val()) > 0) {
        buscarClient();
    }
    //buscarClient();
    console.log("buscamos cliente");
    function buscarClient() {
        let numeroIdentificacion = $("#numeroIdentificacion").val();
        console.log("el numero es:" + numeroIdentificacion);
        $.ajax({
            type: "GET",
            url: "/Tramite/BuscarCliente",
            data: { numeroIdentificacion: numeroIdentificacion },
            success: function (result) {
                if (result.success) {
                    let nombreClienteEncontrado = result.nombre; // Reemplaza con el nombre real
                    let apellidoClienteEncontrado = result.apellido;

                    // Asignar el nombre del cliente al campo de texto usando jQuery
                    $("#nombreCliente").val(nombreClienteEncontrado + " " + apellidoClienteEncontrado);

                    $("#idCliente").val(result.id);
                    console.log("funcion buscar cliente:" + nombreClienteEncontrado);
                    console.log(result.id);
                    // Cliente encontrado, muestra la información o realiza otras acciones
                    alertSuccess("Cliente encontrado.");

                } else {
                    // Cliente no encontrado, muestra un mensaje de alerta
                    alertError(result.message);
                    $("#nombreCliente").val("");
                    $("#idCliente").val("");
                }
            },
            error: function () {
                // Manejar errores de la solicitud AJAX si es necesario
                alert("Error en la búsqueda del cliente.");
            }
        });
    }
    function alertSuccess(mensaje) {
        $(".alert-container").html('<div class="alert alert-success alert-dismissible fade show" role="alert">' + mensaje + '</div>');
        setTimeout(function () {
            $(".alert").alert('close');
        }, 3000);
    }

    function alertError(mensaje) {
        $(".alert-container").html('<div class="alert alert-danger alert-dismissible fade show" role="alert">' + mensaje + '</div>');
        setTimeout(function () {
            $(".alert").alert('close');
        }, 3000);
    }
    function cargarVistaParcial(partialView, data) {
        // Realizar una nueva llamada AJAX para cargar la vista parcial
        $.get("/Home/CargarVistaParcial", { partialView: partialView, data: data }, function (result) {
            // Insertar la vista parcial en el contenedor de alertas
            $("#alert-container").html(result);
        });
    }
});