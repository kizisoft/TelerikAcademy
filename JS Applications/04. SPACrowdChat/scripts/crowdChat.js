define(['jquery', 'persister', 'ui-control'], function ($, persister, ui) {
    var REFRESH_TIME = 5000,
        MAX_MESSAGE_SHOW = 50;

    var CrowdChatController = (function () {
        function CrowdChatController(url) {
            this.serviceUrl = url;
            this.persister = persister.getPersister(url);
            this.ui = ui.getUI();
            this.setIntervalID = null;
        }

        function loadView(path) {
            var deferred = $.Deferred();

            $.get(path).then(function (result) {
                return deferred.resolve(result);
            });

            return deferred.promise();
        }

        function saveUserToSessionStorage(userName) {
            sessionStorage.setItem('crowd-chat-username', userName);
        }

        CrowdChatController.prototype.refreshMessageFromServer = function refreshMessageFromServer() {
            var self = this;

            self.persister.getAllMessages().then(function (messages) {
                var renderedMessages = self.ui.render(messages, MAX_MESSAGE_SHOW),
                    $content = $('#main-chat-content').empty();
                $content.append(renderedMessages);
                $content.scrollTop(10000)
            });
        };

        CrowdChatController.prototype.sendMessageToServer = function sendMessageToServer() {
            var self = this,
                $inputElement = $('#user-msg'),
                message = $inputElement.val();

            if (message) {
                self.persister.sendMessage({
                    user: self.getUserName(),
                    text: message
                }).then(function () {
                    self.refreshMessageFromServer();
                });
            }

            $inputElement.val('').focus();
        };

        CrowdChatController.prototype.logoutUser = function logoutUser() {
            clearInterval(this.setIntervalID);
            sessionStorage.removeItem('crowd-chat-username');
            window.location.href = '#/';
        };

        CrowdChatController.prototype.getUserName = function getUserName() {
            return sessionStorage.getItem('crowd-chat-username');
        };

        CrowdChatController.prototype.isUserLogged = function isUserLogged() {
            return !!this.getUserName();
        };

        CrowdChatController.prototype.loadLogin = function loadLogin() {
            return  loadView('views/login.html').then(function (data) {
                $('#root').html(data);
            });
        };

        CrowdChatController.prototype.loadCrowdChat = function loadCrowdChat() {
            var self = this;

            return loadView('views/crowd-chat.html').then(function (data) {
                $('#root').html(data);
                $('#name').html(self.getUserName());
                self.refreshMessageFromServer();
                if (!self.setIntervalID) {
                    self.setIntervalID = setInterval(function () {
                        self.refreshMessageFromServer();
                    }, REFRESH_TIME);
                }
            });
        };

        CrowdChatController.prototype.setEventsListeners = function setEventsListeners(selector) {
            var self = this,
                wrapper = $(selector);

            wrapper.on('click', '#btn-login', function () {
                var userName = $('#user-name').val();

                saveUserToSessionStorage(userName);
                window.location.href = '#/chat';
            });

            wrapper.on('click', '#btn-logout', function () {
                self.logoutUser();
            });

            wrapper.on('click', '#btn-send', function () {
                self.sendMessageToServer();
            });
        };

        return CrowdChatController;
    }());

    return {
        getCrowdChatController: function (url) {
            return new CrowdChatController(url);
        }
    };
});