// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.atrr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        }

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-oft-targer"));
            $target.replace(data);
        });

        return false;
    };

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
})