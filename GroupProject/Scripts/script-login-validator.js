$(document).ready(function () {
    $('#loginFormID').validate({
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {
            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'UserName': {
                required: true,
                //minlength: 3
            },

            'Password': {
                required: true,
                //minlength: 3
            },
            /*
            'ConfirmPassword': {
                required: true,
                equalTo: '#Password'
            }*/
        },
        messages: {
            'UserName': {
                required: 'Please enter username'
            },

            'Password': {
                required: 'Please enter password'
            },
            /*
            'ConfirmPassword': {
                required: 'Please provide a password',
                minlength: 'Your password must be at least 6 characters long',
                equalTo: 'Please enter the same password as above'
            }
            */
        }
    });

    $('#registerFormID').validate({
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {
            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'FirstName': {
                required: true,
                minlength: 3
            },

            'LastName': {
                required: true,
                minlength: 3
            },

            'UserName': {
                required: true,
                minlength: 3
            },

            'Email': {
                required: true,
                email: true
            },

            'Password': {
                required: true,
                minlength: 3
            },            
            
            'ConfirmPassword': {
                required: true,
                equalTo: '#Password'
            }
        },
        messages: {
            'FirstName': {
                required: 'Please provide first name',
                minlength: 'Fist name must contains least 3 characters'
            },

            'LastName': {
                required: 'Please provide your last name',
                minlength: 'Last name must contains least 3 characters'
            },

            'UserName': {
                required: 'Please provide a username',
                minlength: 'Username must contains least 3 characters'
            },

            'Email': {
                required: 'Please provide your email',
                emai: 'Invalid email address'
            },

            'Password': {
                required: 'Please provide a password',
                minlength: 'Password must contains least 3 characters'
            },
            
            'ConfirmPassword': {
                required: 'Please provide a password',
                minlength: 'Your password must contains at least 3 characters',
                equalTo: 'Please enter the same password as above'
            }
        }
    });
});
