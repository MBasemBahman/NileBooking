$(document).on('click', '.rating_star', function () {
	$('.rating_star').removeClass('fa-solid').addClass('fa-regular');
	$(this).prevAll('.rating_star').addBack().removeClass('fa-regular').addClass('fa-solid');

	$("input[name=Rate]").val($(this).prevAll('.rating_star').addBack().length);
});