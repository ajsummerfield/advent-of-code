var padStart = require('string.prototype.padstart');
var hexToBinary = require('hex-to-binary');

var input = 'hfdlxzhv';
var sample = 'flqrgnkx';
var list255 = Array.apply(null, { length : 256}).map(Number.call, Number);

doIt(sample);
doIt(input);

function doIt(data) {
    var hashes = [];
    var asciiHashes = [];
    var knotHashes = [];
    var binary = [];
    var total = 0;

    for (var i = 0; i < 128; i++) {
        hashes.push(data + '-' + i);
    }

    for (var i = 0; i < hashes.length; i++) {
        var hash = hashes[i];
        var hashed = hash.split('').map(x => x.charCodeAt(0));
        hashed.push(17, 31, 73, 47, 23);
        asciiHashes.push(hashed);
    }

    for (var i = 0; i < asciiHashes.length; i++) {
        var asciiHash = asciiHashes[i];
        var knotHash = getKnotHash(asciiHash, list255);
        knotHashes.push(knotHash);
    }

    for (var i = 0; i < knotHashes.length; i++) {
        var knotHash = knotHashes[i];
        var binaryValue = getBinaryValue(knotHash);
        binary.push(binaryValue);
    }

    // for (var i = 0; i < binary.length; i++) {
    //     var binaryRow = binary[i].split('');

    //     for (var j = 0; j < binaryRow.length; j++) {

    //         if (+binaryRow[j] === 1) {
    //             total++;
    //         }
    //     }
    // }

    binary = binary.map(el => el.split('').reduce((acc, col) => { acc += +col; return acc; }, 0));
    total = binary.reduce((acc, el) => { acc += el; return acc; }, 0);

    console.log(total);
};

function getBinaryValue(knotHash) {
    var binaryValue = [];
    knotHash = knotHash.split('');

    for (var i = 0; i < knotHash.length; i++) {
        binaryValue.push(padStart(hexToBinary(knotHash[i]), 4, '0'));
    }

    return binaryValue.join('');
};

function getKnotHash(data, list) {
    var index = 0;
    var position = 0;
    var skipSize = 0;

    while (index < 64) {
        index++;

        for (var i = 0; i < data.length; i++) {
            var length = +data[i];
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

    return knotHash;
};