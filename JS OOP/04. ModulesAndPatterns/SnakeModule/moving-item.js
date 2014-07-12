var SnakeModule = SnakeModule || {};
(function (Scope) {
    var MovingItem = (function () {
        function move() {
            this.position.x += this.speedVector.x * Scope.Constants.SPEED;
            this.position.y += this.speedVector.y * Scope.Constants.SPEED;
        }

        function MovingItem(shape, position, speedVector, color, img) {
            Scope.Item.call(this, shape, position, color, img);
            this.speedVector = speedVector || Scope.Constants.SPEED_VECTOR;
        }

        MovingItem.prototype = new Scope.Item();
        MovingItem.prototype.constructor = MovingItem;

        MovingItem.prototype.move = move;

        return MovingItem;
    }());

    Scope.MovingItem = MovingItem;
}(SnakeModule));