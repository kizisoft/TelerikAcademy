(function() {
	var todos = [{
		label: 'Alabala alabala 1',
		description: '1 Alabala alabala 1 1 Alabala alabala 1 1 Alabala alabala 1 1 Alabala alabala 1 1 Alabala alabala 1'
	}, {
		label: 'Alabala alabala 2',
		description: '2 Alabala alabala 2 2 Alabala alabala 2 2 Alabala alabala 2 2 Alabala alabala 2 2 Alabala alabala 2'
	}];

	var shortDescription,
		description,
		containerTODOs;

	function generateTODOList(todos) {
		var containerMain = document.createElement('div'),
			containerAdd = document.createElement('div'),
			header = document.createElement('header'),
			shortDescriptionLabel = document.createElement('label'),
			descriptionLabel = document.createElement('label'),
			addButton = document.createElement('button');

		shortDescription = document.createElement('input');
		description = document.createElement('textarea');
		containerTODOs = document.createElement('ul');

		containerMain.classList.add('container-todo-list-main');
		containerAdd.classList.add('container-todo-list-add');
		containerTODOs.classList.add('container-todo-list');
		header.innerHTML = 'TODO List';
		shortDescription.type = 'text';
		shortDescription.name = 'label';
		shortDescriptionLabel.innerHTML = 'Short description:';
		descriptionLabel.innerHTML = 'Description:';
		description.name = 'description';
		addButton.innerHTML = 'Add';

		containerMain.appendChild(header);
		containerAdd.appendChild(shortDescriptionLabel);
		containerAdd.appendChild(shortDescription);
		containerAdd.appendChild(descriptionLabel);
		containerAdd.appendChild(description);
		containerAdd.appendChild(addButton);
		containerMain.appendChild(containerAdd);
		containerMain.appendChild(containerTODOs);

		for (var i = 0; i < todos.length; i += 1) {
			var todoItem = createTODOItem(todos[i]);

			if (todoItem) {
				containerTODOs.appendChild(todoItem);
			}
		}

		document.getElementById('root').appendChild(containerMain);

		addButton.addEventListener('click', onAddButtonClick, false);
		var todoItems = document.querySelectorAll('.container-todo-list li');
		for (var j = 0, len = todoItems.length; j < len; j += 1) {
			todoItems[j].addEventListener('click', onTODOClick, false);
			todoItems[j].firstElementChild.firstElementChild.addEventListener('click', onDeleteClick, false);
		}

		return containerMain;
	}

	function createTODOItem(todoObj) {
		var container = document.createElement('li'),
			shortInfo = document.createElement('div'),
			description = document.createElement('div'),
			deleteItem = document.createElement('span');

		deleteItem.innerHTML = 'X';
		shortInfo.innerHTML = todoObj.label;
		shortInfo.classList.add('label');
		shortInfo.appendChild(deleteItem);

		description.innerHTML = todoObj.description;
		description.classList.add('description');
		description.style.display = 'none';


		container.classList.add('container-todo-list-item');
		container.appendChild(shortInfo);
		container.appendChild(description);

		return container;
	}

	function onAddButtonClick() {
		var label = document.getElementsByName('label')[0].value,
			description = document.getElementsByName('description')[0].value;

		if (label) {
			var todoItem = createTODOItem({
				label: label,
				description: description
			});

			containerTODOs.appendChild(todoItem);
			todoItem.addEventListener('click', onTODOClick, false);
			todoItem.firstElementChild.firstElementChild.addEventListener('click', onDeleteClick, false);
		}
	}

	function onTODOClick() {
		if (this.lastElementChild.style.display === 'none') {
			this.lastElementChild.style.display = 'block';
		} else {
			this.lastElementChild.style.display = 'none';
		}
	}

	function onDeleteClick() {
		this.parentElement.parentElement.parentElement.removeChild(this.parentElement.parentElement);
	}

	window.onload = function() {
		var todoList = generateTODOList(todos);
	};
}());