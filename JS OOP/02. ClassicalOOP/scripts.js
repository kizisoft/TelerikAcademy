DrawShapesModule = (function () {
    var _ctx;

    function draw(drawFunction) {
        _ctx.beginPath();
        drawFunction();
        _ctx.fill();
        _ctx.stroke();
    }

    var Rect = (function () {
        function Rect(x, y, width, height) {
            this.x = x || 0;
            this.y = y || 0;
            this.width = width || 0;
            this.height = height || 0;

            draw.call(this, function () {
                _ctx.rect(x, y, width, height);
            });
        }

        return Rect;
    }());

    var Circle = (function () {
        function Circle(x, y, r) {
            this.x = x || 0;
            this.y = y || 0;
            this.r = r || 0;

            draw.call(this, function () {
                _ctx.arc(x, y, r, 0, 2 * Math.PI);
            })
        }

        return Circle;
    }());

    var Line = (function () {
        function Line(x1, y1, x2, y2) {
            this.x1 = x1 || 0;
            this.y1 = y1 || 0;
            this.x2 = x2 || 0;
            this.y2 = y2 || 0;

            draw.call(this, function () {
                _ctx.moveTo(x1, y1);
                _ctx.lineTo(x2, y2);
            })
        }

        return Line;
    }());

    var init = function (ctx, lineWidth, strokeStyle, fillStyle) {
        if (!ctx) {
            throw new Error('The canvas context is required!');
        }

        _ctx = ctx;
        _ctx.lineWidth = lineWidth || 1;
        _ctx.strokeStyle = strokeStyle || '#000';
        _ctx.fillStyle = fillStyle || '#fff';
    };

    function DrawShapesModule() {
        return {
            Rect: Rect,
            Circle: Circle,
            Line: Line,
            init: init
        };
    }

    return new DrawShapesModule();
}());