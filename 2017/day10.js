var input = '106,16,254,226,55,2,1,166,177,247,93,0,255,228,60,36';
var inputList = Array.apply(null, { length : 256}).map(Number.call, Number);

var sample = '3,4,1,5';
var sampleList = Array.apply(null, { length : 5}).map(Number.call, Number);

doIt(sample, sampleList);
doIt(input, inputList);

function doIt(data, list) {
    data = data.split(',');
    var position = 0;
    var skipSize = 0;

    for (var i = 0; i < data.length; i++) {
        var length = +data[i];
        var sublist = [];

        for (var j = 0; j < length; j++) {
            var digit = list[(position + j) % list.length];
            sublist.push(digit);
        }

        sublist.reverse();

        for (var j = 0; j < sublist.length; j++) {
            var digit = sublist[j];
            list[(position + j) % list.length] = digit;
        }

        position = (position + length + skipSize) % list.length;
        skipSize++;
    }

    console.log(list[0] * list[1]);
};
