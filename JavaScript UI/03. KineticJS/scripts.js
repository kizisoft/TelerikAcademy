var x = [],
	y = 10,
	humans = [],
	mothers = [],
	fathers = [],
	children = [],
	roots = [];

// var familyMembers = [{
// 	mother: 'Rumqna',
// 	father: 'Stamen',
// 	children: ['Gancho', 'Mihaela']
// }, {
// 	mother: 'Stanka',
// 	father: 'Rumen',
// 	children: ['Stamen', 'Petq', 'Stoqn']
// }, {
// 	mother: 'Mariq',
// 	father: 'Ico',
// 	children: ['Ivo']
// }, {
// 	mother: 'Iva',
// 	father: 'Stefan',
// 	children: ['Joro']
// }, {
// 	mother: 'Diana',
// 	father: 'Pesho',
// 	children: ['Iva']
// }, {
// 	mother: 'Pavlina',
// 	father: 'Genadi',
// 	children: ['Jivka']
// }, {
// 	mother: 'Jivka',
// 	father: 'Joro',
// 	children: ['Stefani', 'Daniela']
// }, {
// 	mother: 'Petq',
// 	father: 'Ivo',
// 	children: ['Doncho', 'Monika']
// }, {
// 	mother: 'Ganka',
// 	father: 'Petur',
// 	children: ['Stefan', 'Rumqna']
// }];


var familyMembers = [{
	mother: 'Maria Petrova',
	father: 'Georgi Petrov',
	children: ['Teodora Petrova', 'Peter Petrov']
}, {
	mother: 'Petra Stamatova',
	father: 'Todor Stamatov',
	children: ['Teodor Stamatov', 'Boris Opanov', 'Maria Petrova']
}, {
	mother: 'Boriana Stamatova',
	father: 'Teodor Stamatov',
	children: ['Martin Stamatov', 'Albena Dimitrova']
}, {
	mother: 'Albena Dimitrova',
	father: 'Ivan Dimitrov',
	children: ['Doncho Dimitrov', 'Ivaylo Dimitrov']
}, {
	mother: 'Donika Dimitrova',
	father: 'Doncho Dimitrov',
	children: ['Vladimir Dimitrov', 'Iliana Dobreva']
}, {
	mother: 'Juliana Petrova',
	father: 'Peter Petrov',
	children: ['Dimitar Petrov', 'Galina Opanova']
}, {
	mother: 'Iliana Dobreva',
	father: 'Delian Dobrev',
	children: ['Dimitar Dobrev', 'Galina Pundiova']
}, {
	mother: 'Galina Pundiova',
	father: 'Martin Pundiov',
	children: ['Dimitar Pundiov', 'Todor Pundiov']
}, {
	mother: 'Maria Pundiova',
	father: 'Dimitar Pundiov',
	children: ['Georgi Pundiov', 'Stoian Pundiov']
}, {
	mother: 'Dobrinka Pundiova',
	father: 'Georgi Pundiov',
	children: ['Pavel Pundiov', 'Marian Pundiov']
}, {
	mother: 'Elena Pundiova',
	father: 'Marian Pundiov',
	children: ['Kamen Pundiov', 'Hristina Ivancheva']
}, {
	mother: 'Hristina Ivancheva',
	father: 'Martin Ivanchev',
	children: ['Kamen Ivanchev', 'Evgeny Ivanchev']
}, {
	mother: 'Maria Ivancheva',
	father: 'Kamen Ivanchev',
	children: ['Ivo Ivanchev', 'Delian Ivanchev']
}, {
	mother: 'Nadejda Ivancheva',
	father: 'Ivo Ivanchev',
	children: ['Petio Ivanchev', 'Marin Ivanchev']
}, {
	mother: 'Natalia Ivancheva',
	father: 'Delian Ivanchev',
	children: ['Galina Hristova']
}, {
	mother: 'Galina Opanova',
	father: 'Boian Opanov',
	children: ['Maria Opanova', 'Patar Opanov']
}, {
	mother: 'Galina Hristova',
	father: 'Marin Hristov',
	children: ['Petar Hristov', 'Kamen Hristov', 'Ivan Hristov']
}, {
	mother: 'Simona Hristova',
	father: 'Kamen Hristov',
	children: ['Elena Hristova', 'Valeria Hristova']
}];

