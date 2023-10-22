$(document).ready(function () {
	$(".fromDate").flatpickr({
		enableTime: false,
		noCalendar: false,
		enableDate: true
	});

	$(".toDate").flatpickr({
		enableTime: false,
		noCalendar: false,
		enableDate: true
	});
	$(document).on('click', '#add-new-btn', function () {
		setTimeout(function () {
			$(".idElem").last().val('0');
			$(".adultPriceElem").last().val('');
			$(".childPriceElem").last().val('');
			$(".fromDateElem").last().val('');
			$(".toDateElem").last().val('');
		}, 500);

		$(".fromDate").last().flatpickr({
			enableTime: false,
			noCalendar: false,
			enableDate: true
		});

		$(".toDate").last().flatpickr({
			enableTime: false,
			noCalendar: false,
			enableDate: true
		});
	});

	$('.repeater').repeater({
		show: function () {
			$(this).slideDown();
		},
		hide: function (deleteElement) {
			$(this).slideUp(deleteElement);
		},
	});

	$('button[data-repeater-delete][newRepeater]').click();
});
