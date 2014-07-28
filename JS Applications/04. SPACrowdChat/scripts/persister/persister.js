define(['httpRequester'], function (hr) {
    var ERROR_URL = '#/error';

    var MainPersister = (function MainPersister() {
        var self;

        function MainPersister(url) {
            self = this;
            this.serviceUrl = url;
            this.error = null;
        }

        function errorRedirect(err) {
            self.error = {
                message: 'Can\'t receive data from the server!',
                error: err
            };
            window.location.href = ERROR_URL;
        }

        MainPersister.prototype.getAllMessages = function getAllMessages() {
            return hr.get(self.serviceUrl).then(function success(data) {
                return data;
            }, errorRedirect);
        };

        MainPersister.prototype.sendMessage = function sendMessage(message) {
            return hr.post(self.serviceUrl, message).then(function success(data) {
                return data;
            }, errorRedirect);
        };

        return MainPersister;
    }());

    return {
        getPersister: function (url) {
            return new MainPersister(url);
        }
    };
});