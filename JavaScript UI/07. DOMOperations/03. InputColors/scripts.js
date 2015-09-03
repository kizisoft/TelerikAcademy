(function() {
	var textarea,
		color,
		background;

	function onClickHandler(event) {
		event = event || window.event;

		textarea.style[event.target.id] = event.target.value;
	}

	window.onload = function() {
		textarea = document.getElementById('colored');
		textarea.style.resize = 'none';

		color = document.getElementById('color');
		color.value = '#000000';
		color.onchange = onClickHandler;

		background = document.getElementById('background');
		background.onchange = onClickHandler;
		background.value = '#ffffff';
	};
}());