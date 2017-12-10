var padStart = require('string.prototype.padstart');

var input = '106,16,254,226,55,2,1,166,177,247,93,0,255,228,60,36';
var inputList = Array.apply(null, { length : 256}).map(Number.call, Number);

var sample = '3,4,1,5';
var sampleList = Array.apply(null, { length : 5}).map(Number.call, Number);

//doIt(sample, sampleList);
//doIt(input, inputList);

doItAgain(input, inputList);

function doIt(data, list) {
    data = data.split(',');
    var position = 0;
    var skipSize = 0;

    for (var i = 0; i < data.length; i++) {
        var length = +data[i];
        var sublist = [];

        for (var j = 0; j < length; j++) {
            var val = list[(position + j) % list.length];
            sublist.push(val);
        }

        sublist.reverse();

        for (var j = 0; j < sublist.length; j++) {
            var val = sublist[j];
            list[(position + j) % list.length] = val;
        }

        position += (length + skipSize);
        skipSize++;
    }

    console.log(list[0] * list[1]);
};

function doItAgain(data, list) {
    var ascii = [];
    var lengthsToAdd = [17, 31, 73, 47, 23];

    data = data.split('');

    ascii = data.map(x => x.charCodeAt(0));
    ascii = ascii.concat(lengthsToAdd);

    var index = 0;
    var position = 0;
    var skipSize = 0;

    while (index < 64) {
        index++;

        for (var i = 0; i < ascii.length; i++) {
            var length = +ascii[i];
            var sublist = [];

            for (var j = 0; j < length; j++) {
                var val = list[(position + j) % list.length];
                sublist[j] = val;
            }

            sublist.reverse();
            
            for (var j = 0; j < sublist.length; j++) {
                var val = sublist[j];
                list[(position + j) % list.length] = val;
            }

            position += (length + skipSize);
            skipSize++;
        }
    }

    var denseHash = [];

    for(var i = 0; i < list.length; i += 16) {
        var arr = list.slice(i, (i + 16));
        var result = eval(arr.join('^'));
        denseHash.push(result);
    }

    var knotHash = denseHash.map(x => padStart(x.toString(16), 2, 0)).join('');

    console.log(knotHash);
};
