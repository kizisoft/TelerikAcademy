var SnakeModule = SnakeModule || {};
(function (Scope) {
    var Snake = (function () {
        function move() {
            var i, swap, previousItemSpeed;

            Scope.MovingItem.prototype.move.call(this);
            this._moves += Scope.Constants.SPEED;

            if (this._moves >= Scope.Constants.MAX_MOVES) {
                this._moves = 0;
                previousItemSpeed = this.speedVector;
                for (i = 0; i < this.size; i += 1) {
                    swap = this._body[i].speedVector;
                    this._body[i].speedVector = previousItemSpeed;
                    previousItemSpeed = swap;
                }
            }

            for (i = 0; i < this.size; i += 1) {
                this._body[i].move();
            }
        }

        function setSpeedVector(speedVector) {
            this.speedVector = speedVector;
        }

        function decreaseLife() {
            this.lifes--;
            if (this.lifes === 0) {
                this.isAlive = false;
            }
        }

        function eatApple() {
            var itemPosition,
                last;

            last = this._body[this.size-1];
            this.size++;
            itemPosition = {
                x: last.position.x - 2 * Scope.Constants.RADIUS * last.speedVector.x,
                y: last.position.y - 2 * Scope.Constants.RADIUS * last.speedVector.y
            };
            this._body.push(new Scope.MovingItem(Scope.Constants.SHAPES.CIRCLE, itemPosition, last.speedVector, last.color));
        }

        function Snake(position, speedVector, size, color, headColor) {
            var itemPosition;

            this._body = [];
            this._moves = 0;

            Scope.MovingItem.call(this, Scope.Constants.SHAPES.COMPLEX, position, speedVector, color);
            this.size = size || Scope.Constants.SIZE;
            this.headColor = headColor || Scope.Constants.HEAD_COLOR;
            this.lifes = Scope.Constants.LIFES;

            for (var i = 0; i < this.size; i += 1) {
                itemPosition = {
                    x: (this.position.x + i * 2 * Scope.Constants.RADIUS),
                    y: this.position.y
                };
                this._body.unshift(new Scope.MovingItem(Scope.Constants.SHAPES.CIRCLE, itemPosition, this.speedVector, this.color));
            }

            this._body[0].color = Scope.Constants.HEAD_COLOR;
        }

        Snake.prototype = new Scope.MovingItem();
        Snake.prototype.constructor = Snake;

        Snake.prototype.move = move;
        Snake.prototype.setSpeedVector = setSpeedVector;
        Snake.prototype.decreaseLife = decreaseLife;
        Snake.prototype.eatApple = eatApple;

        return Snake;
    }());

    Scope.Snake = Snake;
}(SnakeModule));