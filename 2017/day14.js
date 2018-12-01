var padStart = require('string.prototype.padstart');
var hexToBinary = require('hex-to-binary');

var input = 'hfdlxzhv';
var sample = 'flqrgnkx';
var list255 = Array.apply(null, { length : 256}).map(Number.call, Number);

doIt(sample);
//doIt(input);

function doIt(data) {
    var asciiHashes = [];
    var knotHashes = [];
    var binary = [];
    var total = 0;

    for (var i = 0; i < 128; i++) {
        var hash = data + '-' + i;
        var asciiHash = hash.split('').map(x => x.charCodeAt(0));
        asciiHash.push(17, 31, 73, 47, 23);
        asciiHashes.push(asciiHash);
    }

    for (var i = 0; i < asciiHashes.length; i++) {
        var asciiHash = asciiHashes[i];
        var knotHash = getKnotHash(asciiHash, list255);
        knotHashes.push(knotHash);
    }

    binary = knotHashes.map(x => getBinaryValue(x));

    for (var i = 0; i < binary.length; i++) {
        var binaryRow = binary[i].split('');

        for (var j = 0; j < binaryRow.length; j++) {

            if (+binaryRow[j] === 1) {
                total++;
            }
        }
    }

    console.log(total);
};

function getBinaryValue(knotHash) {
    var binaryValue = knotHash.split('').map(x => padStart(hexToBinary(x), 4, '0'));
    return binaryValue.join('');
};

function getKnotHash(data, list) {
    var index = 0;
    var position = 0;
    var skipSize = 0;

    while (index < 64) {
        index++;

        data.map(x => hashCycle(+x, list, position, skipSize));

        // for (var i = 0; i < data.length; i++) {
        //     var length = +data[i];
        //     var sublist = [];

        //     for (var j = 0; j < length; j++) {
        //         var val = list[(position + j) % list.length];
        //         sublist[j] = val;
        //     }

        //     sublist.reverse();
            
        //     for (var j = 0; j < length; j++) {
        //         var val = sublist[j];
        //         list[(position + j) % list.length] = val;
        //     }

        //     position += (length + skipSize);
        //     skipSize++;
        // }
    }

    console.log(list);

    var denseHash = [];

    for(var i = 0; i < list.length; i += 16) {
        var arr = list.slice(i, (i + 16));
        var result = eval(arr.join('^'));
        denseHash.push(result);
    }

    
    return denseHash.map(x => padStart(x.toString(16), 2, '0')).join('');
};

function hashCycle(length, list, position, skipSize) {
    var sublist = [];

    for (var j = 0; j < length; j++) {
        var val = list[(position + j) % list.length];
        sublist[j] = val;
    }

    sublist.reverse();
    
    for (var j = 0; j < length; j++) {
        var val = sublist[j];
        list[(position + j) % list.length] = val;
    }

    position += (length + skipSize);
    skipSize++;
};