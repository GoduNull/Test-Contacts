function validate() {

    var form = document.querySelector('.myform');
    var name = form['Name'];
    var phone = form['MobilePhone'];
    var job = form['JobTitle'];
    var bri = form['BirthDate'];
    removeValidation(form);

    var fields = form.querySelectorAll('.field');
    var check = true;
    for (var i = 0; i < fields.length; i++) {
        if (!fields[i].value) {
            var error = generateError('Cant be blank');
            form[i].parentElement.insertBefore(error, fields[i]);
            check = false;
        }
    };
    if (!check) {
        return false;
    }
    if (nameValid(name, form) & phoneValid(phone, form) &
        lengthValid(name, form) & lengthValid(job, form) & validateDate(bri, form)) {
        return true;
    }
    return false;
};

var phoneValid = function (element, form) {
    let regex = /^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$/;
    if (!regex.test(element.value)) {
        var error = generateError('Invalid date format, +375** *** ** **');
        element.parentElement.insertBefore(error, element);
        return false;
    } else {
        return true;
    }
};
var nameValid = function (element, form) {
    let regex = /^[А-яа-яA-Za-zЁё ]+$/;
    if (!regex.test(element.value)) {
        var error = generateError('Name can only contain letters');
        element.parentElement.insertBefore(error, element);
        return false;
    } else {
        return true;
    }
};

var lengthValid = function (element, form) {
    if (element.value.length > 50) {
        var error = generateError('The field can\'t contain more than 50 symbols');
        element.parentElement.insertBefore(error, element);
        return false;
    } else {
        return true;
    }
};

var generateError = function (text) {
    var error = document.createElement('div')
    error.className = 'error';
    error.style.color = 'red';
    error.innerHTML = text;
    return error;
};
var removeValidation = function (form) {
    var errors = form.querySelectorAll('.error');

    for (var i = 0; i < errors.length; i++) {
        errors[i].remove();
    }
};

var validateDate = function (element, form) {
    var aTmp = element.value.split("-");
    var year = new Date().getFullYear();
    if ((parseInt(aTmp[0]) <= 1990) || (parseInt(aTmp[0]) >= year)) {
        var error = generateError('Date in the range 1990-' + (year - 1));
        element.parentElement.insertBefore(error, element);
        return false;
    }
    else {
        return true;
    }
};