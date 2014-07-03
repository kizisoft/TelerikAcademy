(function () {
    var canvas = document.getElementById('main-canvas'),
        ctx = canvas.getContext('2d'),
        rect, circle;

    DrawShapesModule.init(ctx);
    rect = new DrawShapesModule.Rect(50, 100, 200, 100);
    console.log('Rect(x = ' + rect.x + ', y = ' + rect.y + ', width = ' + rect.width + ', height = ' + rect.height + ')');

    DrawShapesModule.init(ctx, null, null, '#ff0');
    circle = new DrawShapesModule.Circle(300, 300, 50);
    console.log('Circle(x = ' + circle.x + ', y = ' + circle.y + ', r = ' + circle.r + ')');

    DrawShapesModule.init(ctx);
    line = new DrawShapesModule.Line(350, 150, 550, 150);
    console.log('Line(x1 = ' + line.x1 + ', y1 = ' + line.y1 + ', x2 = ' + line.x2 + ', y2 = ' + line.y2 + ')');
}());