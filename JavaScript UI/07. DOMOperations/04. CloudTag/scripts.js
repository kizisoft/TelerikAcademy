(function() {
	var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"];

	function calcStatistics(tags) {
		var statistics = [],
			total = 0,
			min = Math.min(),
			max = Math.max();

		for (var i = 0; i < tags.length; i += 1) {
			if (statistics[tags[i]]) {
				statistics[tags[i]] += 1;
			} else {
				statistics[tags[i]] = 1;
				total += 1;
			}
		}

		for (var item in statistics) {
			if (min > statistics[item]) {
				min = statistics[item];
			}

			if (max < statistics[item]) {
				max = statistics[item];
			}
		}

		return {
			statistics: statistics,
			total: total,
			min: min,
			max: max
		};
	}

	function generateTagCloud(tags, minFontSize, maxFontSize) {
		var stat = calcStatistics(tags),
			fragment = document.createDocumentFragment();

		for (var item in stat.statistics) {
			var coef = (maxFontSize - minFontSize) / (stat.max - stat.min) * (stat.statistics[item] - stat.min) + minFontSize,
				tag = document.createElement('span');

			console.log(coef);

			tag.innerHTML = ' ' + item + ' ';
			tag.style.fontSize = coef + 'px';
			fragment.appendChild(tag);
		}

		return fragment;
	}


	window.onload = function() {
		var tagCloud = generateTagCloud(tags, 17, 42);

		document.getElementById('root').appendChild(tagCloud);
	};
}());