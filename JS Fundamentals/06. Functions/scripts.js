(function() {
	// Task 1
	function lastDigitToString(number) {
		var digitInString = ["Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"];

		number = ("" + number).trim();
		return digitInString[number[number.length - 1]];
	}

	// Task 2
	function reverseDigits(number) {
		return ("" + number).trim().split("").reverse().join("");
	}

	// Task 3
	function countWordOcurrences(word, text, isCaseSensitive) {
		var textLength = text.length,
			wordLength = word.length,
			checkIndex = 0,
			wordCount = 0;

		isCaseSensitive = isCaseSensitive || false;
		if (!isCaseSensitive) {
			word = word.toLowerCase();
			text = text.toLowerCase();
		}

		for (var i = 0; i < textLength; i++) {
			if (word[checkIndex] === text[i]) {
				if (checkIndex === wordLength - 1) {
					if (!((text[i - wordLength] >= "A" && text[i - wordLength] <= "Z") || (text[i - wordLength] >= "a" && text[i - wordLength] <= "z")) && !((text[i + 1] >= "A" && text[i + 1] <= "Z") || (text[i + 1] >= "a" && text[i + 1] <= "z"))) {
						// Match!!!
						wordCount++;
					}
				}

				checkIndex = (checkIndex + 1) % wordLength;
			} else {
				checkIndex = 0;
			}
		}

		return wordCount;
	}

	// Task 4
	function countDIVs() {
		return document.body.getElementsByTagName("div").length;
	}

	// Task 5
	function countGivenNumberInArray(number, inArray) {
		var length = inArray.length,
			count = 0;

		for (var i = 0; i < length; i++) {
			if (number === inArray[i]) {
				count++;
			}
		}

		return count;
	}

	// Task 6
	function isBiggerThenNeighbors(position, inArray) {
		if (position === 0 || position === inArray.length - 1) {
			return false;
		}

		return inArray[position] > inArray[position - 1] && inArray[position] > inArray[position + 1];
	}

	// Task 7
	function findFirstBiggerThenNeighbors(inArray) {
		var length = inArray.length;

		for (var i = 1; i < length - 1; i++) {
			if (isBiggerThenNeighbors(i, inArray)) {
				return i;
			}
		}

		return -1;
	}

	// <= Test functions =>

	// Test 1
	document.getElementById("bt-task1").onclick = function() {
		var number = parseInt(document.getElementById("in-task1").value, 10),
			result = "The last digit is: ";

		result += lastDigitToString(number);
		if (isNaN(number)) {
			result = "Enter a number!";
		}

		document.getElementById("tab1").innerText = result;
	};

	// Test 2
	document.getElementById("bt-task2").onclick = function() {
		var number = parseInt(document.getElementById("in-task2").value, 10),
			result = "The reversed number is: ";

		result += reverseDigits(number);
		if (isNaN(number)) {
			result = "Enter a number!";
		}

		document.getElementById("tab2").innerText = result;
	};

	// Test 3
	document.getElementById("bt-task3").onclick = function() {
		var text = document.getElementById("in-task31").value,
			word = document.getElementById("in-task32").value,
			isCaseSensitive = document.getElementById("ck-task3").checked,
			result = "The reversed number is: ";

		result += countWordOcurrences(word, text, isCaseSensitive);
		document.getElementById("tab3").innerText = result;
	};

	// Test 4
	document.getElementById("bt-task4").onclick = function() {
		document.getElementById("tab4").innerText = 'The count of DIVs on this page: ' + countDIVs();
	};

	// Test 5
	document.getElementById("bt-task5").onclick = function() {
		var number = parseInt(document.getElementById("in-task51").value, 10),
			inArray = document.getElementById("in-task52").value.split(","),
			result = "The number appears ";

		inArray = inArray.map(Number);
		if (isNaN(number)) {
			result = "Enter a number!";
		} else {
			result += countGivenNumberInArray(number, inArray) + " times.";
		}

		document.getElementById("tab5").innerText = result;
	};

	// Test 6
	document.getElementById("bt-task6").onclick = function() {
		var inArray = document.getElementById("in-task61").value.split(","),
			position = parseInt(document.getElementById("in-task62").value, 10),
			result = "The element is bigger than its two neighbors: ";

		inArray = inArray.map(Number);
		if (isNaN(position)) {
			result = "Enter a number!";
		} else {
			result += isBiggerThenNeighbors(position, inArray);
		}

		document.getElementById("tab6").innerText = result;
	};

	// Test 7
	document.getElementById("bt-task7").onclick = function() {
		var inArray = document.getElementById("in-task7").value.split(",");

		inArray = inArray.map(Number);
		document.getElementById("tab7").innerText = "The element position: " + findFirstBiggerThenNeighbors(inArray);
	};
})();