function buildHumanDetails(inMother, inFather, inChildren, inGender) {
	return {
		level: -1,
		mother: inMother || false,
		father: inFather || false,
		children: inChildren || [],
		gender: inGender || false
	};
}

function synchronizeHumans(human, mother, father, children, gender) {
	if (humans[human]) {
		humans[human].mother = mother || humans[human].mother;
		humans[human].father = father || humans[human].father;
		humans[human].gender = gender || false;
		for (var i = 0; i < children.length; i += 1) {
			humans[human].children.push(children[i]);
		}
	} else {
		var newHumanDetails = buildHumanDetails(mother, father, children, false);
		humans[human] = newHumanDetails;
	}
}

function initializeData() {
	for (var i = 0; i < familyMembers.length; i += 1) {
		mothers[i] = familyMembers[i].mother;
		fathers[i] = familyMembers[i].father;
		var childrenId = [];
		for (var j = 0; j < familyMembers[i].children.length; j += 1) {
			childrenId[j] = children.push(familyMembers[i].children[j]) - 1;
			synchronizeHumans(children[childrenId[j]], mothers[i], fathers[i], []);
		}

		synchronizeHumans(mothers[i], false, false, childrenId, true);
		synchronizeHumans(fathers[i], false, false, childrenId);
	}

	findRoots();
	for (i = 0; i < roots.length; i += 1) {
		levelTree(roots[i], 0);
	}
}

function findRoots() {
	for (var human in humans) {
		if (!humans[human].mother) {
			roots.push(human);
		}
	}
}

function setCoupleLevel(human, level) {
	if (humans[human].level < 0) {
		var index = mothers.indexOf(human);
		if (index >= 0) {
			if (humans[fathers[index]].level >= 0) {
				level = humans[fathers[index]].level;
			}
		} else {
			index = fathers.indexOf(human);
			if (index >= 0) {
				if (humans[mothers[index]].level >= 0) {
					level = humans[mothers[index]].level;
				}
			}
		}
	} else {
		var index = mothers.indexOf(human);
		if (index >= 0 && humans[fathers[index]].level < 0) {
			humans[fathers[index]].level = humans[human].level;
		} else {
			index = fathers.indexOf(human);
			if (index >= 0 && humans[mothers[index]].level < 0) {
				humans[mothers[index]].level = humans[human].level;
			}
		}
	}

	return level;
}

function levelTree(human, level) {
	level = setCoupleLevel(human, level);
	humans[human].level = level;
	for (var i = 0; i < humans[human].children.length; i += 1) {
		levelTree(children[humans[human].children[i]], level + 1);
	}
}

function getStage(inX, inY) {
	return new Kinetic.Stage({
		container: 'kinetic-container',
		width: inX,
		height: inY
	});
}

function drawHumanNode(layer, human, inX, inY) {
	var radius = 10;

	if (humans[human].gender) {
		radius = 20;
	}

	var text = new Kinetic.Text({
		x: inX + 20,
		y: inY + 10,
		fill: '#000',
		text: human + ' ' + humans[human].level,
		fontSize: 16
	});

	var rect = new Kinetic.Rect({
		x: inX,
		y: inY,
		width: text.getSize().width + 40,
		height: text.getSize().height + 20,
		fill: '#BFFFBF',
		stroke: '#000',
		strokeWidth: 0.3,
		cornerRadius: radius
	});

	layer.add(rect, text);

	return rect.getSize();
}

function drawTree(layer, human, level) {
	if (!x[level]) {
		x[level] = 0;
	}

	var offset = drawHumanNode(layer, human, x[level], y);
	x[level] += offset.width + 40;
	y = humans[human].level * (offset.height + 60);

	for (var i = 0; i < humans[human].children.length; i += 1) {
		drawTree(layer, children[humans[human].children[i]], level);
	}
}

window.onload = function() {
	var stage = getStage(1300, 2000),
		layer = new Kinetic.Layer();

	initializeData();
	for (var i = 0; i < roots.length; i += 1) {
		drawTree(layer, roots[i], humans[roots[i]].level);
	}

	stage.add(layer);

	console.log('end');
};