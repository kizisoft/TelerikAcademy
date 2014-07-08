/* global define */

define(function() {
	var TYPES = ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet'],
		MIN_NAME = 6,
		MAX_NAME = 40;

	var Item = (function() {
		function isFloat(n) {
			return n === +n && n !== (n | 0);
		}

		function Item(type, name, price) {
			if (TYPES.indexOf(type) < 0) {
				throw new Error('Unknown type!');
			}

			if (name.length < MIN_NAME || name.length > MAX_NAME) {
				throw new Error('Incorrect name size, should be ' + MIN_NAME + '..' + MAX_NAME + ' charachters long!');
			}

			if (!(isFloat(price))) {
				throw new Error('The price should be floating point value!');
			}

			this.type = type;
			this.name = name;
			this.price = price;
		}

		return Item;
	}());

	return Item;
});