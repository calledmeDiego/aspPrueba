$(document).ready(function () {
    $('#btnContinuar').on('click', function () {
        mostrarValoresSeleccionados();

    })
    mostrarValoresSeleccionados();

    function mostrarValoresSeleccionados() {
        let checkedCheckboxes = $('.checkboxservices2:checked');
        let selectedValues = checkedCheckboxes.map(function () {
            return parseInt($(this).val());
        }).get();
        console.log("sehizo click");
        $.ajax({
            type: "POST",
            url: "/Tramite/ActualizarContenedor", // Asegúrate de que la ruta sea correcta
            data: { serviciosSeleccionados: selectedValues },
            success: function (data) {
                // Actualizar el contenedor con la respu esta de la vista parcial
                $("#vistaParcialContainer").html(data);

            },
            error: function (error) {
                console.error("Error en la solicitud AJAX", error);
            }
        });
        let selectedValuesString = selectedValues.join(' ');

        // Asignar la cadena al campo oculto
        $("#SelectedServiceIdsHidden").val(selectedValuesString);

        //$.ajax({
        //    url: '/Tramite/ActualizarSelectedServiceIds',
        //    type: 'POST',
        //    data: { selectedServiceIds: selectedValues },
        //    success: function (data) {
        //        // Manejar la respuesta del servidor si es necesario
        //    },
        //    error: function () {
        //        // Manejar errores si es necesario
        //    }
        //});
    }

});