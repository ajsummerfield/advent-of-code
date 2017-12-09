var input = require('fs').readFileSync('day9.txt');
var sample1 = '<>'; // 0
var sample2 = '<random characters>'; // 17
var sample3 = '<<<<>'; // 3
var sample4 = '<{!>}>'; // 2
var sample5 = '<!!>'; // 0
var sample6 = '<!!!>>'; // 0
var sample7 = '<{o"i!a,<{i<a>'; // 10
var sample8 = '<asd>,<asd>'; // 6

//doIt(sample);
doIt(input);

//doItAgain(sample8);
doItAgain(input);

function doIt(data) {
    data = data + ''.split('');
    var total = 0;
    var groupScore = 0;
    var isGarbage = false;

    for (var i = 0; i < data.length; i++) {
        var char = data[i];

        if (char === '{') {
            if (!isGarbage) {
                groupScore++;
            }
        } else if (char === '}') {
            if (!isGarbage) {
                total += groupScore;
                groupScore--;
            }
        } else if (char === '!') {
            i++;
        } else if (char === '<') {
            isGarbage = true;
        } else if (char === '>') {
            isGarbage = false;
        }
    }

    console.log(total);
};

function doItAgain(data) {
    data = data + ''.split('');
    var garbageScore = 0;
    var isGarbage = 0;

    for (var i = 0; i < data.length; i++) {
        var char = data[i];

        if (char === '!') {
            i++;
        } else if (char === '<') {
            if (isGarbage) {
                garbageScore++;
            } else {
                isGarbage = true;
            }
            
        } else if (char === '>') {
            isGarbage = false;
        } else {
            if (isGarbage) {
                garbageScore++;
            }
        }
    }

    console.log(garbageScore);
};