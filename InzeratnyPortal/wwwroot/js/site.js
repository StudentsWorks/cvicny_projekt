// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//

function confirmDelete(id, clickedDelete) {
    var deleteSpan = "del_" + id;
    var confirmDeleteSpan = "cfm-del_" + id;

    if (clickedDelete) {
        $("#" + deleteSpan).hide();
        $("#" + confirmDeleteSpan).show();
    }
    else {
        $("#" + deleteSpan).show();
        $("#" + confirmDeleteSpan).hide();
    }
}
