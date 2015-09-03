// 03. Crеate a function that gets the value of <input type="color"> and
//     sets the background of the body to this value

window.onload = function() {
	document.getElementById('changeColor').onclick = function changeBodyColor() {
		var color = document.getElementById('color').value || document.body.bgColor;

		document.body.bgColor = color;
	};
};