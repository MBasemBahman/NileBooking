$(function () {
    'use strict';

    // form repeater jquery
    $('.repeater').repeater({
        show: function () {
            $(this).slideDown();
            // Feather Icons
        },
        hide: function (deleteElement) {
            if (confirm('Are you sure you want to delete this element?')) {
                $(this).slideUp(deleteElement);
            }
        }
    });
});
