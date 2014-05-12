// Task 1
document.getElementById("bt-task1").onclick = function() {
    var n,
        i,
        res = "";

    n = parseInt(document.getElementById("in-task1").value, 10);

    if (isNaN(n)) {
        res = "Not an integer number!\r\n";
    } else {
        for (i = 1; i <= n; i++) {
            res = res + i + "\r\n";
        }
    }

    document.getElementById("res-task1").value = res;
};

// Task 2
document.getElementById("bt-task2").onclick = function() {
    var n,
        i,
        res = "";

    n = parseInt(document.getElementById("in-task2").value, 10);

    if (isNaN(n)) {
        res = "Not an integer number!\r\n";
    } else {
        for (i = 1; i <= n; i++) {
            if (i % 3 === 0 && i % 7 === 0) {
                continue;
            }

            res = res + i + "\r\n";
        }
    }

    document.getElementById("res-task2").value = res;
};

// Task 3
document.getElementById("bt-task3").onclick = function() {
    var n,
        i,
        res = "",
        range,
        rndNumber,
        minNumber = Math.min(),
        maxNumber = Math.max();

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    n = parseInt(document.getElementById("in-task3").value, 10);

    if (isNaN(n)) {
        res = "Not an integer number!\r\n";
    } else {
        range = n * 10;
        res = "[ ";

        for (i = 1; i <= n; i++) {
            rndNumber = getRandomInt(-range, range);

            if (minNumber > rndNumber) {
                minNumber = rndNumber;
            }

            if (maxNumber < rndNumber) {
                maxNumber = rndNumber;
            }

            res = res + rndNumber;
            if (i === n) {
                continue;
            }

            res = res + ", ";
        }
    }

    document.getElementById("res-task31").value = res + " ]";
    document.getElementById("res-task32").innerText = "Min value = " + minNumber + " Max value = " + maxNumber;
};

// Task 4
document.getElementById("bt-task4").onclick = function() {
    var documentProps,
        windowProps,
        navigatorProps;

    function getPropertiesByName(obj) {
        var prop,
            minProp,
            maxProp;

        for (prop in obj) {
            if (maxProp === undefined || prop > maxProp) {
                maxProp = prop;
            }

            if (minProp === undefined || prop < minProp) {
                minProp = prop;
            }
        }

        return [minProp, maxProp];
    }

    documentProps = getPropertiesByName(document);
    windowProps = getPropertiesByName(window);
    navigatorProps = getPropertiesByName(navigator);


    document.getElementById("res-task4").value = "document:\r\n min = " + documentProps[0] + "\r\n max = " + documentProps[1] + "\r\n\n" +
        "window:\r\n min = " + windowProps[0] + "\r\n max = " + windowProps[1] + "\r\n\n" +
        "navigator:\r\n min = " + navigatorProps[0] + "\r\n max = " + navigatorProps[1];
};