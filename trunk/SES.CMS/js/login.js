//// Login Form

//$(function() {
//    var button = $('#loginButton');
//    var box = $('#login_box');
//    var form = $('#loginForm');
//    button.removeAttr('href');
//    button.mouseup(function(login) {
//        box.toggle();
//        button.toggleClass('active');
//    });
//    form.mouseup(function() { 
//        return false;
//    });
//    $(this).mouseup(function(login) {
//        if(!($(login.target).parent('#loginButton').length > 0)) {
//            button.removeClass('active');
//            box.hide();
//        }
//    });
//});

var mouse_is_inside = false;

$(document).ready(function() {
    $(".login_btn").click(function() {
        var loginBox = $("#login_box");
        if (loginBox.is(":visible"))
            loginBox.fadeOut("fast");
        else
            loginBox.fadeIn("fast");
        return false;
    });

    $("#login_box").hover(function() {
        mouse_is_inside = true;
    }, function() {
        mouse_is_inside = false;
    });

    $("body").click(function() {
        if (!mouse_is_inside) $("#login_box").fadeOut("fast");
    });
});

$('input:text').focus(function() {
    if ($(this).val() === $(this).attr('placeholder')) {
        $(this).val('');
    }
}).blur(function() {
    if ($(this).val() == "") {
        $(this).val($(this).attr('placeholder'))
    }
}
);