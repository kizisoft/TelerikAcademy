window.onload = function() {

	// Create object to store point coordinates and command how to process it
	function buildPoint(inX, inY, inColor, inCommand) {
		return {
			x: inX,
			y: inY,
			color: inColor,
			command: inCommand,
			toString: function() {
				return this.command + '(' + this.x + ', ' + this.y + ', ' + this.color + ')';
			}
		};
	}

	// Draw current path
	function executePath(ctx, path) {
		path = path || [];
		var length = path.length;

		ctx.beginPath();

		for (var i = 0; i < length; i++) {
			switch (path[i].command) {
				case 'B':
					ctx.beginPath();
					break;
				case 'L':
					ctx.lineTo(path[i].x, path[i].y);
					break;
				case 'M':
					ctx.moveTo(path[i].x, path[i].y);
					break;
				case 'F':
					ctx.fillStyle = path[i].color;
					ctx.fill();
					break;
				case 'S':
					ctx.strokeStyle = path[i].color;
					ctx.stroke();
					break;
				default:
					continue;
			}
		}
	}

	// Round value -> XX05 = XX10, XX04 = XX00
	function round(valueToRound) {
		var lastDigith = valueToRound % 10;

		if (lastDigith > 4) {
			return valueToRound - lastDigith + 10;
		} else {
			return valueToRound - lastDigith;
		}
	}

	var canvas = document.getElementById('mainCanvas'),
		ctx = canvas.getContext('2d'),
		spanX = document.getElementById('coordinateX'),
		spanY = document.getElementById('coordinateY'),
		currentX,
		currentY,
		ctrlKey = document.getElementById('ctrlKey'),
		altKey = document.getElementById('altKey'),
		commandInfo = document.getElementById('commandInfo'),
		command = 'L',
		pathText = document.getElementById('path'),
		img = document.getElementById('image'),
		color = '#000',
		fillColor = '#af6161',
		rounding = true;

	// Mouse position
	canvas.onmousemove = function(event) {
		spanX.innerText = event.x;
		spanY.innerText = event.y;
	};

	document.onmousemove = function(event) {
		currentX = event.x;
		currentY = event.y;
	};

	// Create point in the path
	canvas.onclick = function(event) {
		var x = event.x,
			y = event.y,
			setColor = color;

		if (rounding) {
			x = round(x);
			y = round(y);
		}

		if (command === 'F') {
			setColor = fillColor;
		}

		var point = buildPoint(x, y, setColor, command);
		var newLine = '';
		if (pathText.value !== '') {
			newLine = '\r\n';
		}

		pathText.value += newLine + point.toString();
	};

	// Indicate current command
	document.body.onkeydown = keyDownUp;
	document.body.onkeyup = keyDownUp;

	function keyDownUp(event) {
		if (parseInt(currentX, 10) > canvas.width || parseInt(currentY, 10) > canvas.height) {
			return;
		}

		if (event.ctrlKey && event.altKey) {
			ctrlKey.innerText = 'ON';
			altKey.innerText = 'ON';
			commandInfo.innerText = 'Fill path (F)';
			command = 'F';
			event.preventDefault();
		} else if (event.ctrlKey) {
			ctrlKey.innerText = 'ON';
			altKey.innerText = 'OFF';
			commandInfo.innerText = 'Move to (M)';
			command = 'M';
			event.preventDefault();
		} else if (event.altKey) {
			ctrlKey.innerText = 'OFF';
			altKey.innerText = 'ON';
			commandInfo.innerText = 'Stroke path (S)';
			command = 'S';
			event.preventDefault();
		} else {
			ctrlKey.innerText = 'OFF';
			altKey.innerText = 'OFF';
			commandInfo.innerText = 'Line to (L)';
			command = 'L';
		}
	}

	// Button < Begin new path >
	document.getElementById('beginPath').onclick = function() {
		var point = buildPoint(0, 0, '#none', 'B'),
			newLine = '';

		if (pathText.value !== '') {
			newLine = '\r\n';
		}

		pathText.value += newLine + point.toString();
	};

	// Button < Show Task Solution >
	document.getElementById('show').onclick = function() {
		var path = parsePath();
		
		ctx.clearRect(0, 0, canvas.width, canvas.height);
		drawCirclesBefore(ctx);
		executePath(ctx, path);
		drawCirclesAfter(ctx);
	};

	// Button < Clear canvas >
	document.getElementById('clear').onclick = function() {
		ctx.clearRect(0, 0, canvas.width, canvas.height);
	};

	// Change stroke color
	document.getElementById('color').onchange = function() {
		color = document.getElementById('color').value || color;
	};

	// Change fill color
	document.getElementById('fillColor').onchange = function() {
		fillColor = document.getElementById('fillColor').value || fillColor;
	};

	// Round point coordinates -> XX05 = XX10, XX04 = XX00
	document.getElementById('rounding').onchange = function() {
		rounding = document.getElementById('rounding').checked;
	};

	// Button < Draw path >
	function parsePath() {
		var str = pathText.value,
			length = str.length,
			path = [],
			firstNumber = false,
			secondNumber = false,
			colorFlag = false,
			newColor = '#',
			command = '',
			strX = '',
			strY = '';

		function initValues() {
			firstNumber = false,
			secondNumber = false,
			colorFlag = false,
			newColor = '#',
			command = '',
			strX = '',
			strY = '';
		}

		for (var i = 0; i < length; i++) {
			switch (str[i]) {
				case 'M':
				case 'L':
				case 'F':
				case 'S':
				case 'B':
					command = str[i];
					break;
				case '(':
					firstNumber = true;
					break;
				case ',':
					secondNumber = true;
					break;
				case '#':
					colorFlag = true;
					break;
				case ')':
					var x = parseInt(strX, 10),
						y = parseInt(strY, 10);

					if (rounding) {
						x = round(x);
						y = round(y);
					}

					path.push(buildPoint(x, y, newColor, command));
					initValues();
					break;
				default:
					if (colorFlag) {
						newColor += str[i];
					} else if (secondNumber) {
						strY += str[i];
					} else if (firstNumber) {
						strX += str[i];
					}
			}
		}

		return path;
	}

	document.getElementById('draw').onclick = function() {
		var path = parsePath();
		executePath(ctx, path);
	};

	function drawCirclesBefore(ctx) {
		ctx.beginPath();
		ctx.fillStyle = '#8CE3FD';
		ctx.strokeStyle = '#61949e';
		ctx.moveTo(575, 530);
		ctx.arc(500, 530, 75, 0, 2 * Math.PI);
		ctx.moveTo(285, 540);
		ctx.arc(210, 540, 75, 0, 2 * Math.PI);
		ctx.fill();
		ctx.moveTo(360, 535);
		ctx.arc(340, 535, 20, 0, 2 * Math.PI);
		ctx.stroke();

		ctx.beginPath();
		ctx.strokeStyle = '#34626D';

		ctx.save();
		ctx.moveTo(385, 260);
		ctx.scale(1.1, 1);
		ctx.arc(270, 260, 80, 0, 2 * Math.PI);
		ctx.restore();

		ctx.fill();

		ctx.save();
		ctx.moveTo(310, 300);
		ctx.rotate(10 * Math.PI / 180);
		ctx.scale(1.15, 0.4);
		ctx.arc(285, 610, 25, 0, 2 * Math.PI);
		ctx.restore();

		ctx.save();
		ctx.moveTo(265, 230);
		ctx.scale(1.1, 0.8);
		ctx.arc(230, 290, 12, 0, 2 * Math.PI);
		ctx.moveTo(292, 290);
		ctx.arc(280, 290, 12, 0, 2 * Math.PI);
		ctx.restore();

		ctx.stroke();

		ctx.beginPath();
		ctx.fillStyle = '#34626D';
		ctx.save();
		ctx.moveTo(250, 230);
		ctx.scale(0.8, 1.1);
		ctx.arc(310, 210, 5, 0, 2 * Math.PI);
		ctx.moveTo(385, 210);
		ctx.arc(380, 210, 5, 0, 2 * Math.PI);
		ctx.restore();

		ctx.fill();

		ctx.beginPath();
		ctx.fillStyle = '#236A9A';
		ctx.strokeStyle = '#000';
		ctx.save();
		ctx.scale(1.1, 0.2);
		ctx.moveTo(350, 940);
		ctx.arc(260, 940, 90, 0, 2 * Math.PI);
		ctx.restore();

		ctx.fill();
		ctx.stroke();

		ctx.beginPath();
		ctx.save();
		ctx.scale(1.1, 0.4);
		ctx.moveTo(318, 430);
		ctx.arc(268, 430, 50.3, 0, 2 * Math.PI);
		ctx.restore();

		ctx.fill();
		ctx.stroke();
	}

	function drawCirclesAfter(ctx) {
		ctx.beginPath();
		ctx.fillStyle = '#236A9A';
		ctx.strokeStyle = '#000';
		ctx.save();
		ctx.scale(1.1, 0.4);
		ctx.moveTo(318, 200);
		ctx.arc(268, 200, 50.3, 0, 2 * Math.PI);
		ctx.restore();

		ctx.fill();
		ctx.stroke();

		ctx.beginPath();
		ctx.fillStyle = '#af6161';

		ctx.save();
		ctx.scale(1, 0.4);
		ctx.moveTo(1020, 180);
		ctx.arc(1000, 180, 20, 0, 2 * Math.PI);
		ctx.restore();

		ctx.fill();

		ctx.moveTo(810, 450);
		ctx.arc(805, 450, 5, 0, 2 * Math.PI);
		ctx.moveTo(840, 450);
		ctx.arc(835, 450, 5, 0, 2 * Math.PI);

		ctx.save();
		ctx.scale(1, 0.5);
		ctx.moveTo(870, 790);
		ctx.arc(820, 790, 50, 0, 1 * Math.PI, true);
		ctx.restore();

		ctx.stroke();
	}

	ctx.drawImage(img, 0, 0);
};