(function () {
    requirejs.config({
        paths: {
            'jquery': '../scripts/libs/jquery.min',
            'mocha': '../scripts/libs/mocha',
            'chai': '../scripts/libs/chai',
            'sinon': '../scripts/libs/sinon',
            'httpRequest' : '../scripts/crowdShare/httpRequest',
            'Q' : '../scripts/libs/q.min',
            'logic': '../scripts/crowdShare/logic',
            'sammy': "../scripts/libs/sammy-latest.min",
            'handlebars': "../scripts/libs/handlebars",
            'kendo': "../scripts/libs/kendo.web.min",
            'cryptojs': '../scripts/libs/cryptojs',
            'sha1': '../scripts/libs/sha1',
            'underscore': '../scripts/libs/underscore',
            'ui': "../scripts/crowdShare/ui",
            'events': "../scripts/crowdShare/events"
        }
    });

    require(['mocha', 'chai', 'sinon'], function () {
        mocha.setup('bdd');
        require(['mochaTests'], function() {
            mocha.run();
        });
    });
}());
