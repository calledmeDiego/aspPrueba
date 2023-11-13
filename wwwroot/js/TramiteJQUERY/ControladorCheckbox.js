$(function () {
    $('.checkboxservices2').on('change', function () {

        manejarCasosEspeciales();
    });
    manejarCasosEspeciales();

    function manejarCasosEspeciales() {
        let checkedCheckboxes = $('.checkboxservices2:checked');

        if (checkedCheckboxes.length > 0) {
            var allowedValues = [5, 6, 8, 10, 12];
            checkedCheckboxes.each(function () {
                let currentValue = parseInt($(this).val());

                if (allowedValues.includes(currentValue)) {
                    // Marcar los checkboxes con valor 1, 3 y 4
                    $('[value="1"], [value="3"], [value="4"]').prop('checked', true);
                    $('.checkboxservices2').not(':checked, [value="2"], [value="11"]').prop('disabled', true);
                }
                else {
                    // Desmarcar checkboxes con valor 1 y 3
                    $('[value="1"], [value="3"]').prop('checked', false);
                }
            });
            //var valoresSimples = [2, 4, 7, 9];
            //if (valoresSimples.includes(currentValue)) {
            //    console.log('Es un valor especial: ' + currentValue);
            //    $('.checkboxservices2').not(':checked ,[value="2"], [value="4"], [value="11"]').prop('checked', false).prop('disabled', true);

            //}
            //Agrega más casos según sea necesario
        }
        else {
            $('.checkboxservices2').prop('checked', false).prop('disabled', false);
        }
        console.log("funcion filtrado casos especiales checkboxes");

    }
})  