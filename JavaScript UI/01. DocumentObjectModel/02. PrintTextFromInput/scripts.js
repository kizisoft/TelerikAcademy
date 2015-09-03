// 02. Create a function that gets the value of <input type="text"> and
//     prints its value to the console

window.onload = function() {
	document.getElementById('print').onclick = function printInputTextToConsole() {
		var text = document.getElementById('text').value || '';

		if (text === '') {
			console.log('No text inputed!');
		} else {
			console.log('Inputed text: ' + text);
		}
	};
};