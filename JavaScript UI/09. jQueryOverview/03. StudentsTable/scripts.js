(function($) {
	var students = [{
			firstname: "Petar",
			lastname: "Ivanov",
			grade: "3"
		}, {
			firstname: "Milena",
			lastname: "Grigorova",
			grade: "6"
		}, {
			firstname: "Gergana",
			lastname: "Borisova",
			grade: "12"
		}, {
			firstname: "Boyko",
			lastname: "Petrov",
			grade: "7"
		}],
		$holderDIV = $('<div class="holder" />');

	function addLine(lineData, classToAdd) {
		var $line = $('<div class="line" />'),
			$cell = $('<div class="cell" />'),
			$span = $('<span class="' + classToAdd + '" />');

		$line.append($cell.clone().append($span.clone(true).text(lineData.firstname)));
		$line.append($cell.clone().append($span.clone(true).text(lineData.lastname)));
		$line.append($cell.append($span.text(lineData.grade)));
		$holderDIV.append($line);
	}

	$(document).ready(function() {
		addLine({
			firstname: 'First Name',
			lastname: 'Last Name',
			grade: 'Grade'
		}, 'header');

		for (var i = 0; i < students.length; i += 1) {
			addLine(students[i], 'item');
		}

		$('.root').append($holderDIV);
	});
}(jQuery));