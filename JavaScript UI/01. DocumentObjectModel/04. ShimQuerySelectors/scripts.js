// 04. *Write a script that shims querySelector and querySelectorAll in older browsers

window.onload = function() {
	function querySelectorHandler(selector, type) {
		var len = document.all.length,
			style = document.createElement('style'),
			css = selector + "{background-image: url('aaa');}",
			result = [];

		if (style.styleSheet) {
			style.styleSheet.cssText = css;
		} else {
			style.appendChild(document.createTextNode(css));
		}

		document.head.appendChild(style);
		//window.scrollBy(0, 0);

		for (var i = 0; i < len; i++) {
			var val = getStyle(document.all[i], 'background-image'),
				start = val.length - 4,
				end = start + 3;

			if (val.slice(start, end) === 'aaa') {
				result.push(document.all[i]);
			}
		}

		document.head.removeChild(style);

		if (type === 'all') {
			return result;
		} else {
			return result[0] || null;
		}
	}

	function getStyle(element, styleProp) {
		var result = null;

		if (element.currentStyle) {
			result = element.currentStyle[styleProp];
		} else if (window.getComputedStyle) {
			result = document.defaultView.getComputedStyle(element, null).getPropertyValue(styleProp);
		}

		return result;
	}

	// Shims querySelector()
	if (!document.querySelector) {
		document.querySelector = function(selector) {
			querySelectorHandler(selector);
		};
	}

	// Shims querySelectorAll()
	if (!document.querySelectorAll) {
		document.querySelectorAll = function(selector) {
			querySelectorHandler(selector, 'all');
		};
	}

	document.getElementById('select').onclick = function() {
		document.getElementById('result').innerText = '';

		var selector = document.getElementById('selector').value || '*',
			result = document.querySelector(selector);

		document.getElementById('result').innerText = result.outerHTML || null;
	};

	document.getElementById('selectAll').onclick = function() {
		document.getElementById('result').innerText = '';

		var selector = document.getElementById('selector').value || '*',
			nodeList = document.querySelectorAll(selector),
			result = '';

		for (var i = 0, len = nodeList.length; i < len; i++) {
			result += (nodeList[i].outerHTML || null) + '\r\n\n';
		}

		document.getElementById('result').innerText = result;
	};
};