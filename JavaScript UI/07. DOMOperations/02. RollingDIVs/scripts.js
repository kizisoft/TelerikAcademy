(function() {
	var count = 5,
		startTime = 0,
		divs = [],
		currentAngle = [];

	function createDIV() {
		var div = document.createElement('div');

		div.style.position = 'absolute';
		div.style.width = '20px';
		div.style.height = '20px';
		div.style.backgroundColor = '#FFFF00';
		div.style.border = '1px solid #000';
		div.style.borderRadius = '20px';

		return div;
	}

	function calcPosition(div, angle) {
		var rad = angle * Math.PI / 180;

		div.style.left = 300 + 100 * Math.cos(rad) + 'px';
		div.style.top = 300 + 100 * Math.sin(rad) + 'px';

		return angle % 360;
	}

	function moveDIVs(frame) {
		if (startTime < 100) {
			startTime += frame.timeDiff;
		} else {
			startTime = 0;
			for (var i = 0; i < count; i += 1) {
				currentAngle[i] = calcPosition(divs[i], currentAngle[i] + 1);
			}
		}

		window.requestAnimationFrame(moveDIVs);
	}

	window.onload = function() {
		var fragment = document.createDocumentFragment();

		for (var i = 0; i < count; i += 1) {
			divs.push(createDIV());
			currentAngle.push(calcPosition(divs[i], i * 10));
			fragment.appendChild(divs[i]);
		}

		document.body.appendChild(fragment);
		window.requestAnimationFrame(moveDIVs);
	};
}());