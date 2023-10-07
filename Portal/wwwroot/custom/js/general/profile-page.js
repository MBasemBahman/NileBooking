let link = $(".nav-link.active").eq(0).attr("id");

$(".page_content").load(link);

$(document).on('click', '.nav-link', function(e) {
    e.preventDefault();

    let link = $(this).attr('id');

    $(".page_content").load(link);

    $(".active").each(function() {
        $(this).removeClass('active');
    });

    $(this).addClass('active');

});