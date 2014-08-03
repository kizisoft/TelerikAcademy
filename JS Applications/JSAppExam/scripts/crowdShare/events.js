define(['jquery', 'logic'], function ($, logic) {
	// lOG IN
	$(document).on("click", "#login-button", function(){
		var username = $('#login-nickname').val(),
			password = $('#login-password').val();

		if (username.length<6 || username.length>40) {
			alert('Username must be between 6 and 40 symbols!');
		}
		else {
			if (password !== '' && username !== '') {
				logic.login(username, password);
			}
			else {
				alert('Please enter correct data!');
			}
		}
	});

	// REGISTER
	$(document).on("click", "#register-button", function(){
		var username = $('#register-nickname').val(),
			password = $('#register-password').val(),
			repeatPassword = $('#repeat-register-password').val();

		if (username.length<6 || username.length>40) {
			alert('Username must be between 6 and 40 symbols!');
		}
		else {
			if (password !== repeatPassword) {
				alert("The passwords don't match!");
			}
			else {
				if (password !== '' && username !== '') {
					logic.registerAccount(username, password);
				}
				else {
					alert('Please enter correct data!');
				}
			}
		}
	});

	// CREATE POST
	$(document).on("click", "#post-button", function(){
		var title = $('#createpost-title').val(),
			body = $('#createpost-body').val();

		if (title !== '' && body !== '') {
			logic.postMessage(title, body);
		}
		else {
			alert('Please enter correct data!');
		}
	});

	// GET POSTS
	$(document).on("click", "#getmessages-button", function(){
		var searchUser = $('#search-user').val(),
			searchTitleBody = $('#search-title-body').val(),
			postsCount = $('#posts-count').val();
		
		logic.getMessages(searchUser, searchTitleBody, postsCount);
	});

	// Get sorting
	$(document).on("click", ".k-header", function () {
		var grid = $('#posts-containter').data("kendoGrid"),
			ds = grid.dataSource,
			sort = ds.sort();

		if (sort) {
			logic.orderData(sort[0].field, sort[0].dir, grid._data);
		}
	});
});