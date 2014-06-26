var domModule = (function() {
	function DomModule() {
		var MAX_BUFFER = 100,
			buffers = [];

		function createFragmentObject(buffer, elementToAdd) {
			var docFragment = document.createDocumentFragment();

			docFragment.appendChild(elementToAdd);
			return {
				count: 1,
				docFragment: docFragment
			};
		}

		this.appendChild = function(elementToAdd, parentElement) {
			var parent = document.querySelector(parentElement);

			if (parent) {
				parent.appendChild(elementToAdd);
			}
		};

		this.removeChild = function(parentElement, elementToRemove) {
			var parent = document.querySelector(parentElement),
				element = document.querySelector(elementToRemove);

			if (element && parent) {
				parent.removeChild(element);
			}
		};

		this.addHandler = function(parentElement, eventToHandle, functionToAttach) {
			var element = document.querySelectorAll(parentElement);

			if (!element || !element.length) {
				return;
			}

			for (var i = 0; i < element.length; i += 1) {
				element[i].addEventListener(eventToHandle, functionToAttach);
			}
		};

		this.appendToBuffer = function(container, elementToAdd) {
			if (!document.querySelector(container)) {
				return;
			}

			if (buffers[container]) {
				buffers[container].count += 1;
				buffers[container].docFragment.appendChild(elementToAdd);
				if (buffers[container].count >= MAX_BUFFER) {
					document.querySelector(container).appendChild(buffers[container].docFragment);
					delete buffers[container];
				}
			} else {
				buffers[container] = createFragmentObject(buffers[container], elementToAdd);
			}
		};
	}

	return new DomModule();
}());