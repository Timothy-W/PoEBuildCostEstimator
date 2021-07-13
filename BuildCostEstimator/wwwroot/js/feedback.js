


$(document).ready(() => {
    $('#MyButton').click(() => GetFeedback());
});

async function GetFeedback() {
    const { value: text } = await Swal.fire({
        input: 'textarea',
        inputLabel: 'Feedback',
        inputPlaceholder: 'Type your feedback here...',
        inputAttributes: {
            'aria-label': 'Type your message here'
        },
        confirmButtonText: 'Submit',
        showCancelButton: true
    });

    if (text) {
        Swal.fire({
            text: "Feedback submitted, thank you!",
        });
    }
}
