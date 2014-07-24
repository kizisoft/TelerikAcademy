var TYPES = (function () {
    return{
        NONE: 'none',
        RAM: 'ram',
        SHEEP: 'sheep',
        contains: function contains(value) {
            for (var item in this) {
                if (this.hasOwnProperty(item)) {
                    if (this[item] === value) {
                        return true;
                    }
                }
            }

            return false;
        }
    };
}());