define(['chai', 'jquery', 'logic', 'ui'], function(chai, $, logic, ui) {
	var expect = chai.expect;

	describe('Test the sort behavior', function() {
		

		it("Without posts", function() {
			var data = [];

			var orderedData = logic.orderData('title', 'asc', data);

			expect(data[0]).to.equal(orderedData[0]);
		});

		it("By title ASC", function() {
			var data = [
				{
					"id": 1,
					"title": "Test",
					"body": "1",
					"postDate": "2014-07-29T11:19:35.437Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				},
				{
					"id": 2,
					"title": "Proba ",
					"body": "2 ",
					"postDate": "2014-07-29T11:19:39.988Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				},
				{
					"id": 3,
					"title": "Aaaa ",
					"body": "3 ",
					"postDate": "2014-07-29T11:19:43.942Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				}
			];

			var orderedData = logic.orderData('title', 'asc', data);

			expect(data[0].title).to.equal(orderedData[2].title);
		});

		it("By title DESC", function() {
			var data = [
				{
					"id": 1,
					"title": "Test",
					"body": "1",
					"postDate": "2014-07-29T11:19:35.437Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				},
				{
					"id": 2,
					"title": "Proba ",
					"body": "2 ",
					"postDate": "2014-07-29T11:19:39.988Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				},
				{
					"id": 3,
					"title": "Aaaa ",
					"body": "3 ",
					"postDate": "2014-07-29T11:19:43.942Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				}
			];

			var orderedData = logic.orderData('title', 'desc', data);

			expect(data[0].title).to.equal(orderedData[0].title);
		});

		it("By date ASC", function() {
			var data = [
				{
					"id": 1,
					"title": "Test",
					"body": "1",
					"postDate": "2014-07-29T11:19:35.437Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				},
				{
					"id": 2,
					"title": "Proba ",
					"body": "2 ",
					"postDate": "2014-07-29T11:19:39.988Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				},
				{
					"id": 3,
					"title": "Aaaa ",
					"body": "3 ",
					"postDate": "2014-07-29T11:19:43.942Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				}
			];

			var orderedData = logic.orderData('title', 'asc', data);

			expect(data[0].date).to.equal(orderedData[2].date);
		});

		it("By date DESC", function() {
			var data = [
				{
					"id": 1,
					"title": "Test",
					"body": "1",
					"postDate": "2014-07-29T11:19:35.437Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				},
				{
					"id": 2,
					"title": "Proba ",
					"body": "2 ",
					"postDate": "2014-07-29T11:19:39.988Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				},
				{
					"id": 3,
					"title": "Aaaa ",
					"body": "3 ",
					"postDate": "2014-07-29T11:19:43.942Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				}
			];

			var orderedData = logic.orderData('title', 'desc', data);

			expect(data[0].date).to.equal(orderedData[0].date);
		});
	});

	describe('Test the paging behavior', function() {
		it("Without posts", function() {
			var data = [],
				postPerPage = 8;

			pages = data.length/postPerPage;

			expect(pages).to.equal(0);
		});

		it("With posts", function() {
			var data = [
				{
					"id": 1,
					"title": "Test",
					"body": "1",
					"postDate": "2014-07-29T11:19:35.437Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				},
				{
					"id": 2,
					"title": "Proba ",
					"body": "2 ",
					"postDate": "2014-07-29T11:19:39.988Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				},
				{
					"id": 3,
					"title": "Aaaa ",
					"body": "3 ",
					"postDate": "2014-07-29T11:19:43.942Z",
					"user": {
					"id": 1,
					"username": "penjurov"
				}
				}
			],
			postPerPage = 1;

			pages = data.length/postPerPage;

			expect(pages).to.equal(3);
		});
	});
});
