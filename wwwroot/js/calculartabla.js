$(document).ready(function () {
    // Calcular automáticamente los subtotales al cargar la página
    var cantidadesString = [];
    $('.cantidadServicio').each(function () {
        calcularSubTotal($(this).attr('id').replace('cantidad', ''));
        var cantidad = parseFloat($(this).val()) || 0;
        cantidadesString.push(cantidad);
    });
    obtenerCantidades();
     
    function obtenerCantidades() {
        // Crear un array para almacenar las cantidades como strings
        var cantidadesString = [];

        // Obtener todos los valores de las cantidades y formatearlos como strings
        $('.cantidadServicio').each(function () {
            var cantidad = parseFloat($(this).val()) || 0;
            cantidadesString.push(cantidad.toString());
        });

        // Unir las cantidades en una cadena separada por comas
        var cantidadesStringFinal = cantidadesString.join(' ');
        $('#campoCantidades').val(cantidadesStringFinal);     
        // Devolver la cadena formateada con las cantidades
        
    }

    // Calcular y mostrar el total al cargar la página
    calcularTotal();

    // Asignar eventos a los botones de incremento y decremento
    $('.btn-number').on('click',function (e) {
        e.preventDefault();
        
        let fieldName = $(this).attr('data-field');
        let type = $(this).attr('data-type');
        let input = $('#' + fieldName);
        let currentVal = parseFloat(input.val());

        if (!isNaN(currentVal)) {
            if (type === 'minus') {
                input.val(Math.max(currentVal - 1, 1));

                // No permitir valores negativos ni cero
            } else if (type === 'plus') {
                input.val(Math.max(currentVal + 1, 1));
                // No permitir valores negativos ni cero
            }
            obtenerCantidades();
                       // Calcular el subtotal al cambiar la cantidad
            calcularSubTotal(fieldName.replace('cantidad', ''));
            
            // Calcular y mostrar el total
            calcularTotal();
        } else {
            input.val(1);
        }
    });

    // Asignar un evento input a cada input de cantidad
        //$('.cantidadServicio').on('input', function () {
        //    let currentVal = parseFloat($(this).val());

        //    if (!isNaN(currentVal)) {
        //        $(this).val(Math.max(currentVal, 0)); // No permitir valores negativos
        //    } else {
        //        $(this).val(0);
        //    }

        //    // Calcular el subtotal al cambiar la cantidad
        //    calcularSubTotal($(this).attr('id').replace('cantidad', ''));
        //    // Calcular y mostrar el total
        //    calcularTotal();

        
        //});
});

function calcularSubTotal(idServicio) {
    // Obtener el valor de la cantidad y convertirlo a decimal
    let cantidad = parseFloat($('#cantidad' + idServicio).val()) || 0;

    // Obtener el precio del servicio y convertirlo a decimal
    let precio = parseFloat($('#subTotalService' + idServicio).closest('tr').find('.precioServicio').val()) || 0;

    // Calcular el subtotal y actualizar el campo de subtotal en el mismo tr
    let subTotal = cantidad * precio;
    $('#subTotalService' + idServicio).val(subTotal.toFixed(2));
    console.log(subTotal);
}

function calcularTotal() {
    // Obtener todos los subtotales y sumarlos
    let total = 0;
    let subtotalesString = [];

    $('.subTotalServicio').each(function () {
        total += parseFloat($(this).val()) || 0;
        let subtotal = parseFloat($(this).val()) || 0;
        subtotalesString.push(subtotal.toFixed(2));
    });
    console.log("funcion calculartotal")
    console.log(total.toFixed(2));
    // Actualizar el campo de total
    $('#totalServices').val(total.toFixed(2));

    let totalString = subtotalesString.join(' ');

    $('#campoSubtotales').val(totalString);
}

