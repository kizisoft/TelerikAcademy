// Task 1
document.getElementById("bt-task1").onclick = function () {
    var inVal = document.getElementById("in-task1").value;
    var res = (inVal % 2 == 0);
    document.getElementById("res-task1").innerText = res;
};

// Task 2
document.getElementById("bt-task2").onclick = function () {
    var inVal = document.getElementById("in-task2").value;
    var res = ((inVal % 5 == 0) && (inVal % 7 == 0));
    document.getElementById("res-task2").innerText = res;
};

// Task 3
document.getElementById("bt-task3").onclick = function () {
    var width = document.getElementById("in-task31").value;
    var height = document.getElementById("in-task32").value;
    var res = width * height;
    document.getElementById("res-task3").innerText = res;
};

// Task 4
document.getElementById("bt-task4").onclick = function () {
    var inVal = document.getElementById("in-task4").value;
    var res = inVal[inVal.length - 3] == 7;
    document.getElementById("res-task4").innerText = res;
};

// Task 5
document.getElementById("bt-task5").onclick = function () {
    var inVal = document.getElementById("in-task5").value;
    var res = ((inVal & 8) == 8);
    document.getElementById("res-task5").innerText = res;
};

// Task 6
document.getElementById("bt-task6").onclick = function () {
    var x = document.getElementById("in-task61").value;
    var y = document.getElementById("in-task62").value;
    var res = (x * x + (y - 5) * (y - 5) <= 25);
    document.getElementById("res-task6").innerText = res;
};

// Task 7
document.getElementById("bt-task7").onclick = function () {
    var inVal = document.getElementById("in-task7").value;
    var res = true;
    for (var i = 2; i <= Math.sqrt(inVal) ; i++) {
        if (inVal % i == 0) {
            res = false;
            break;
        }
    }
    document.getElementById("res-task7").innerText = res;
};

// Task 8
document.getElementById("bt-task8").onclick = function () {
    var a = parseFloat(document.getElementById("in-task81").value);
    var b = parseFloat(document.getElementById("in-task82").value);
    var h = parseFloat(document.getElementById("in-task83").value);
    var res = (a + b) * h / 2;
    document.getElementById("res-task8").innerText = res;
};

// Task 9
document.getElementById("bt-task9").onclick = function () {
    var x = parseFloat(document.getElementById("in-task91").value);
    var y = parseFloat(document.getElementById("in-task92").value);
    var res = ((x - 1) * (x - 1) + (y - 1) * (y - 1) <= 9) && (x < -1 || x > 5 || y < -1 || y > 1);
    document.getElementById("res-task9").innerText = res;
};