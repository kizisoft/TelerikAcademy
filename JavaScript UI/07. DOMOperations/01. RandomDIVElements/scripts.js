(function() {
	// Return nnumber in range min<= Number <= max
	function getRandom(min, max) {
		return Math.floor(Math.random() * (max - min + 1)) + min;
	}

	function getRandomColor() {
		var r = getRandom(0, 255),
			g = getRandom(0, 255),
			b = getRandom(0, 255);

		return 'rgb(' + r + ',' + g + ',' + b + ')';
	}

	function createDIV() {
		var div = document.createElement('div'),
			strong = document.createElement('strong');

		div.style.width = getRandom(20, 100) + 'px';
		div.style.height = getRandom(20, 100) + 'px';
		div.style.background = getRandomColor();
		div.style.color = getRandomColor();
		div.style.position = 'absolute';
		div.style.top = getRandom(0, 800) + 'px';
		div.style.left = getRandom(0, 1024) + 'px';
		div.style.borderRadius = getRandom(0, 20) + 'px';
		div.style.border = getRandom(1, 20) + 'px solid ' + getRandomColor();
		strong.innerHTML = 'div';
		div.appendChild(strong);

		return div;
	}

	window.onload = function() {
		var fragment = document.createDocumentFragment();

		for (var i = 0; i < getRandom(5, 20); i += 1) {
			fragment.appendChild(createDIV());
		}

		document.body.appendChild(fragment);
	};

}());