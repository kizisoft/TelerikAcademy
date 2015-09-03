// 01. Write a script that selects all the div nodes that are directly inside other div elements
//     - Create a function using querySelectorAll()
//     - Create a function using getElementsByTagName()

window.onload = function() {
	function printNodeList(nodeList) {
		var length = nodeList.length || 0,
			result = document.getElementById('result'),
			hr = new Array(50).join('-'),
			br = '\r\n';

		if (nodeList === null || length < 1) {
			result.innerText = hr + br + 'No elements found!';
		} else {
			result.innerText = hr + br + length + ' elements found.' + br;
			for (var i = 0; i < length; i++) {
				result.innerText += br + hr + br + 'elements[' + i + '] :' + br + nodeList[i].outerHTML + br;
			}
		}
	}

	function findDIVsByQuerySelectorAll() {
		var elements = document.querySelectorAll('div > div');

		printNodeList(elements);
	}

	function findDIVsBygetElementsByTagName() {
		var elements = document.getElementsByTagName('div'),
			length = elements.length || 0,
			result = [];

		for (var i = 0; i < length; i++) {
			if (elements[i].parentNode instanceof HTMLDivElement) {
				result.push(elements[i]);
			}
		}

		printNodeList(result);
	}

	document.getElementById('selector').onclick = findDIVsByQuerySelectorAll;
	document.getElementById('tagName').onclick = findDIVsBygetElementsByTagName;
};