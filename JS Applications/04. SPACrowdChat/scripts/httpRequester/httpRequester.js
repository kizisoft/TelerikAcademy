define(function () {
    function makeHttpRequest(verb, url, data) {
        var deferred = $.Deferred(),
            requestObject = {
                url: url,
                type: verb,
                contentType: 'application/json',
                timeout: 15000,
                success: function (result) {
                    deferred.resolve(result);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            };

        if (data) {
            requestObject.data =  JSON.stringify(data);
        }

        $.ajax(requestObject);
        return deferred.promise();
    }

    function getJASON(url) {
        return makeHttpRequest('GET', url);
    }

    function postJASON(url, data) {
        return makeHttpRequest('POST', url, data);
    }

    return {
        get: getJASON,
        post: postJASON
    };
});