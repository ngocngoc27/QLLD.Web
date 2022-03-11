// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
        }
    })
}


JQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#view-all").html(res.html);
                    $("#form-modal .modal-body").html('');
                    $("#form-modal .modal-title").html('');
                    $("#form-modal").modal('hide');
                    $.notify('submitted successfully', { globalPosition: 'top center', className: 'success' })
                    window.location.reload();

                }
                else
                    $("#form-modal .modal-body").html(res.html);
            },
            error: function (err) {
                console.log(err);
            }
        })



    } catch (e) {
        console.log(e);
    }

    //to prevent submit form event
    return false;
}


JQueryAjaxDelete = form => {
    if (confirm('Are you sure to delete this record?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $("#view-all").html(res.html);
                    $.notify('delete successfully', { globalPosition: 'top center', className: 'success' })
                    window.location.reload();
                },
                error: function (err) {
                    console.log(err);
                }
            })


        } catch (e) {
            console.log(e);
        }
    }
    //to prevent submit form event
    return false;
}