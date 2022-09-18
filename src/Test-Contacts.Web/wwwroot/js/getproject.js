$(function () {

    //Optional: turn the chache off
    $.ajaxSetup({ cache: false });

    $('#btnCreate').click(function () {
        $('#dialogContent').load(this.href, function () {
            $('#dialogDiv').modal({
                backdrop: 'static',
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });
});
function bindForm(dialog) {
    $('form', dialog).submit(function () {
        if (validate()) {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $('#dialogDiv').modal('hide');
                    } else {
                        $('#dialogContent').html(result);
                        bindForm();
                    }
                }
            });
            return false;
        }
        else {
            return false;
        }
    });
};
let contactId;
const menuList = document.querySelector(".right-menu");
function menu(event) {
    event = event || window.event;
    event.cancelBubble = true;
    menuList.style.top = (event.clientY+10) + 'px';
    menuList.style.left = (event.clientX+15) + 'px';
    menuList.classList.add("right-menu-active");
    contactId = (event.target.id) || event.target.parentNode.id;
    return false;
}
$(document).on('click', function () {
    menuList.classList.remove("right-menu-active");
});
menuList.addEventListener("click", event => {
    event.stopPropagation();
});
$('#delete').click(function () {
    if (confirm("Удалить контакт?")) {
        $.ajax({
            url: "/Project/DeleteProject",
            type: "Post",
            data: { contactId },
            success: function (result) {
            },
            statusCode: {
                200: function () {
                    alert('Проект удален');
                    location.reload();
                },
                400: function () {
                    alert('Не получилось');
                    location.reload();
                }
            }
        });
    };
});
$('#update').click(function () {
    if (confirm("Изменить контакт?")) {
        $('#dialogContent').load("/Home/UpdateModalWindow", { id: contactId }, function () {
            $('#dialogDiv').modal({
                backdrop: 'static',
                keyboard: true
            }, 'show');
            bindForm(this);
        });
    };
});
