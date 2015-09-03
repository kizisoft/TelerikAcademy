/*jslint browser: true*/
/*global Kinetic*/

window.onload = function() {
	var stage = getStage('kinetic-container', 1300, 600),
		layer = new Kinetic.Layer(),
		img = document.getElementById('frames'),
		frameW = 82,
		frameH = 125,
		numberOfFrames = 10,
		image = new Kinetic.Image({
			x: 0,
			y: 0,
			width: frameW,
			height: frameH,
			image: img,
			crop: {
				x: 0,
				y: 285,
				width: frameW,
				height: frameH
			}
		}),
		i = 0,
		startTime = null,
		speed = 30,
		anim = new Kinetic.Animation(framesAnimation, layer);

	function getStage(inContainer, inWidth, inHeight) {
		return new Kinetic.Stage({
			container: inContainer,
			width: inWidth,
			height: inHeight
		});
	}

	function framesAnimation(frame) {
		if (startTime < 60) {
			startTime += frame.timeDiff;
		} else {

			if (image.getX() > stage.attrs.width) {
				image.setX(-80);
			}

			startTime = 0;
			i = i % numberOfFrames;
			image.attrs.cropX = frameW * i;
			image.setX(image.getX() + speed * frame.timeDiff / 60);
			layer.add(image);
			layer.draw();
			i += 2;
		}
	}

	stage.add(layer);
	anim.start();
};