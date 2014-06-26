/* global movingDIVsModule */
(function() {
	function onAddRectClick() {
		movingDIVsModule.add('rect');
	}

	function onAddEllipseClick() {
		movingDIVsModule.add('ellipse');
	}

	document.getElementById('add-rect').addEventListener('click', onAddRectClick);
	document.getElementById('add-ellipse').addEventListener('click', onAddEllipseClick);
}());