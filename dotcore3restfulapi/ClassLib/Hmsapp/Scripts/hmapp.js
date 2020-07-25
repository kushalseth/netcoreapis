$(document).ready(function () {
    debugger;

    $("#register-submit").click(function () {

        $("#js-hms-loader").show();
        var register_form = $("#register-form");
        var _model = {
            Email: register_form.find("#email").val(),
            UserName: register_form.find("#username").val(),
            Password: register_form.find("#password").val(),
            PhoneNumber: register_form.find("#phonenumber").val(),
            RoleCD: $('input[name=registerList]:checked', '#register-form').val()
        };

        $.ajax({
            url: "/account/register",
            type: 'post',
            data: { model: _model  },
            success: function (data, status, xhr) {
                debugger;
                if (!$.isPlainObject(data)) {
                    data = JSON.parse(data);
                }
                
                if (data && data.result && data.result.Succeeded) {
                    location.href = "/hms/index";
                    $("#js-hms-loader").hide();
                    // For two way authentication
                    //location.href = "/account/SendCode?ReturnUrl='ascas'&rememberMe=true"
                    //$("#js-hms-loader").hide();
                }
                else {
                    console.error(data);
                    
                    alert("Please check console for error");
                }
            },
            error: function (error) {
                debugger;
                console.error(error);
                alert("Please check console for error");
            }
        });
        
    });

    //$("#login-submit").click(function () {
    //    var login_form = $("#login-form");
    //    var _model = {
    //        //Email: login_form.find("#email").val(),
    //        Email: login_form.find("#login-username").val(),
    //        Password: login_form.find("#login-password").val(),
    //        PhoneNumber: login_form.find("#login-phonenumber").val(),
    //        RoleCD: $('input[name=login-form-list]:checked', '#login-form').val()
    //    };

    //    $.ajax({
    //        url: "/account/login",
    //        type: 'post',
    //        data: { model: _model, returnUrl: "/hms/index" },
    //        success: function (data, status, xhr) {
    //            debugger;
                
    //        },
    //        error: function (error) {
    //            debugger;
    //            console.error(error);
    //            alert("Please check console for error");
    //        }
    //    });

    //});
    
});