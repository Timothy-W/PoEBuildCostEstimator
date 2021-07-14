

$('#pastebinUrlInputForm').on('input', function () {

    if ($('#pastebinUrlInputForm').val() != "") {
        $('#pastebinSubmitButton').text('Go');

    } else {
        $('#pastebinSubmitButton').text('Test');
    }
});

$('#pastebinSubmitButton').click(function () {

    if ($('#pastebinUrlInputForm').val() == "") {
        $('#pastebinUrlInputForm').val('https://pastebin.com/7nhJbxk4');
    }
});

