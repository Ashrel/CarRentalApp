
var makeId = $('makes').val();

$('#makes').change(function () {
    makeId = $(this).val();
    $('#models').html('<option>Select Model<\option>');
    LoadModels();
    
});
function LoadModels() {
    $.getJSON('/Cars/Create?handler=CarModels', { makeId: makeId }, function (date) {
        $.each(data, function (key, value) {
            var option = $('<option><\option>').attr('value', value.id).text(value.name);
            $('#models').append(option);
        });
    });
}