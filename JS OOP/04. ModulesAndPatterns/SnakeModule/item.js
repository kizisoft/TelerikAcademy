var SnakeModule = SnakeModule || {};
(function (Scope) {
    var Item = (function () {

        function Item(shape, position, color, img) {
            this.position = position || Scope.Constants.POSITION;
            this.color = color || Scope.Constants.COLOR;
            this.img = img || '';
            this.shape = shape || Scope.Constants.SHAPES.DEFAULT;
            this.isAlive = true;
        }

        return Item;
    }());

    Scope.Item = Item;
}(SnakeModule));