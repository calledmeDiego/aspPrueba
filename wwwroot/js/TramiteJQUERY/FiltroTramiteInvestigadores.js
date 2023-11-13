
$(function () {
    $('#tipoCliente').on('change', filtrado);
});
function filtrado() {
    const CLIENTE_INVESTIGADOR = '2';
    const PROCEDIMIENTO_INTERMEDIO = '0';
    const PROCEDIMIENTO_HISTORICO = '1';
    let selectedProcedure = $('#tipoProcedimiento').val();
    let selectedClient = $('#tipoCliente').val();
    // Show or hide additional fields based on the selected options

    if (selectedClient === CLIENTE_INVESTIGADOR) {
        $('.tramiteinvestigador').toggle(selectedProcedure === '0' || selectedProcedure === '1');
        if (selectedProcedure === PROCEDIMIENTO_INTERMEDIO) {
            $('.tramiteinvestigadorintermedio').show();

        }
        else {
            $('.tramiteinvestigadorintermedio').hide();
        }
        if (selectedProcedure === PROCEDIMIENTO_HISTORICO) {
            $('.tramiteinvestigadorhistorico').show();
        }
        else {
            $('.tramiteinvestigadorhistorico').hide();

        }

    }
}
    
