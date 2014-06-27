var specialConsole = (function() {

	function writeLine() {
		var result = formatString.apply(null, arguments);
		console.log(result);
	}

	function writeError() {
		var result = formatString.apply(null, arguments);
		console.error(result);
	}

	function writeWarning() {
		var result = formatString.apply(null, arguments);
		console.warn(result);
	}

	function formatString() {
		var len = arguments.length,
			result = arguments[0] || '';

		if (!len) {
			return result;
		}

		if (len === 1) {
			return result.toString();
		} else {
			for (var i = 1; i < len; i += 1) {
				result = replaceAll('{' + (i - 1) + '}', arguments[i].toString(), result);
			}

			return result;
		}
	}

	function replaceAll(find, replace, str) {
		return str.replace(new RegExp(escapeRegExp(find), 'g'), replace);
	}

	function escapeRegExp(string) {
		return string.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
	}

	return {
		writeLine: writeLine,
		writeError: writeError,
		writeWarning: writeWarning
	};
}());