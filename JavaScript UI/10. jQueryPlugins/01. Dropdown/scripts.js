(function($) {
	$.fn.dropdown = function() {
		var $options = $('#dropdown option'),
			optionsCount = $options.length,
			$dropdownListContainer = $('<div />').addClass('dropdown-list-container').on('click', onDropdownClick),
			$dropdownListOptions = $('<ul />').addClass('dropdown-list-options');

		function onDropdownClick() {
			$dropdownListOptions.toggleClass('open');
		}

		function onOptionClick() {
			var $text = $('<p />').addClass('list-option-value').text($(this).text()),
				selectedValue = parseInt($(this).attr('data-value'), 10) + 1;

			$('.list-option-value').remove();
			$text.insertBefore($dropdownListOptions);
			$('#dropdown :selected').attr('selected', false);
			$('#dropdown [value="' + selectedValue + '"]').attr('selected', true);
			$('#dropdown').val(selectedValue);
		}

		$('#dropdown').css('display', 'none');
		$dropdownListContainer.append($dropdownListOptions);
		for (var i = 0; i < optionsCount; i += 1) {
			var $dropdownListOption = $('<li />')
				.addClass('dropdown-list-option')
				.attr('data-value', i)
				.text($($options[i]).text())
				.on('click', onOptionClick);

			$dropdownListOptions.append($dropdownListOption);
		}

		$('.root').append($dropdownListContainer);
	};

	$(document).ready(function() {
		$('dropdown').dropdown();
	});
}(jQuery));