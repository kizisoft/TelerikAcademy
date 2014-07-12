var Controls = (function () {
    var snakes = [];

    function onKeyDown(event) {
        for (var i = 0, len = snakes.length; i < len; i += 1) {
            var snake = snakes[i].snake;
            switch (event.keyCode) {
                case snakes[i].left:
                    snake.setSpeedVector(SnakeModule.Constants.DIRECTION.LEFT);
                    break;
                case snakes[i].right:
                    snake.setSpeedVector(SnakeModule.Constants.DIRECTION.RIGHT);
                    break;
                case snakes[i].up:
                    snake.setSpeedVector(SnakeModule.Constants.DIRECTION.UP);
                    break;
                case snakes[i].down:
                    snake.setSpeedVector(SnakeModule.Constants.DIRECTION.DOWN);
                    break;
                default :
            }
        }
    }

    var addControls = function addControls(snake, controls) {
        snakes.forEach(function () {
            if (this.snake === snake) {
                throw new Error('This snake already exist!');
            }
        });

        snakes.push({
            snake: snake,
            left: controls.left,
            right: controls.right,
            up: controls.up,
            down: controls.down
        });

        document.body.addEventListener('keydown', onKeyDown);
    };

    return {
        addControls: addControls
    };
}());