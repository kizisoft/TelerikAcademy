/* global domModule */
(function() {
	var countLi = 0,
		countSpan = 0;

	document.getElementById('add').addEventListener('click', addDIV);
	document.getElementById('remove').addEventListener('click', removeDIV);
	document.getElementById('add-handler').addEventListener('click', addOnClickHandler);
	document.getElementById('add-li').addEventListener('click', addLiElements);
	document.getElementById('add-span').addEventListener('click', addSpanElements);

	function addDIV() {
		var div = document.createElement('div');

		div.style.border = '1px solid #f00';
		div.style.width = '200px';
		div.style.height = '100px';
		div.style.overflowY = 'auto';
		div.style.marginTop = '20px';
		div.className = 'created';

		domModule.appendChild(div, '#root');

		document.getElementById('add-handler').disabled = false;
	}

	function removeDIV() {
		domModule.removeChild('#root', '.created');

		if (document.getElementsByClassName('created').length === 0) {
			document.getElementById('add-handler').disabled = true;
		}
	}

	function addOnClickHandler() {
		domModule.addHandler('div.created', 'click', eventHandler);
	}

	function eventHandler() {
		this.innerText += "I'm clicked!\r\n";
	}

	function addLiElements() {
		var li = document.createElement('li');

		countLi += 10;
		if (countLi >= 100) {
			countLi = 0;
		}

		this.innerText = this.innerText.slice(0, 9) + ' (' + countLi + ')';
		li.innerText = "I'm test LI element!";
		for (var i = 0; i < 10; i += 1) {
			domModule.appendToBuffer('#father', li.cloneNode(true));
		}
	}

	function addSpanElements() {
		var span = document.createElement('span');

		countSpan += 10;
		if (countSpan >= 100) {
			countSpan = 0;
		}

		this.innerText = this.innerText.slice(0, 9) + ' (' + countSpan + ')';
		span.innerText = "I'm test SPAN element!";
		for (var i = 0; i < 10; i += 1) {
			domModule.appendToBuffer('#container', span.cloneNode(true));
		}
	}
}());