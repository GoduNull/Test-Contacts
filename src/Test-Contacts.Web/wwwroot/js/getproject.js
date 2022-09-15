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
