$(function () {

    $('#btnContinuar').on('click', function () {
        operacionGuardarServicio();
    })
    $('#tipoProcedimiento').on('change', function () {
        limpiarSelectionTipo();
        configurarFiltrado1();
    });

    $('#tipoCliente').on('change', function () {
        limpiarSelectionCliente();
        filtradoTipoCliente();
    });
    configurarFiltrado1();
    filtradoTipoCliente();
    operacionGuardarServicio();
    function configurarFiltrado1() {
        var selectedProcedure = $('#tipoProcedimiento').val();

        // Show or hide the second selector based on the selected value
        if (selectedProcedure === '0' || selectedProcedure === '1') {
            $('#segundoSelector').show();
        } else {
            $('#segundoSelector').hide();
        }
        console.log("funcion filtrado tipo procedimiento:" + selectedProcedure);
    }

    function filtradoTipoCliente() {
        //var selectedProcedure = $('#tipoProcedimiento').val();
        var selectedClient = $('#tipoCliente').val();
        // Show or hide additional fields based on the selected options

        console.log(selectedClient+ "seleccionadddoasoaos");
        if ($('#tipoProcedimiento option:selected').length > 0 && selectedClient === '1') {
            $('#btnServicios').show();

        } else {
            // Reset and hide additional fields
            $('.escritura_fields').hide();
        }

        console.log("funcion filtrado tipo cliente");
    }
    function limpiarSelectionTipo() {

        // Reset the second selector and hide additional fields when changing the first selector
        $('#tipoCliente').val('');
        $('#segundoSelector').hide();

        limpiarSelectionCliente();
        console.log("funcion limpieza completo");

    }
    function limpiarSelectionCliente() {

        $('.escritura_fields').hide();
        $('#btnServicios').hide();
        $('#camposPrincipales').hide();

        $('.checkboxservices2').prop('checked', false).prop('disabled', false);
        $('.partidas_fields').val('');
        $('.escritura_fields').val('');
        $('.tramiteinvestigador').hide();

        $('.tramiteinvestigadorintermedio').hide();
        $('.tramiteinvestigadorhistorico').hide();
        /*$("#selectedValuesContainer").text('');*/
        console.log("funcion limpieza datos cliente");
    }

    function operacionGuardarServicio() {
        let checkedCheckboxes = $('.checkboxservices2:checked');
        let selectedValues = checkedCheckboxes.map(function () {
            return parseInt($(this).val());
        }).get();
        if (checkedCheckboxes.length > 0) {
            // Mostrar los campos "partidas_fields" si 8 está presente junto con otros valores
            $('.partidas_fields').toggle(selectedValues.includes(8) && selectedValues.length > 1);

            // Mostrar los campos "escritura_fields" si 8 NO está presente
            $('.escritura_fields').toggle(!selectedValues.includes(8));
            console.log("seleccion 8");
            // Puedes agregar más lógica para otros campos según tus necesidades
        } else {
            // Ocultar todos los campos si no hay ningún checkbox seleccionado
            $('.partidas_fields, .escritura_fields').hide();
        }
        console.log(selectedValues);
        console.log("funcion guardado de servicios" + selectedValues);
    }
})