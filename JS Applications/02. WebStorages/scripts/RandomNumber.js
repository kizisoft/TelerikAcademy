var RandomNumber = (function () {
    function RandomNumber() {
        this._number = [];
        for (var i = 0; i < 4; i += 1) {
            this._number.push(new RandomDigit(this.getNumber()));
        }
    }

    RandomNumber.prototype.getNumber = function getUsedDigits() {
        var digits = [],
            len = this._number.length;

        if (!len) {
            return [0];
        }

        for (var i = 0; i < len; i += 1) {
            digits.push(this._number[i].getDigit());
        }

        return digits;
    };

    RandomNumber.prototype.indexOf = function indexOf(digit) {
        for (var i = 0; i < 4; i += 1) {
            if (this._number[i].getDigit() === parseInt(digit, 10)) {
                return i;
            }
        }

        return -1;
    };

    return RandomNumber;
}());