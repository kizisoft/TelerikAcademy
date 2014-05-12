function PrintTypeOf(typeOfLiteral, val) {
    // Get the HTML from div element
    var res = document.getElementById("root").innerHTML;
    // Add a new line if it's not empty
    if (res !== "") {
        res += "<br />";
    }

    // Add new data in the div
    res += "The type of <span class = 'white'>" + typeOfLiteral + "</span> literal = <span class = 'green'>" + typeof (val) + "</span>";
    document.getElementById("root").innerHTML = res;
};

function solution() {

    // 1. Assign all the possible JavaScript literals to different variables.
    var intType = 123,
        floatType = 1.23,
        booleanType = false,
        stringType = "Hello",
        objectType = {
            fName: "Pesho",
            lName: "Goshov"
        },
        arrayType = [1, 2, 3, 4, 5],
        quotedText,
        nullVar,
        undefinedVar;

    // 2. Create a string variable with quoted text in it. For example: "How you doin'?", Joey said.
    quotedText = '"How you doin?", Joey said.';

    // 3. Try typeof on all variables you created.
    PrintTypeOf("Integer", intType);
    PrintTypeOf("Float", floatType);
    PrintTypeOf("Boolean", booleanType);
    PrintTypeOf("String", stringType);
    PrintTypeOf("Object", objectType);
    PrintTypeOf("Array", arrayType);

    // 4. Create null, undefined variables and try typeof on them.
    nullVar = null;

    PrintTypeOf("null", nullVar);
    PrintTypeOf("undefined", undefinedVar);
}

// Start execution of the script
solution();