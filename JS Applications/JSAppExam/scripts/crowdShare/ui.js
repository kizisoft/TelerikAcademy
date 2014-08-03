define(['jquery', 'handlebars', 'kendo'], function ($) {
	var START_MENU_SIZE = 300;

	var initHomePage = function() {
		var username = localStorage.getItem('crowdShareUserName');
		
		initPage('#menu', $('#menu-container'));

		$('#main-content').load('home.html', function() {
			if (username && username !=='' && username !=='null') {
				$('#logout').text('Welcome: ' + username + ' (Logout)');
			}
		});
	};

	var initLoginPage = function(chatItems) {
		initPage('#menu', $('#menu-container'));

		$('#main-content').load('login.html', function() {
			$('#login-nickname').kendoMaskedTextBox();
			$('#login-password').kendoMaskedTextBox();
			$('#login-button').kendoButton();
			$('#login-nickname').focus();
		});
	};

	var initRegisterPage = function() {
		initPage('#menu', $('#menu-container'));

		$('#main-content').load('register.html', function() {
			$('#register-nickname').kendoMaskedTextBox();
			$('#register-password').kendoMaskedTextBox();
			$('#repeat-register-password').kendoMaskedTextBox();
			$('#register-button').kendoButton();
			$('#register-nickname').focus();
		});
	};

	var initCreatePostPage = function(chatItems) {
		initPage('#menu', $('#menu-container'));

		$('#main-content').load('createPost.html', function() {
			$('#createpost-title').kendoMaskedTextBox();
			$('#createpost-body').kendoMaskedTextBox();
			$('#post-button').kendoButton();
			$('#createpost-title').focus();
		});
	};

	var initGetPostsPage = function(chatItems) {
		initPage('#menu', $('#menu-container'));

		$('#main-content').load('getPosts.html', function() {
			$('#getmessages-button').kendoButton();
			$('#search-title-body').kendoMaskedTextBox();
			$('#search-user').kendoMaskedTextBox();
			$('#posts-count').kendoMaskedTextBox();
			$('#search-user').focus();
		});
	};

	var showError = function(err) {
		$('#main-content').text(err.responseText);
	};

	var initPage = function (menu, container) {
		container.load('menu.html', function() {
			$(menu).kendoMenu();
		});
		$('#main-content').text(' ');
	};

	function drawKendoGrid(items, postsCount) {
		var postsTemplate = Handlebars.compile($('#posts-template').html());

		$('#posts-containter').html(postsTemplate({
			posts : items
		}));

		if ($('.k-grid').html()) {
			var grid = $('#posts-containter').data("kendoGrid");
			ds = grid.dataSource;
			ds.pageSize = postsCount;
		}
		else {
			$('#posts-containter').kendoGrid({
				dataSource: {
					pageSize: postsCount || 10
				},
				height: window.innerHeight - START_MENU_SIZE,
				groupable: true,
				sortable: true,
				filterable: true,
				pageable: {
					refresh: true,
					pageSizes: true,
					buttonCount: 5
				},
			});
		}
	}

	return {
		initHomePage: initHomePage,
		initLoginPage: initLoginPage,
		initRegisterPage: initRegisterPage,
		initCreatePostPage: initCreatePostPage,
		initGetPostsPage: initGetPostsPage,
		showError: showError,
		drawKendoGrid: drawKendoGrid
	};
});