var RandomDigit = (function () {
    function RandomDigit(usedDigits) {
        if (!usedDigits || !(usedDigits instanceof Array)) {
            throw new Error('The parameter for already used digits should be an Array of digits!');
        }

        do {
            this._digit = getRandomInt(0, 9);
        } while (usedDigits.indexOf(this._digit) >= 0);
    }

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    RandomDigit.prototype.getDigit = function getDigit() {
        return this._digit;
    };

    return RandomDigit;
}());