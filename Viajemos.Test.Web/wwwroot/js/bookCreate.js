var authors = [];
var editorial = {};
const BASEURL = "https://localhost:5001";
const ENDPOINT = "/api/v1/authors";
$('.form-button--primary').click(function () {
    getAuthors();
    cleanInputs();
    $('.createModal').modal();
}) ;

function getAuthors() {
    $.ajax({
        url: `${BASEURL}${ENDPOINT}`,
        method: 'GET',
        type:'json',
        success: function (result)
        {
            $("#selectAuthors").empty();
            $("#selectAuthors").append('<option>seleccione</option>')
            result.forEach(it => $("#selectAuthors").append(`<option value=${it.id}>${it.name} ${it.lastName} </option>`));
        }
    })
}

$("#selectAuthors").change(function () {
    $("#id").val($('option:selected', this).val());
    $("#name").val($('option:selected', this).text().split(' ')[0]);
    $("#lastname").val($('option:selected', this).text().split(' ')[1]);
});

$('#cleanSelect').click(function () {
    $("#selectAuthors").prop('disabled', true);
    $("#name").prop('disabled', false);
    $("#lastname").prop('disabled', false)
});

function cleanInputs()
{
    $('#id').val('');
    $('#name').val('');
    $('#lastname').val('');
}

$('#addAuthor').click(function (event) {
    event.preventDefault();
    if ($('#name').val() == '' || $('#lastname').val() == '')
    {
        $('.error-text').text('Nombre y apellido son obligatorios!');
        $('.error').css("display", "block");
        $('.createModal').modal();
        return;
    }

    var object = {
        guid: jQuery.guid++,
        id: $("#id").val(),
        name: $("#name").val(), 
        lastname: $("#lastname").val()
    };
   
    authors.push(object);
    $('.authors').append(`<tr class="data"><td>${object.name}</td><td>${object.lastname}</td><td><button class="button-delete" data="${object.guid}" onclick="clickOnDelete(this)">x</td></tr>`);
    $('.success-text').text('Autor agregado correctamente!');
    $('.error').css("display", "none");
    $('.success').css("display", "block");
    cleanInputs();
    $('.createModal').modal();
});

$('.form-button--cancel').click(function () {
    $('.createModal').modal('hide');
}); 

$('.editorial').change(function () {
    editorial = {
        id: $('option:selected', this).val(),
        name: $('option:selected', this).text().split('-')[0],
        campus: $('option:selected', this).text().split('-')[1],
    }
})

$("#formBook").submit(function (event) {
    event.preventDefault();
    var form = $(this).serializeArray();
    form.push({ name: "Authors", value: authors });
    form.push({ name: "Editorial", value: editorial });
    var data = form.reduce((map, obj) => {
        map[obj.name] = obj.value;
        return map;
    },{});

    $.ajax({
        method: 'POST',
        url: '/Book/Create',
        data: data,
        success: function () {
            location.href = '/Book/Index'
        },
        error: function (error) {
            $('.error').css('display', 'block');
            $('.error').text(error.responseText);
        }
    })
});

function clickOnDelete(e) {
    cleanInputs();
    var guid = e != undefined ? e.getAttribute("data"): 0;
    var filter = authors.filter(it => it.guid != guid);
    authors = filter;
    var result = filter.map(it => `<tr class="data"> <td>${it.name}</td><td>${it.lastname}</td><td><button class="button-delete" data="${it.guid}" onclick="clickOnDelete(this)">x</td></tr>`);
    $('.authors tr.data').remove();
    result.forEach(it => $(".authors").append(it));
}