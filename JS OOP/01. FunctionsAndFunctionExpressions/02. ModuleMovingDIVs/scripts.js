var movingDIVsModule = (function() {
	var MIN_RECT_X = 100,
		MIN_RECT_Y = 100,
		MAX_RECT_X = 400,
		MAX_RECT_Y = 400,
		START_ELLIPSE_X = 500,
		START_ELLIPSE_Y = 200,
		RADIUS_X = 200,
		RADIUS_Y = 100,
		STEP = 2,
		startTime = 0,
		divs = [];

	function calcRectPosition(div) {
		switch (div.position.dir) {
			case 'r':
				if (div.position.x >= MAX_RECT_X) {
					div.position.x = MAX_RECT_X;
					div.position.dir = 'd';
				} else {
					div.position.x += STEP;
				}
				break;
			case 'd':
				if (div.position.y >= MAX_RECT_Y) {
					div.position.y = MAX_RECT_Y;
					div.position.dir = 'l';
				} else {
					div.position.y += STEP;
				}
				break;
			case 'l':
				if (div.position.x <= MIN_RECT_X) {
					div.position.x = MIN_RECT_X;
					div.position.dir = 'u';
				} else {
					div.position.x -= STEP;
				}
				break;
			case 'u':
				if (div.position.y <= MIN_RECT_Y) {
					div.position.y = MIN_RECT_Y;
					div.position.dir = 'r';
				} else {
					div.position.y -= STEP;
				}
				break;
			default:
		}

		div.div.style.left = div.position.x + 'px';
		div.div.style.top = div.position.y + 'px';
	}

	function calcEllipsePosition(div, angle) {
		var rad = angle * Math.PI / 180;

		div.style.left = START_ELLIPSE_X + RADIUS_X * Math.cos(rad) + 'px';
		div.style.top = START_ELLIPSE_Y + RADIUS_Y * Math.sin(rad) + 'px';

		return angle % 360;
	}

	function moveDIVs(frame) {
		if (startTime < 100) {
			startTime += frame.timeDiff;
		} else {
			startTime = 0;
			for (var i = 0, len = divs.length; i < len; i += 1) {
				if (divs[i].type === 'rect') {
					calcRectPosition(divs[i]);
				} else if (divs[i].type === 'ellipse') {
					divs[i].position = calcEllipsePosition(divs[i].div, divs[i].position + 1);
				}
			}
		}

		window.requestAnimationFrame(moveDIVs);
	}

	function MovingDIVsModule() {
		var div = document.createElement('div');

		this.add = function(type) {
			var obj = createDIV(type);

			document.getElementById('root').appendChild(obj.div);
			divs.push(obj);
		};

		function createDIV(type) {
			var position;

			switch (type) {
				case 'rect':
					position = {
						x: MIN_RECT_X,
						y: MIN_RECT_Y,
						dir: 'r'
					};
					div.style.backgroundColor = '#FF0000';
					div.style.borderRadius = 0;
					break;
				case 'ellipse':
					position = 0;
					div.style.backgroundColor = '#FFFF00';
					div.style.borderRadius = '20px';
					break;
				default:
			}

			return {
				div: div.cloneNode(true),
				type: type,
				position: position
			};
		}

		div.style.position = 'absolute';
		div.style.width = '20px';
		div.style.height = '20px';
		div.style.border = '1px solid #000';
	}

	window.requestAnimationFrame(moveDIVs);
	return new MovingDIVsModule();
}());