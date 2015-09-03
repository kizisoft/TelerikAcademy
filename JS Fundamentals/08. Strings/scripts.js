(function strings() {
	// Task 1
	function reverse(str) {
		var result = "",
			length = str.length;

		for (var i = 0; i < length; i++) {
			result += str[length - 1 - i];
		}

		return result;
	}

	// Task 2
	function checkBrackets(str) {
		var brackets = 0,
			length = str.length;

		for (var i = 0; i < length; i++) {
			if (brackets < 0) {
				return false;
			}

			if (str[i] === "(") {
				brackets++;
			}

			if (str[i] === ")") {
				brackets--;
			}
		}

		return brackets === 0;
	}

	// Task 3
	function countSubsring(str, key) {
		var count = 0,
			currentIndex = -1;

		str = str.toLowerCase();
		do {
			currentIndex = str.indexOf(key, currentIndex + 1);
			if (currentIndex < 0) break;
			count++;
		} while (true);

		return count;
	}

	// Task 4
	function changeTextRegions(str) {
		var START_COMMANDS = ["<upcase>", "<lowcase>", "<mixcase>"],
			END_COMMANDS = ["</upcase>", "</lowcase>", "</mixcase>"],
			length = str.length,
			commandIndex = -1,
			currentCommand = [],
			result = "";

		function getRandomInt(min, max) {
			return Math.floor(Math.random() * (max - min + 1)) + min;
		}

		function checkCommand(i) {
			var length = END_COMMANDS.length;

			for (var j = 0; j < length; j++) {
				if (START_COMMANDS[j] === str.slice(i, i + START_COMMANDS[j].length)) {
					currentCommand.push(START_COMMANDS[j]);
					commandIndex++;
					return START_COMMANDS[j].length;
				}

				if (END_COMMANDS[j] === str.slice(i, i + END_COMMANDS[j].length)) {
					if (commandIndex < 0 || currentCommand[commandIndex] !== START_COMMANDS[j]) {
						return -1;
					}

					currentCommand.pop();
					commandIndex--;
					return END_COMMANDS[j].length;
				}
			}

			return 0;
		}

		for (var i = 0; i < length; i++) {
			var forwardIndex = checkCommand(i);

			if (forwardIndex < 0) {
				return "Wrong tags!";
			}

			i += forwardIndex;
			if (commandIndex >= 0) {
				switch (currentCommand[commandIndex]) {
					case "<upcase>":
						result += str[i].toUpperCase();
						continue;
					case "<lowcase>":
						result += str[i].toLowerCase();
						continue;
					case "<mixcase>":
						if (getRandomInt(0, 1) === 1) {
							result += str[i].toUpperCase();
						} else {
							result += str[i].toLowerCase();
						}

						continue;
					default:
						return "Error!";
				}
			}

			if (i < length) {
				result += str[i];
			}

		}

		return result;
	}

	// Task 5
	function replaceSpaceToNBSpace(str) {
		var result = str.split(" ").join("&nbsp;");

		return result;
	}

	// Task 6
	function stripTags(str) {
		var length = str.length,
			result = "";

		for (var i = 0; i < length; i++) {
			if (str[i] === "<") {
				var index = str.indexOf(">", i);

				if (index < i) {
					return "Wrong tags!";
				}

				i = index;
			} else {
				result += str[i];
			}
		}

		return result;
	}

	// Task 7
	function parseURL(str) {
		str = str.trim() || "";

		var length = str.length,
			index = str.indexOf(":");

		if (index < 1) {
			return "Wrong URL!";
		}

		var protocol = str.split("").splice(0, index).join("");
		index++;
		while (str[index] === "/") {
			index++;
		}

		var serverIndex = str.indexOf("/", index);
		if (serverIndex < index) {
			serverIndex = length;
		}

		var server = str.split("").splice(index, serverIndex - index).join("");
		var resource = str.split("").splice(serverIndex, length - serverIndex).join("");

		return {
			"protocol": protocol,
			"server": server,
			"resource": resource
		};
	}

	// Task 8
	function replaceAll(str) {
		str = str || "";
		str = str.split('<a href="').join("[URL=");
		str = str.split('">').join("]");
		str = str.split("</a>").join("[/URL]");
		return str;
	}

	// Task 9
	function getEmailsFromText(str) {
		var regex = /([\w_]+)\@(\w+)\.([\w\.]+\w)/g,
			result = [],
			email;

		while (email = regex.exec(str)) {
			result.push(email[0]);
		}

		return result;
	}

	// Task 10
	function getPalindromesFromText(str) {
		str = str || "";
		var words = str.replace(/^[\s,.!?+(-)]+|[\s,.!?+(-)]+$/g, "").split(/[\s,.!?+(-)]+/),
			result = [];

		function IsPalindrome(word) {
			var length = word.length;

			if (length < 3) {
				return false;
			}

			for (var i = 0; i < length / 2; i++) {
				if (word[i] != word[length - i - 1]) {
					return false;
				}
			}

			return true;
		}

		for (var i = 0; i < words.length; i++) {
			if (IsPalindrome(words[i])) {
				result.push(words[i]);
			}
		}

		return result;
	}

	// Task 11
	function stringFormat() {
		var args = Array.prototype.slice.call(arguments),
			str = args[0],
			length = args.length,
			params = args.splice(1, length - 1);

		for (var i = 0; i < params.length; i++) {
			var match = "{" + i + "}";

			str = str.split(match).join(params[i]);
		}

		return str;
	}



	// Test
	(function test() {
		var str = "",
			key = "";

		console.log("Task 1");
		console.log(reverse("sample"));

		console.log("Task 2");
		console.log(checkBrackets("((a+b)/5-d)"));
		console.log(checkBrackets(")(a+b))"));

		console.log("Task 3");
		str = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
		key = "in";
		console.log(countSubsring(str, key));

		console.log("Task 4");
		str = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.<upcase>We are <mixcase>living in an yellow submarine. <lowcase>We don't have anything else. Inside</lowcase> the submarine is very tight.</mixcase> So we are drinking all the day. We will move out of it in 5 days.</upcase>";
		console.log(changeTextRegions(str));

		console.log("Task 5");
		console.log(replaceSpaceToNBSpace(str));

		console.log("Task 6");
		str = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>";
		console.log(stripTags(str));

		console.log("Task 7");
		str = "http://forums.academy.telerik.com/160835/js-%D0%B7%D0%B0%D0%B4%D0%B0%D1%87%D0%B0-7-%D0%B4%D0%BE%D0%BC%D0%B0%D1%88%D0%BD%D0%BE-strings?show=160835#q160835 "; // :)
		console.log(parseURL(str));

		console.log("Task 8");
		str = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';
		console.log(replaceAll(str));

		console.log("Task 9");
		str = "Bla blaaaalbal alflals @ bla student@telerikacademy.com aaaaaa @mail. asd  someoneelse@yahoo.com asd. (lektor@academy.it).";
		console.log(getEmailsFromText(str));

		console.log("Task 10");
		str = "A palindrome is a word, ABBA phrase, number exe, or other sequence of symbols or elements, whose meaning may be interpreted the same lamal way in either forward or reverse direction.";
		console.log(getPalindromesFromText(str));

		console.log("Task 11");
		str = "{0}, {1}, {0} text {2}";
		console.log(stringFormat(str, 1, "Pesho", "Gosho"));
	})();
})();