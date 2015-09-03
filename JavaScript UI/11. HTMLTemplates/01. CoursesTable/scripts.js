/* globals document, Handlebars */
(function() {
	var courses = [{
		courseName: 'Title',
		date1: 'Date #1',
		date2: 'Date #2'
	}, {
		id: 1,
		courseName: 'Course Introduction',
		date1: 'Wed 18:00, 28-May-2014',
		date2: 'Thu 1400, 29-May-2014'
	}, {
		id: 2,
		courseName: 'Document Object Model',
		date1: 'Wed 18:00, 28-May-2014',
		date2: 'Thu 1400, 29-May-2014'
	}, {
		id: 3,
		courseName: 'HtML5 Canvas',
		date1: 'Wed 18:00, 28-May-2014',
		date2: 'Thu 1400, 29-May-2014'
	}, {
		id: 4,
		courseName: 'Kinetic JS Overview',
		date1: 'Wed 18:00, 28-May-2014',
		date2: 'Thu 1400, 29-May-2014'
	}, {
		id: 5,
		courseName: 'SVG and Raphael JS',
		date1: 'Wed 18:00, 28-May-2014',
		date2: 'Thu 1400, 29-May-2014'
	}];

	window.onload = function() {
		var coursesTemplateHtml = document.getElementById('courses-table-template').innerHTML,
			coursesTemplate = Handlebars.compile(coursesTemplateHtml);

		document.getElementById('courses-table').innerHTML = coursesTemplate({
			coursesGroup: courses
		});
	};
}());