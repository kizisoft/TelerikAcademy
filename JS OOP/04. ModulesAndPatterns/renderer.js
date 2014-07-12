var Renderer = (function () {
    var Renderer = (function () {
        function getLayer(layerName, x, y, width, height) {
            var canvas = document.createElement('canvas'),
                root = document.getElementById('root');

            canvas.style.position = 'absolute';
            root.style.position = 'absolute';
            canvas.style.left = x;
            root.style.left = x + 'px';
            canvas.style.top = y;
            root.style.top = y + 'px';
            canvas.width = width;
            root.style.width = width + 'px';
            canvas.height = height;
            root.style.height = height + 'px';
            canvas.id = layerName;

            root.appendChild(canvas);

            return canvas.getContext('2d');
        }

        function paint(layer, obj) {
            layer.beginPath();
            layer.strokeStyle = '#000';
            layer.fillStyle = obj.color;

            switch (obj.shape) {
                case SnakeModule.Constants.SHAPES.CIRCLE:
                    layer.arc(obj.position.x, obj.position.y, SnakeModule.Constants.RADIUS, 0, 2 * Math.PI);
                    break;
                case SnakeModule.Constants.SHAPES.RECT:
                    layer.rect(obj.position.x, obj.position.y, obj.width, obj.height);
                    break;
                case SnakeModule.Constants.SHAPES.IMAGE:
                    // TODO: Work with images
                    break;
                default :
                    throw new Error('No such shape :' + obj.shape);
            }

            layer.fill();
            layer.stroke();
        }

        function draw(gameObjects) {
            var i, len;

            len = gameObjects.length;
            for (i = 0; i < len; i += 1) {
                if (gameObjects[i].shape === SnakeModule.Constants.SHAPES.COMPLEX) {
                    this.draw(gameObjects[i]._body);
                } else {
                    paint(this.layer, gameObjects[i]);
                }
            }
        }

        function clear() {
            this.layer.clearRect(0, 0, this.width, this.height);
        }

        function Renderer(layerName, x, y, width, height) {
            this.name = layerName;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.layer = getLayer(this.name, this.x, this.y, this.width, this.height);
        }

        Renderer.prototype.draw = draw;
        Renderer.prototype.clear = clear;

        return Renderer;
    }());

    return Renderer;
}());