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
                    /*$.notify('submitted successfully', { globalPosition: 'top center', className: 'success' })*/
                    Command: toastr["success"]("Thực hiện thành công")

                    toastr.options = {
                        "closeButton": true,
                        "debug": false,
                        "newestOnTop": true,
                        "progressBar": true,
                        "positionClass": "toast-top-right",
                        "preventDuplicates": true,
                        "onclick": null,
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "extendedTimeOut": "1000",
                        "showEasing": "swing",
                        "hideEasing": "linear",
                        "showMethod": "fadeIn",
                        "hideMethod": "fadeOut"
                        
                    };
                    setTimeout("window.location.reload()", 3000);

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
    if (confirm('Dữ liệu có thể sẽ không được phục hồi! Bạn có chắc muốn xóa?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $("#view-all").html(res.html);
                    Command: toastr["success"]("Xóa thành công")

                    toastr.options = {
                        "closeButton": true,
                        "debug": false,
                        "newestOnTop": true,
                        "progressBar": true,
                        "positionClass": "toast-top-right",
                        "preventDuplicates": true,
                        "onclick": null,
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "extendedTimeOut": "1000",
                        "showEasing": "swing",
                        "hideEasing": "linear",
                        "showMethod": "fadeIn",
                        "hideMethod": "fadeOut"

                    };
                    setTimeout("window.location.reload()", 3000);
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
$(document).ready(function () {
    $('#example').DataTable();
});
function previewFile(input) {
    const [file] = input.files
    const preview = document.getElementById('preview')
    const reader = new FileReader()

    reader.onload = e => {
        const img = document.createElement('img')
        img.src = e.target.result
        img.width = 100
        img.height = 100
        img.alt = 'file'

        preview.appendChild(img)
    }
    reader.readAsDataURL(file)
}
function changeImage() {
    document.getElementById('myImage').style.display = "none";
}

