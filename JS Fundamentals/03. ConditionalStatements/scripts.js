// Task 1
document.getElementById("bt-task1").onclick = function () {
    var firstNumb,
        secondNumb;

    firstNumb = parseInt(document.getElementById("in-task11").value, 10);
    secondNumb = parseInt(document.getElementById("in-task12").value, 10);

    if (firstNumb >= secondNumb) {
        firstNumb += secondNumb;
        secondNumb = firstNumb - secondNumb;
        firstNumb = firstNumb - secondNumb;
    }

    document.getElementById("res-task11").innerText = "First number: " + firstNumb;
    document.getElementById("res-task12").innerText = "Second number: " + secondNumb;
};

// Task 2
document.getElementById("bt-task2").onclick = function () {
    var numbs = new Array(3),
        res = 0,
        i;

    numbs[0] = parseInt(document.getElementById("in-task21").value, 10);
    numbs[1] = parseInt(document.getElementById("in-task22").value, 10);
    numbs[2] = parseInt(document.getElementById("in-task23").value, 10);

    for (i = 0; i < 3; i++) {
        if (numbs[i] < 0) {
            res++;
        }
    }

    if (res % 2 !== 0) {
        res = '"-" Negative';
    } else {
        res = '"+" Positive';
    }

    document.getElementById("res-task2").innerText = res;
};

// Task 3
document.getElementById("bt-task3").onclick = function () {
    var numbs = new Array(3),
        res = 0;

    numbs[0] = parseInt(document.getElementById("in-task31").value, 10);
    numbs[1] = parseInt(document.getElementById("in-task32").value, 10);
    numbs[2] = parseInt(document.getElementById("in-task33").value, 10);

    //if (numbs[0]>=numbs[1]) {
    //    if (numbs[0]>=numbs[2]) {
    //        res = numbs[0];
    //    }
    //    else {
    //        res = numbs[2];
    //    }
    // }
    //else {
    //    if (numbs[1] >= numbs[2]) {
    //        res = numbs[1];
    //    }
    //    else {
    //        res = numbs[2];
    //    }
    //}

    res = Number(numbs[0] < numbs[1]);      // JavaScript :)
    if (numbs[res] >= numbs[2]) {
        res = numbs[res];
    } else {
        res = numbs[2];
    }

    document.getElementById("res-task3").innerText = "The biggest number is: " + res;
};

// Task 4
document.getElementById("bt-task4").onclick = function () {
    var numbs = new Array(3);

    function swapNumb(index1, index2) {
        numbs[index1] += numbs[index2];
        numbs[index2] = numbs[index1] - numbs[index2];
        numbs[index1] = numbs[index1] - numbs[index2];
    }

    numbs[0] = parseFloat(document.getElementById("in-task41").value);
    numbs[1] = parseFloat(document.getElementById("in-task42").value);
    numbs[2] = parseFloat(document.getElementById("in-task43").value);

    while (numbs[0] < numbs[1] || numbs[1] < numbs[2]) {
        if (numbs[0] < numbs[1]) {
            swapNumb(0, 1);
        }

        if (numbs[1] < numbs[2]) {
            swapNumb(1, 2);
        }
    }

    document.getElementById("res-task4").innerText = "Sorted numbers: " + numbs;
};

// Task 5
document.getElementById("bt-task5").onclick = function () {
    var digit,
        strDigit;

    digit = parseInt(document.getElementById("in-task5").value, 10);

    switch (digit) {
        case 0: strDigit = "Zero"; break;
        case 1: strDigit = "One"; break;
        case 2: strDigit = "Two"; break;
        case 3: strDigit = "Three"; break;
        case 4: strDigit = "Four"; break;
        case 5: strDigit = "Five"; break;
        case 6: strDigit = "Six"; break;
        case 7: strDigit = "Seven"; break;
        case 8: strDigit = "Eight"; break;
        case 9: strDigit = "Nine"; break;
        default: strDigit = "Not a digit!";
    }

    document.getElementById("res-task5").innerText = strDigit;
};

