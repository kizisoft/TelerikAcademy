(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery-2.1.1.min',
            'sammy': 'libs/sammy-latest.min',
            'crowd-chat': 'crowdchat',
            'persister': 'persister/persister',
            'ui-control': 'ui-control/ui-control',
            'httpRequester': 'httpRequester/httpRequester'
        }
    });

    require(['jquery', 'sammy', 'crowd-chat'], function ($, sammy, cc) {
        var controller, app;

        controller = cc.getCrowdChatController('http://crowd-chat.herokuapp.com/posts');
        controller.setEventsListeners('#root');

        app = sammy('#root', function () {
            this.get('#/', function () {
                if (controller.isUserLogged()) {
                    window.location.href = '#/chat';
                } else {
                    controller.loadLogin();
                }
            });

            this.get('#/error', function () {
                clearInterval(controller.setIntervalID);
                window.location.href = '#/';
            });

            this.get('#/logout', function () {
                controller.logoutUser();
            });

            this.get('#/chat', function () {
                if (controller.isUserLogged()) {
                    controller.loadCrowdChat();
                } else {
                    window.location.href = '#/';
                }
            });
        });

        app.run('#/');
    });
}());