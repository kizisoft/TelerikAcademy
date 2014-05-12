// Task 1
document.getElementById("task1").onclick = function() {
	var arr = new Array(20),
		resultStr = "";

	for (var i = 0; i <= 20; i++) {
		arr[i] = i * 5;
		resultStr += "\r\narr[" + i + "] = " + arr[i];
	}

	document.getElementById("tab1").innerText = resultStr;
};

// Task 2
document.getElementById("bt-task2").onclick = function() {
	var firstStringToCompare = document.getElementById("in-task21").value,
		secondStringToCompare = document.getElementById("in-task22").value,
		length = Math.min(firstStringToCompare.length, secondStringToCompare.length),
		result = "First string is the bigger: " + firstStringToCompare.toString();

	for (var i = 0; i < length; i++) {
		if (firstStringToCompare[i] > secondStringToCompare[i]) {
			result = "Second string is the bigger: " + secondStringToCompare.toString();
		}
	}

	document.getElementById("tab2").innerText = result;
};

// Task 3
document.getElementById("bt-task3").onclick = function() {
	var sequence = document.getElementById("in-task3").value.split(","),
		length = sequence.length,
		startSequence = 0,
		endSequence = 0,
		currentStartSequence = 0,
		currentSequenceElement = sequence[0] || "",
		result;

	for (var i = 1; i < length; i++) {
		if (currentSequenceElement !== sequence[i]) {
			if (i - currentStartSequence > endSequence - startSequence) {
				startSequence = currentStartSequence;
				endSequence = i;
			}

			currentStartSequence = i;
			currentSequenceElement = sequence[i];
		}
	}

	document.getElementById("tab3").innerText = "The max sequence: " +
		sequence.slice(startSequence, endSequence) +
		"\r\nStart position: " + startSequence +
		"\r\nEnd position: " + (endSequence - 1);
};

// Task 4
document.getElementById("bt-task4").onclick = function() {
	var sequence = document.getElementById("in-task4").value.split(","),
		length = sequence.length,
		startSequence = 0,
		endSequence = 0,
		currentStartSequence = 0,
		currentSequenceElement = sequence[0] || "",
		result;

	for (var i = 1; i < length; i++) {
		if (currentSequenceElement >= sequence[i]) {
			if (i - currentStartSequence > endSequence - startSequence) {
				startSequence = currentStartSequence;
				endSequence = i;
			}

			currentStartSequence = i;
			currentSequenceElement = sequence[i];
		}
	}

	document.getElementById("tab4").innerText = "The max sequence: " +
		sequence.slice(startSequence, endSequence) +
		"\r\nStart position: " + startSequence +
		"\r\nEnd position: " + (endSequence - 1);
};

// Task 5
function getRandomInt(min, max) {
	return Math.floor(Math.random() * (max - min + 1)) + min;
}

document.getElementById("task5").onclick = function() {
	var count = getRandomInt(20, 40),
		arrayToSort = new Array(count),
		min,
		resultStr = "Random geneerated sequence of " + (count + 1) + " elenents:\r\n[ ";

	for (var i = 0; i <= count; i++) {
		arrayToSort[i] = getRandomInt(-count * 10, count * 10);
		resultStr += arrayToSort[i];
		if (i < count) {
			resultStr += ", ";
		}
	}

	resultStr += " ]\r\n\nSorted sequence:\r\n[ ";
	for (i = 0; i <= count; i++) {
		min = i;
		for (var j = i; j <= count; j++) {
			if (arrayToSort[j] < arrayToSort[min]) {
				min = j;
			}
		}

		if (min !== i) {
			arrayToSort[i] += arrayToSort[min];
			arrayToSort[min] = arrayToSort[i] - arrayToSort[min];
			arrayToSort[i] -= arrayToSort[min];
		}
	}

	resultStr += arrayToSort.join(", ");
	document.getElementById("tab5").innerText = resultStr + " ]";
};

// Task 6
document.getElementById("bt-task6").onclick = function() {
	var sequence = document.getElementById("in-task6").value.split(","),
		sequenceDictionary = [],
		length = sequence.length,
		maxIndex = -1,
		maxValue = 0;

	for (var i = 0; i < length; i++) {
		sequence[i] = sequence[i].trim();
		if (sequenceDictionary[sequence[i]] !== undefined) {
			sequenceDictionary[sequence[i]]++;
		} else {
			sequenceDictionary[sequence[i]] = 1;
		}

		if (sequenceDictionary[sequence[i]] > maxValue) {
			maxIndex = sequence[i];
			maxValue = sequenceDictionary[sequence[i]];
		}
	}

	document.getElementById("tab6").innerText = "The most frequent number is " +
		maxIndex + " -> " + sequenceDictionary[maxIndex] + " times.";
};

// Task 7
document.getElementById("bt-task7").onclick = function() {
	var searchNumber = parseInt(document.getElementById("in-task7").value, 10),
		length = 2000000,
		low = 0,
		high = length - 1,
		middle,
		count = 0,
		array = [],
		resultStr = " check(s) made.\r\nNumber " + searchNumber + " does not exist!";

	// Initialize a sorted array
	for (var i = 0; i < length; i++) {
		array[i] = i;
	}

	while (low <= high) {
		count++;
		// Find the middle
		middle = low + parseInt((high - low) / 2, 10);

		if (array[middle] === searchNumber) {
			// Check if number is found
			resultStr = " check(s) made. \r\nNumber exist at possition = " + middle;
			break;
		} else if (array[middle] < searchNumber) {
			// If number > middle element then move low to the next right
			// of middle element and continue the loop
			low = middle + 1;
		} else {
			// If number < middle element then move high to the next left
			// of middle element and continue the loop
			high = middle - 1;
		}
	}

	document.getElementById("tab7").innerText = count + resultStr;
};