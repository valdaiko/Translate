$(function () {
    $("#send").click(function () {
        var valid = true;
        if ($("#username").val() == "") {
            $("#username").next("span.star").show();
            valid = false;
        } else {
            $("#username").next("span.star").hide();
        }

        if ($("#useremail").val() == "") {
            $("#useremail").next("span.star").show();
            valid = false;
        } else {
            $("#useremail").next("span.star").hide();
        }
        if (valid) {
            var message = new FormData($('form')[0]);
            // var message = { username: $("#username").val(), useremail: $("#useremail").val(), usercoment: $("#usercoment").val(), userFile: $("#userfile").val() };
            $.ajax(
                {
                    type: "POST",
                    url: "/order",
                    data: message,
                    dataType: "json",
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (data) {
                        if (data == true) {
                            notify("Ваша заявка принята. Спасибо!");
                            $("#username").val("");
                            $("#useremail").val("");
                            $("#usercoment").val("");
                            $("#userfile").val("");
                        } else {
                            notify("Произошла ошибка, пожалуйста, сообщите на email info@ulrespect.ru. Спасибо!");
                        }

                    },
                    error: function (data) {
                        notify("Произошла ошибка, пожалуйста, сообщите на email info@ulrespect.ru. Спасибо!");
                    }
                });
        }
    });
});

function notify(message) {
    $("#contact-fields").fadeOut(400, function () { });
    $("#contact_form").append("<span class='message'>" + message + "</span>");
    setTimeout(function () {
        $("span", "#contact_form").hide();
        $("#contact-fields").fadeIn();
    }, 5000);
}

$(window).load(function () {
    /* custom scrollbar fn call */
    $(".about").mCustomScrollbar({
        scrollButtons: {
            enable: true
        }
    });

    $(".ymaps-image").click(function () {
        $("#a-office").click();
        return false;
    });

});
