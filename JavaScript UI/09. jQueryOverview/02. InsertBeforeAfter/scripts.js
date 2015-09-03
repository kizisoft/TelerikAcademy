(function($) {
	var $div = $('<div />');

	$(document).ready(function() {
		$('#before').on('click', function() {
			var $newDiv = $div.clone(true).insertBefore('#main-div');
			$newDiv.text("I'm inserted before!");
		});

		$('#after').on('click', function() {
			var $newDiv = $div.clone(true).insertAfter('#main-div');
			$newDiv.text("I'm inserted after!");
		});

		$('#clear').on('click', function() {
			$('.wrapper div').remove(":contains('inserted')");
		});
	});
}(jQuery));