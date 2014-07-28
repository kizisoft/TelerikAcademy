define(function () {
    var UI = (function () {
        function UI() {

        }

        UI.prototype.render = function render(messages, count) {
            var messagesLen = messages.length,
                len = Math.min(messagesLen, count),
                $ul = $('<ul />'),
                $li = $('<li />'),
                $span = $('<span />'),
                $p = $('<p />');

            for (var i = 1; i <= len; i += 1) {
                $ul.prepend($li.clone().append($span.clone().html(messages[messagesLen - i].by + ':'))
                    .append($p.clone().html(messages[messagesLen - i].text)));
            }

            return $ul;
        };

        return UI;
    }());

    return {
        getUI: function () {
            return new UI();
        }
    };
});