// Task 6
document.getElementById("bt-task6").onclick = function () {
    var a,
        b,
        c,
        d,
        res;

    // Read the numbers
    a = parseFloat(document.getElementById("in-task61").value);
    b = parseFloat(document.getElementById("in-task62").value);
    c = parseFloat(document.getElementById("in-task63").value);

    if (a === 0) {
        // If a = 0 and b = 0 it is not an equation
        if (b === 0) {
            res = "It is not an equation";
        }
        else {
            res = "The equation answer: " + (-c / b);
        }
    } else {
        // Calculate the discriminant
        d = b * b - 4 * a * c;

        // Check case d < 0, d > 0 and d = 0
        if (d < 0) {
            res = "The quadratic equation has no real roots!";                     // d < 0 => No real roots
        }
        else if (d === 0) {
            res = "The quadratic equation has 1 real root: " + (-b / (2 * a));     // d = 0 => One real root
        }
        else {
            res = "The quadratic equation has 2 real root: " + ((-b + Math.sqrt(d)) / (2 * a) + ", " + (-b - Math.sqrt(d)) / (2 * a));      // d > 0 => Two real roots
        }
    }

    document.getElementById("res-task6").innerText = res;
};

// Task 7
document.getElementById("bt-task7").onclick = function () {
    var numbs = new Array(5),
        maxNumb = Number.MIN_VALUE,
        i;

    numbs[0] = parseFloat(document.getElementById("in-task71").value);
    numbs[1] = parseFloat(document.getElementById("in-task72").value);
    numbs[2] = parseFloat(document.getElementById("in-task73").value);
    numbs[3] = parseFloat(document.getElementById("in-task74").value);
    numbs[4] = parseFloat(document.getElementById("in-task75").value);

    for (i = 0; i < 5; i++) {
        if (numbs[i] > maxNumb) {
            maxNumb = numbs[i];
        }
    }

    document.getElementById("res-task7").innerText = "The max number: " + maxNumb;
};

// Task 8
document.getElementById("bt-task8").onclick = function () {
    var i100,
        i10,
        i1,
        num,
        res,
        numbs = {
            0: { text: "zero" },
            1: { text: "one" },
            2: { text: "two" },
            3: { text: "three" },
            4: { text: "four" },
            5: { text: "five" },
            6: { text: "six" },
            7: { text: "seven" },
            8: { text: "eight" },
            9: { text: "nine" },
            10: { text: "ten" },
            11: { text: "eleven" },
            12: { text: "twelve" },
            13: { text: "thirteen" },
            14: { text: "fourteen" },
            15: { text: "fifteen" },
            16: { text: "sixteen" },
            17: { text: "seventeen" },
            18: { text: "eighteen" },
            19: { text: "nineteen" },
            20: { text: "twenty" },
            30: { text: "thirty" },
            40: { text: "forty" },
            50: { text: "fifty" },
            60: { text: "sixty" },
            70: { text: "seventy" },
            80: { text: "eighty" },
            90: { text: "ninety" },
            100: { text: "One" },
            200: { text: "Two" },
            300: { text: "Three" },
            400: { text: "Four" },
            500: { text: "Five" },
            600: { text: "Six" },
            700: { text: "Seven" },
            800: { text: "Eight" },
            900: { text: "Nine" }
        };

    // Input a number
    num = parseInt(document.getElementById("in-task8").value, 10);
    if (isNaN(num) || num < 0 || num > 999) {
        document.getElementById("res-task8").innerText = "Not a number in the range [0...999]";
        return;
    }

    i1 = num % 10;              // Calculate units
    i10 = num % 100 - i1;       // Calculate tens
    i100 = num - i10 - i1;      // Calculate hundreds

    // Compute the text number
    if (i100 + i10 === 0) {
        res = numbs[i1].text;
    } else if (i10 + i1 === 0) {
        res = numbs[i100].text + " hundred";
    } else if (i100 + i1 === 0) {
        res = numbs[i10].text;
    } else if (i100 === 0) {
        if (num < 20) {
            res = numbs[num].text;
        } else {
            res = numbs[i10].text + " " + numbs[i1].text;
        }
    } else if (i10 === 0) {
        res = numbs[i100].text + " hundred and " + numbs[i1].text;
    } else if (i1 === 0) {
        res = numbs[i100].text + " hundred and " + numbs[i10].text;
    } else {
        if (i10 + i1 < 20) {
            res = numbs[i100].text + " hundred and " + numbs[i10 + i1].text;
        } else {
            res = numbs[i100].text + " hundred and " + numbs[i10].text + " " + numbs[i1].text;
        }
    }

    // Print the text number
    document.getElementById("res-task8").innerText = res;
};