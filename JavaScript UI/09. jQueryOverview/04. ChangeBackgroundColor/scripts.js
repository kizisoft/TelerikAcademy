(function($) {
	$(document).ready(function() {
		$('#changeColor').on('click', function() {
			$('body').css('background', $('#color').val());
		});
	});
}(jQuery));