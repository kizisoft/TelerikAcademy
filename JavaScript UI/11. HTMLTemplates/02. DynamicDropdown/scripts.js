/* globals document, Handlebars */
(function() {
	var options = [{
		value: 1,
		text: 'One'
	}, {
		value: 2,
		text: 'Two'
	}, {
		value: 3,
		text: 'Three'
	}, {
		value: 4,
		text: 'Four'
	}, {
		value: 5,
		text: 'Five'
	}];

	window.onload = function() {
		var optionsTemplate = document.getElementById('options-template');
		var optionsTemplateString = optionsTemplate.innerHTML;
		var templateFunction = Handlebars.compile(optionsTemplateString);
		var dropdown = document.getElementById('dropdown');
		var optionsHtml = templateFunction({
			optionsGroup: options
		});
		dropdown.innerHTML += optionsHtml;
	};
}());