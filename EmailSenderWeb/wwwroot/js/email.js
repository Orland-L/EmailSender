document.addEventListener('DOMContentLoaded', function () {
    document.getElementById("sendEmailForm").addEventListener("submit", function (event) {
        event.preventDefault();
        const note = document.getElementById("note");
        note.className = "alert alert-info fade show";
        note.innerHTML = "Sending email now...";
        fetch("/api/Email", {
            method: "POST",
            body: new FormData(this)
        })
            .then(res => {
                switch (res.status) {
                    case 200: break;
                    case 400: throw new Error("Form data is invalid, please make sure the fields recipient, subject and body are entered properly.");
                    case 401: throw new Error("Authentication failed, please check the appsettings to see if email server information has been entered correctly.");
                    case 408: throw new Error("Request Timeout, please try again later to see if the network connection issue persists.");
                    default: throw new Error("Internal Server Error, please try again or check the email log file if the issue persists.");
                }
            }).then(data => {
                note.className = "alert alert-success fade show";
                note.innerHTML = "Email Sent successfully to recipient! This page will refresh in 5 seconds.";
                setTimeout(function () {
                    window.location.reload();
                }, 5000);
            }).catch(error => {
                note.className = "alert alert-danger fade show";
                note.innerHTML = error;
            });
    });
});