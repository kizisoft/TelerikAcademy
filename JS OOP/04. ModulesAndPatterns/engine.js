var EngineModule = (function () {
    var players = [],
        staticObjects = [],
        rendererMoving,
        rendererStatic;

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function generateApples(count) {
        var position,
            consts = SnakeModule.Constants;
        for (var i = 0; i < count; i += 1) {
            position = {
                x: getRandomInt(consts.RADIUS * 2 + consts.PLAY_FIELD.MIN_X, consts.PLAY_FIELD.MIN_X + consts.PLAY_FIELD.MAX_X - consts.RADIUS * 2),
                y: getRandomInt(consts.RADIUS * 2 + consts.PLAY_FIELD.MIN_Y, consts.PLAY_FIELD.MIN_Y + consts.PLAY_FIELD.MAX_Y - consts.RADIUS * 2)
            };
            staticObjects.push(new SnakeModule.Item(null, position, consts.APPLE_COLOR));
        }
    }

    function hasCollideWithBorders(player) {
        var head = player._body[0];
        return head.position.x <= rendererMoving.x ||
            head.position.x + SnakeModule.Constants.RADIUS >= rendererMoving.width ||
            head.position.y <= rendererMoving.y ||
            head.position.y + SnakeModule.Constants.RADIUS >= rendererMoving.height;
    }

    function hasCollideWithStaticObjects(player, staticObject) {
        var head = player._body[0];
        return Math.sqrt((staticObject.position.x - head.position.x) *
            (staticObject.position.x - head.position.x) +
            (staticObject.position.y - head.position.y) *
            (staticObject.position.y - head.position.y)) < 2 * SnakeModule.Constants.RADIUS;
    }

    function detectCollisions() {
        for (var i = 0; i < players.length; i += 1) {
            if (hasCollideWithBorders(players[i])) {
                players[i].decreaseLife();
                players[i].position = SnakeModule.Constants.POSITION;
                players[i].speedVector = SnakeModule.Constants.SPEED_VECTOR;
            }

            for (var j = 0; j < staticObjects.length; j += 1) {
                if (hasCollideWithStaticObjects(players[i], staticObjects[j])) {
                    players[i].eatApple();
                    staticObjects[j].isAlive = false;
                }
            }
        }
    }

    function deleteDeathObjects() {
        var result = false;
        for (var i = 0; i < staticObjects.length; i += 1) {
            if (!staticObjects[i].isAlive) {
                staticObjects.splice(i, 1);
                result = true;
            }
        }

        return result;
    }

    function animationFrame() {
        rendererMoving.clear();
        if (deleteDeathObjects()) {
            rendererStatic.clear();
            if (!staticObjects.length) {
                generateApples(5);
            }
        }

        rendererMoving.draw(players);
        rendererStatic.draw(staticObjects);

        for (var i = 0; i < players.length; i += 1) {
            players[i].move();
        }

        detectCollisions();

        // TODO: make it work with second Player
        if (players[0].isAlive) {
            window.requestAnimationFrame(animationFrame);
        }
    }

    function Engine() {
        players.push(new SnakeModule.Snake());
        // players.push(new SnakeModule.Snake(null, null, null, '#00CC00', '#CCAA00'));
        Controls.addControls(players[0], SnakeModule.Constants.CONTROL_1);
        // Controls.addControls(players[1], SnakeModule.Constants.CONTROL_2);

        generateApples(5);

        var consts = SnakeModule.Constants.PLAY_FIELD;
        rendererMoving = new Renderer('moving', consts.MIN_X, consts.MIN_Y, consts.MAX_X, consts.MAX_Y);
        rendererStatic = new Renderer('static', consts.MIN_X, consts.MIN_Y, consts.MAX_X, consts.MAX_Y);

        window.requestAnimationFrame(animationFrame);
    }

    return new Engine();
}());