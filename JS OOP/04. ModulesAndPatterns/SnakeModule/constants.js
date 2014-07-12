var SnakeModule = SnakeModule || {};
(function (Scope) {
    var Constants = (function () {
        function Constants() {
            this.POSITION = {
                x: 100,
                y: 100
            };
            this.SPEED_VECTOR = {
                x: 1,
                y: 0
            };
            this.SIZE = 5;
            this.RADIUS = 10;
            this.COLOR = '#FFFF00';
            this.HEAD_COLOR = '#FFCC00';
            this.APPLE_COLOR = '#BB3300';
            this.MAX_MOVES = this.RADIUS * 2;
            this.SPEED = 2;
            this.LIFES = 3;
            this.SHAPES = {
                DEFAULT: 'arc',
                CIRCLE: 'arc',
                RECT: 'rect',
                IMAGE: 'img',
                COMPLEX: 'complex'
            };
            this.CONTROL_1 = {
                left: 37,
                right: 39,
                up: 38,
                down: 40
            };
            this.CONTROL_2 = {
                left: 65,
                right: 68,
                up: 87,
                down: 83
            };
            this.DIRECTION = {
                LEFT: {x: -1, y: 0},
                RIGHT: {x: 1, y: 0},
                UP: {x: 0, y: -1},
                DOWN: {x: 0, y: 1}
            };
            this.PLAY_FIELD = {
                MIN_X: 10,
                MIN_Y: 10,
                MAX_X: 1024,
                MAX_Y: 768
            };
        }

        return new Constants();
    }());

    Scope.Constants = Constants;
}(SnakeModule));