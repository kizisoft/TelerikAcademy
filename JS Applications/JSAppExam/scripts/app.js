(function () {
	require.config({
		paths: {
			jquery: "libs/jquery.min",
			sammy: "libs/sammy-latest.min",
			handlebars: "libs/handlebars",
			kendo: "libs/kendo.web.min",
			Q: "libs/q.min",
			cryptojs: 'libs/cryptojs',
			sha1: 'libs/sha1',
			underscore: 'libs/underscore',
			httpRequest : "crowdShare/httpRequest",
			logic: "crowdShare/logic",
			ui: "crowdShare/ui",
			events: "crowdShare/events"
		}
	});

	require(["sammy", "ui", "logic", "events"], function (sammy, ui, logic) {
		var app = sammy("#main-content", function() {
			this.get("#/", function () {
				ui.initHomePage();
			});

			this.get("#/login", function () {
				ui.initLoginPage();
			});

			this.get("#/register", function () {
				ui.initRegisterPage();
			});

			this.get("#/logout", function () {
				logic.logout();
			});

			this.get("#/createpost", function () {
				ui.initCreatePostPage();
			});

			this.get("#/getposts", function () {
				ui.initGetPostsPage();
			});

		});

		app.run("#/");
	});
}());