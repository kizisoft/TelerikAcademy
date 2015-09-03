window.onload = function() {
	var radians2PI = 2 * Math.PI,
		itemRadius = 10,
		snakeHeadStroke = '#000',
		snakeHeadFill = '#fb0',
		snakeBodyStroke = '#000',
		snakeBodyFill = '#ff0',
		step = 5,
		speedX = step,
		speedY = 0,
		canvas = document.getElementById('mainCanvas'),
		ctx = canvas.getContext('2d');

	function buildSnake(inVector, inSize, inLives) {
		var itemsList = [],
			movesCount = 0;

		// Build snake head
		itemsList.push(buildItem(inVector.translate(0), itemRadius, snakeHeadStroke, snakeHeadFill));

		// Build snake body
		for (var i = 1; i < inSize; i += 1) {
			itemsList.push(buildItem(inVector.translate(itemRadius * 2 * i), itemRadius, snakeBodyStroke, snakeBodyFill));
		}

		return {
			vector: inVector,
			size: inSize,
			lives: inLives,
			items: itemsList,
			draw: function() {
				for (var i = 0; i < this.size; i += 1) {
					this.items[i].draw();
				}
			},
			move: function() {
				this.vector.move();
				movesCount++;

				if (movesCount * step >= itemRadius * 2) {
					movesCount = 0;

					var newVector = buildVector(this.vector.x, this.vector.y, this.speedX, this.speedY);

					for (var i = 0; i < this.size; i += 1) {
						var swapVector = this.items[i].vector;
						this.items[i].vector = newVector;
						newVector = swapVector;
					}
				} else {
					for (var i = 0; i < this.size; i += 1) {
						this.items[i].vector.move();
					}
				}
			}
		};
	}

	function buildItem(inVector, inR, inStrokeStyle, inFillStyle) {
		return {
			vector: inVector,
			r: inR,
			strokeStyle: inStrokeStyle,
			fillStyle: inFillStyle,
			draw: function() {
				ctx.beginPath();
				ctx.strokeStyle = this.strokeStyle;
				ctx.fillStyle = this.fillStyle;
				ctx.arc(this.vector.x, this.vector.y, this.r, 0, radians2PI);
				ctx.fill();
				ctx.stroke();
			}
		};
	}

	function buildVector(inX, inY, inSpeedX, inSpeedY) {
		return {
			x: inX,
			y: inY,
			speedX: inSpeedX,
			speedY: inSpeedY,
			translate: function(coeficient) {
				var newX = this.x,
					newY = this.y;

				if (speedX > 0) {
					newX = this.x - coeficient;
				} else if (speedX < 0) {
					newX = this.x - coeficient;
				}

				if (speedY > 0) {
					newY = this.y - coeficient;
				} else if (speedY < 0) {
					newY = this.y - coeficient;
				}

				return buildVector(newX, newY, this.SpeedX, this.SpeedY);
			},
			move: function() {
				this.x += this.speedX;
				this.y += this.speedY;
				return this;
			}
		};
	}

	/*	function clearBall(ctx, ball) {
		ctx.clearRect(ball.x - ball.r - 1, ball.y - ball.r - 1, ball.x + ball.r + 1, ball.y + ball.r + 1);
	}

	function isColideX(ball) {
		if (ball.x - ball.r - 1 <= 0 || ball.x + ball.r + 1 >= canvas.width) {
			return true;
		}

		return false;
	}

	function isColideY(ball) {
		if (ball.y - ball.r - 1 <= 0 || ball.y + ball.r + 1 >= canvas.height) {
			return true;
		}

		return false;
	}*/

	function start() {
		ctx.clearRect(0, 0, canvas.width, canvas.height);

		snake.draw();
		snake.move();

		window.requestAnimationFrame(start);
	}

	var snake = buildSnake(buildVector(100, 100, speedX, speedY), 5, 3);
	start();
};