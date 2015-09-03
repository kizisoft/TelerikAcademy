(function usingObjects() {
    // Task 1
    function buildPoint(inX, inY) {
        // Return an instance of Point
        return {
            x: inX,
            y: inY,
            toString: function () {
                return "P(" + this.x + ", " + this.y + ")";
            }
        };
    }

    function buildLine(inPointA, inPointB) {
        // Return an instance of Line
        return {
            pointA: inPointA,
            pointB: inPointB,
            calculateDistance: function () {
                return Math.sqrt((this.pointA.x - this.pointB.x) * (this.pointA.x - this.pointB.x) +
                    (this.pointA.y - this.pointB.y) * (this.pointA.y - this.pointB.y));
            },
            toString: function () {
                return "L(" + this.pointA + ", " + this.pointB + ")"
            }
        }
    }

    // Calculate if a given lines can form a triangle
    function isPossibleTriangle(lineA, lineB, lineC) {
        var a = lineA.calculateDistance(),
            b = lineB.calculateDistance(),
            c = lineC.calculateDistance();

        return a + b > c && a + c > b && b + c > a;
    }

    // Task 2
    Array.prototype.removeAll = function (element) {
        var length = this.length || 0,
            count = 0;

        for (var i = 0; i < length; i++) {
            if (this[i].trim() === element) {
                this.splice(i, 1);
                i--;
                length--;
                count++;
            }
        }

        // Return the count of removed elements
        return count;
    };

    // Task 3
    function deepCopy(source) {
        var target;

        if (source === null || typeof (source) !== "object") {
            return source;
        }

        if (source.constructor === Array) {
            target = target || [];
        } else {
            target = target || {};
        }

        for (var index in source) {
            if (typeof (source[index]) !== "object") {
                target[index] = source[index];
            } else {
                target[index] = deepCopy(source[index]);
            }
        }

        return target;
    }

    // Task 4
    function hasProperty(obj, prop) {
        for (var index in obj) {
            if (index === prop) {
                return true;
            }
        }

        return false;
    }

    // Task 5
    function buildPerson(inFirstName, inLastName, inAge) {
        return {
            firstName: inFirstName,
            lastName: inLastName,
            age: inAge,
            toString: function () {
                return this.firstName + " " + this.lastName + ", " + this.age;
            }
        };
    }

    function findYoungestPerson(persons) {
        var minAge = Math.min,
            indexMinAge = -1,
            length = persons.length || 0;

        for (var i = 0; i < length; i++) {
            if (minAge > persons[i].age) {
                minAge = persons[i].age;
                indexMinAge = i;
            }
        }

        return indexMinAge;
    }

    // Task 6
    function group(persons, by) {
        function groupBy(persons, by) {
            var grouped = {},
                length = persons.length || 0;

            for (var i = 0; i < length; i++) {
                if (grouped[persons[i][by]] === undefined) {
                    grouped[persons[i][by]] = [persons[i]];
                } else {
                    grouped[persons[i][by]].push(persons[i]);
                }
            }

            return grouped;
        }

        switch (by) {
            case "firstname":
                return groupBy(persons, "firstName");
            case "lastname":
                return groupBy(persons, "lastName");
            case "age":
                return groupBy(persons, "age");
            default:
                return null;
        }
    }

    // Test 1
    document.getElementById("bt-task1").onclick = function () {
        var pA1 = buildPoint(parseInt(document.getElementById("in-task11").value, 10), parseInt(document.getElementById("in-task12").value, 10)),
            pA2 = buildPoint(parseInt(document.getElementById("in-task13").value, 10), parseInt(document.getElementById("in-task14").value, 10)),
            pB1 = buildPoint(parseInt(document.getElementById("in-task15").value, 10), parseInt(document.getElementById("in-task16").value, 10)),
            pB2 = buildPoint(parseInt(document.getElementById("in-task17").value, 10), parseInt(document.getElementById("in-task18").value, 10)),
            pC1 = buildPoint(parseInt(document.getElementById("in-task19").value, 10), parseInt(document.getElementById("in-task110").value, 10)),
            pC2 = buildPoint(parseInt(document.getElementById("in-task111").value, 10), parseInt(document.getElementById("in-task112").value, 10)),

            lineA = buildLine(pA1, pA2),
            lineB = buildLine(pB1, pB2),
            lineC = buildLine(pC1, pC2),
            result = "Lines length:\r\n";

        result += "LineA = " + lineA.calculateDistance() + "\r\n";
        result += "LineB = " + lineB.calculateDistance() + "\r\n";
        result += "LineC = " + lineC.calculateDistance() + "\r\n";
        result += "The lines could form a triangle: " + isPossibleTriangle(lineA, lineB, lineC);

        document.getElementById("res-task1").innerText = result;
    };

    // Test 2
    document.getElementById("bt-task2").onclick = function () {
        var sequence = document.getElementById("in-task21").value.split(","),
            element = document.getElementById("in-task22").value,
            count = sequence.removeAll(element);

        document.getElementById("res-task2").innerText = count + " element(s) removed.\r\n Current sequence: [" + sequence + "]";
    };

    // Test 3
    document.getElementById("bt-task31").onclick = testDeepCopy;
    document.getElementById("bt-task32").onclick = testDeepCopy;

    function testDeepCopy(e) {
        var p1 = buildPoint(1, 1),
            p2 = buildPoint(2, 2),
            p3 = buildPoint(3, 3),
            p4 = buildPoint(4, 4),
            l1 = buildLine(p1, p2),
            l2 = buildLine(p3, p4),
            changed = "",
            testList = [p1, p2, p3, p4, l1, l2, null, undefined, 1, "blabla", [l1, NaN]],
            copy = deepCopy(testList);

        e.currentTarget.disabled = true;
        if (e.currentTarget.id === "bt-task31") {
            document.getElementById("info-task3").style.visibility = 'visible';
            document.getElementById("bt-task32").disabled = false;
            var result = "";
        } else {
            document.getElementById("bt-task31").disabled = false;
            var result = document.getElementById("res-task3").innerText + "\r\nAfter some changes to the copied obcejts!\r\n\n";
            changed = "changed ";

            // Make some changes to the copied object
            copy[1].x = 99;
            copy[10][0].pointA = buildPoint(33, 44);
        }

        result += "The test array with original objects:\r\n[" + testList + "]\r\n\nThe " + changed +
                  "copied objects:\r\n[" + copy + "]\r\n";
        document.getElementById("res-task3").innerText = result;
    }

    // Test 4
    document.getElementById("bt-task4").onclick = function () {
        var prop = document.getElementById("in-task4").value,
            resultElement = document.getElementById("res-task4");

        if (hasProperty(document, prop)) {
            resultElement.innerText = "The property \"" + prop + "\" exist.\r\n\n";
        } else {
            resultElement.innerText = "The property \"" + prop + "\" doesn't exist.\r\n\n";
        }

        for (var index in document) {
            if (index === prop) {
                resultElement.innerHTML += "<span style='color: #fff; background: #00f;'>" + index + "</span><br />";
            } else {
                resultElement.innerHTML += index + "<br />";
            }
        }
    };

    // Test 5
    function fillPersonsList() {
        var persons = [];

        persons.push(buildPerson("Pesho", "Stoqnov", "23"));
        persons.push(buildPerson("Ivan", "Petkanov", "32"));
        persons.push(buildPerson("Petkan", "Ivanov", "23"));
        persons.push(buildPerson("Stoqn", "Stoqnov", "32"));
        persons.push(buildPerson("Pesho", "Ivanov", "21"));

        return persons;
    }

    document.getElementById("bt-task5").onclick = function () {
        var persons = fillPersonsList(),
            result = "";

        for (var i = 0; i < persons.length; i++) {
            result += persons[i].toString() + "\r\n";
        }

        var indexMinAge = findYoungestPerson(persons);
        document.getElementById("res-task5").innerText = result + "\r\nThe youngest person: " + persons[indexMinAge];
    }

    // Test 6
    document.getElementById("bt-task6").onclick = function () {
        var persons = fillPersonsList(),
            result = {},
            resultStr = "";

        for (var i = 1; i < 4; i++) {
            if (document.getElementById("r" + i).checked) {
                var by = document.getElementById("r" + i).value;
                break;
            }
        }

        result = group(persons, by);

        for (var index in result) {
            resultStr += index + ":\r\n";
            for (var i = 0; i < result[index].length; i++) {
                resultStr += result[index][i] + "\r\n";
            }

            resultStr += "\r\n";
        }

        document.getElementById("res-task6").innerText = resultStr;
    }
})();