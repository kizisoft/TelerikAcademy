// 02. Draw a circle that flies inside a box
//     - When it reaches an edge, it should bounce that edge

window.onload = function() {
	var radians2PI = 2 * Math.PI,
		speedX = 5,
		speedY = 5,
		canvas = document.getElementById('mainCanvas'),
		ctx = canvas.getContext('2d'),
		ball = buildBall(canvas.width / 2, canvas.height / 2, 20, '#000', '#ff0');

	function buildBall(inX, inY, inR, inStrokeStyle, inFillStyle) {
		return {
			x: inX,
			y: inY,
			r: inR,
			strokeStyle: inStrokeStyle,
			fillStyle: inFillStyle
		};
	}

	function drawBall(ctx, ball) {
		ctx.beginPath();
		ctx.strokeStyle = ball.strokeStyle;
		ctx.fillStyle = ball.fillStyle;
		ctx.arc(ball.x, ball.y, ball.r, 0, radians2PI);
		ctx.fill();
		ctx.stroke();
	}

	function clearBall(ctx, ball) {
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
	}

	function start() {
		clearBall(ctx, ball);

		if (isColideX(ball)) {
			speedX = -speedX;
		}

		if (isColideY(ball)) {
			speedY = -speedY;
		}

		ball.x += speedX;
		ball.y += speedY;
		drawBall(ctx, ball);

		window.requestAnimationFrame(start);
	}

	start();
};