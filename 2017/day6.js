var input = `10	3	15	10	5	15	5	15	9	2	5	8	5	2	3	6`;
var sample = `0 2 7 0`;

//doIt(sample); // 5
//doIt(input); // 14029

doItAgain(sample); // 4
doItAgain(input);

function doIt(data) {

    data = data.split(/\s+/).map((item) => { return parseInt(item); });
    var previousConfigurations = [];
    var currentConfiguration = data.join(' ');
    var index = 0;
    var startPos = 0;

    while(true) {
        index++;

        var largestBank = parseInt(Math.max(...data)); // find largest bank
        var postionOfLargestBank = data.indexOf(largestBank); // find position of largest bank
        data[postionOfLargestBank] = 0; // empty bank of blocks
        var startPos = postionOfLargestBank + 1; // star position is the next bank along
        var size = data.length;

        for (var j = 0; j < largestBank; j++) {
            data[(startPos + j) % size] = data[(startPos + j) % size] + 1;
        }

        currentConfiguration = data.join(' ');

        if (previousConfigurations.indexOf(currentConfiguration) > -1) {
            break;
        } else {
            previousConfigurations.push(currentConfiguration);
        }
    }

    console.log(index);
};

function doItAgain(data) {

    data = data.split(/\s+/).map((item) => { return parseInt(item); });
    var previousConfigurations = [];
    var currentConfiguration = data.join(' ');
    previousConfigurations.push(currentConfiguration);
    var index = 0;
    var startPos = 0;
    var result = 0;

    while(true) {
        index++;

        var largestBank = parseInt(Math.max(...data)); // find largest bank
        var postionOfLargestBank = data.indexOf(largestBank); // find position of largest bank
        data[postionOfLargestBank] = 0; // empty bank of blocks
        var startPos = postionOfLargestBank + 1; // star position is the next bank along
        var size = data.length;

        for (var j = 0; j < largestBank; j++) {
            data[(startPos + j) % size] = data[(startPos + j) % size] + 1;
        }

        currentConfiguration = data.join(' ');

        if (previousConfigurations.indexOf(currentConfiguration) > -1) {
            result = index - previousConfigurations.indexOf(currentConfiguration);
            break;
        } else {
            previousConfigurations.push(currentConfiguration);
        }
    }

    console.log(result);
};