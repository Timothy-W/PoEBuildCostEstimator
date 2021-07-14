


$(document).ready(() => {
    $('#MyButton').click(() => GetFeedback());
});

async function GetFeedback() {
    
    Swal.fire({
        text: "Please submit feedback to toxxindev@gmail.com",
        confirmButtonColor: '#f89406',
    });
    
    //const { value: text } = await Swal.fire({
    //    input: 'textarea',
    //    inputLabel: 'Feedback',
    //    inputPlaceholder: 'Type your feedback here...',
    //    inputAttributes: {
    //        'aria-label': 'Type your message here'
    //    },
    //    confirmButtonText: 'Submit',
    //    showCancelButton: true
    //});

    //if (text) {
    //    Swal.fire({
    //        text: "Feedback submitted, thank you!",
    //    });
    //}
}

async function SubmitFeedback() {



}
