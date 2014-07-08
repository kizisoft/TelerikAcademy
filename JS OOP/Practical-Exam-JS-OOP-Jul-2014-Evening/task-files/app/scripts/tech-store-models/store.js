/* global define */

define(['tech-store-models/item'], function(Item) {
	var MIN_NAME = 6,
		MAX_NAME = 30;

	var Store = (function() {
		function sortLexic(items) {
			items.sort(function(a, b) {
				return a.name.localeCompare(b.name);
			});
		}

		function filterItemsByTypes(filterTypes) {
			var returnItems, len;

			len = filterTypes.length;
			returnItems = this._items.filter(function(item) {
				return filterTypes.indexOf(item.type) >= 0;
			});

			sortLexic(returnItems);
			return returnItems;
		}

		var addItem = function(item) {
			if (!(item instanceof Item)) {
				throw new Error('The object is not of type Item!');
			}

			this._items.push(item);
			return this;
		};

		var getAll = function() {
			var returnItems;

			returnItems = this._items.slice(0);
			sortLexic(returnItems);
			return returnItems;
		};

		var getSmartPhones = function() {
			return filterItemsByTypes.call(this, ['smart-phone']);
		};

		var getMobiles = function() {
			return filterItemsByTypes.call(this, ['smart-phone', 'tablet']);
		};

		var getComputers = function() {
			return filterItemsByTypes.call(this, ['pc', 'notebook']);
		};

		var filterItemsByPrice = function(options) {
			var returnItems, min, max;

			options = options || {};
			min = options.min || 0;
			max = options.max || Math.min();

			returnItems = this._items.filter(function(item) {
				return (item.price >= min && item.price <= max);
			});

			returnItems.sort(function(a, b) {
				// sort asccending
				return a.price - b.price;
			});

			return returnItems;
		};

		var filterItemsByType = function(filterType) {
			return filterItemsByTypes.call(this, [filterType]);
		};

		var filterItemsByName = function(partOfName) {
			var returnItems;
			partOfName = partOfName || '';

			returnItems = this._items.filter(function(item) {
				return (item.name.toLowerCase().indexOf(partOfName.toLowerCase()) >= 0);
			});

			sortLexic(returnItems);
			return returnItems;
		};

		var countItemsByType = function() {
			var returnItems, i, len;

			returnItems = [];
			for (i = 0, len = this._items.length; i < len; i += 1) {
				if (returnItems[this._items[i].type]) {
					returnItems[this._items[i].type]++;
				} else {
					returnItems[this._items[i].type] = 1;
				}
			}

			return returnItems;
		};

		function Store(name) {
			if (name.length < MIN_NAME || name.length > MAX_NAME) {
				throw new Error('Incorrect name size, should be ' + MIN_NAME + '..' + MAX_NAME + ' charachters long!');
			}

			this.name = name;
			this._items = [];
		}

		Store.prototype.addItem = addItem;
		Store.prototype.getAll = getAll;
		Store.prototype.getSmartPhones = getSmartPhones;
		Store.prototype.getMobiles = getMobiles;
		Store.prototype.getComputers = getComputers;
		Store.prototype.filterItemsByPrice = filterItemsByPrice;
		Store.prototype.filterItemsByType = filterItemsByType;
		Store.prototype.filterItemsByName = filterItemsByName;
		Store.prototype.countItemsByType = countItemsByType;

		return Store;
	}());

	return Store;
});