// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function updateForm(volunteerName) {
    document.getElementById("volunteer_display").innerHTML = "Volunteer Profie goes here . . . "
}

function confirmDeleteProfile() {
    var r = confirm("Are you sure you want to Delete Volunteer Profile?");
    if (r == true) {
        alert ("Volunteer Profile is been deleted!");
        window.location.replace("./VolunteerManagement");
        return true;
    }
    else {
        return false;
    }
}



function confirmCancelEditVolunteerProfile() {
    var r = confirm("Are you sure you want to Cancel? all changes will be discarded?");
    if (r == true) {
        window.location.replace("./VolunteerManagement");
        return true;
    }
    else {
        return false;
    }
}


function confirmCancelSaveVolunteerProfile() {
    var r = confirm("Are you sure you want to Save Changes?");
    if (r == true) {
        alert ("Changes Volunteer Profile saved!");
        window.location.replace("./VolunteerManagement");
        return true;
    }
    else {
        return false;
    }
}