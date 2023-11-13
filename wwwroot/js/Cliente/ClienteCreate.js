$(document).ready(function () {
    // Funciones relacionadas con el primer conjunto de elementos
    $(".numeroInput").on("input", function () {
        var maxLength = 10;
        if ($(this).val().length > maxLength) {
            $(this).val($(this).val().slice(0, maxLength));
        }
    });

    // Evento de cambio para el elemento con el ID 'TipoCliente'
    $('#TipoCliente').on("change",function () {
        // Llama a la función habilitarCarnet cuando cambia el valor de '#TipoCliente'
        habilitarCarnet();
    });

    // Evento de cambio para el checkbox con el ID 'habilitarCampoExtranjero'
    $('#habilitarCampoExtranjero').on("change",function () {
        // Llama a la función cambiarCampos cuando cambia el estado del checkbox
        cambiarCampos();
    });

    // Definición de la función cambiarCampos
    function cambiarCampos() {
        // Obtener el estado del checkbox con el ID 'habilitarCampoExtranjero'
        var useAlternative = $('#habilitarCampoExtranjero').prop('checked');

        // Mostrar u ocultar los campos según el estado del checkbox
        if (useAlternative) {


            $('#camposNacional').hide();
            $('#camposExtranjero').show();
            $('#lblPasaporteExtranjero').show();
            $('#lblDNINacional').hide();
        } else {
            $('#camposNacional').show();
            $('#camposExtranjero').hide();
            $('#lblPasaporteExtranjero').hide();
            $('#lblDNINacional').show();


        }
    }

    // Definición de la función habilitarCarnet
    function habilitarCarnet() {
        // Obtener el valor del elemento con el ID 'TipoCliente'
        var tipoCliente = $('#TipoCliente');
        // Obtener el contenedor con el ID 'carnetContainer'
        var carnetContainer = $('#carnetContainer');

        // Cambiar la propiedad de estilo 'display' según el valor de 'TipoCliente'
        carnetContainer.toggle(tipoCliente.val() === "2");
        habilitarFechaRegistro();
    }
    function habilitarFechaRegistro() {
        var tipoCliente = $('#TipoCliente');
        var fechaRegistro = $('#FechaRegistro'); // Reemplaza 'FechaRegistro' con el ID real de tu campo de fecha

        // Habilitar la fecha de registro si el tipo de cliente es "2", de lo contrario, deshabilitarla
        fechaRegistro.prop('disabled', tipoCliente.val() !== "2");
    }

    // Llamar a la función habilitarCarnet al cargar la página
    habilitarCarnet();


});