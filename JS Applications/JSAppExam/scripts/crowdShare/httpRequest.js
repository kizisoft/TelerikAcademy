define(['Q'], function (Q) {
	var httpRequest = (function () {
		var getJSON = function(url, contentType, acceptType) {
			var deferred = Q.defer();
			Q.stopUnhandledRejectionTracking();

			$.ajax({
				url: url,
				type: 'GET',
				contentType : contentType || '',
				acceptType : acceptType || '',
				success: function (data) {
					deferred.resolve(data);
				},
				error: function (err) {
					deferred.reject(err);
				}
			});

			return deferred.promise;
		};

		var postJSON = function(url, contentType, acceptType, data, sessionKey) {
			var deferred = Q.defer(),
				type = 'PUT';

			if (data) {
				data = JSON.stringify(data);
				type = 'POST';
			}

			Q.stopUnhandledRejectionTracking();

			$.ajax({
				beforeSend: function (xhrObj) {
					xhrObj.setRequestHeader("x-sessionkey", sessionKey);
				},
				url: url,
				data: data,
				type: type,
				contentType: contentType,
				acceptType: acceptType,
				success: function (data) {
					deferred.resolve(data);
				},
				error: function (err) {
					deferred.reject(err);
				}
			});

			return deferred.promise;
		};

		return {
			getJSON: getJSON,
			postJSON: postJSON
		};
	}());
	return httpRequest;
});