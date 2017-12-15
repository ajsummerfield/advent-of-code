var input = `0: 3
1: 2
2: 4
4: 4
6: 5
8: 6
10: 6
12: 6
14: 6
16: 8
18: 8
20: 8
22: 8
24: 10
26: 8
28: 8
30: 12
32: 14
34: 12
36: 10
38: 12
40: 12
42: 9
44: 12
46: 12
48: 12
50: 12
52: 14
54: 14
56: 14
58: 12
60: 14
62: 14
64: 12
66: 14
70: 14
72: 14
74: 14
76: 14
80: 18
88: 20
90: 14
98: 17`;

var sample = `0: 3
1: 2
4: 4
6: 4`;

//doIt(sample);
//doIt(input);

doItAgain(sample);
doItAgain(input);

function doIt(data) {
    data = data.split('\n');
    var layers = [];
    var severity = 0;

    data.map(x => {
        var layer = getLayer(x);
        layers[layer.depth] = layer;
    });

    for (var i = 0; i < layers.length; i++) {

        if (layers[i] && checkIfCaught(layers[i], i) === 0) {
            severity += (layers[i].depth * layers[i].range);
        }
    }

    console.log(severity);
};

function doItAgain(data) {
    data = data.split('\n');
    var layers = [];
    var delay = 0;
    
    data.map(x => {
        var layer = getLayer(x);
        layers[layer.depth] = layer;
    });

    while (true) {
        var caught = false;
        delay++;
        
        for (var i = 0; i < layers.length; i++) {

            if(layers[i] && checkIfCaught(layers[i], (i + delay)) === 0) {
                caught = true;
                break;
            }
        }

        if (!caught) {
            break;
        }
    }

    console.log(delay);
};

function getLayer(row) {
    var depth = +row.split(': ')[0];
    var range = +row.split(': ')[1];

    return {
        depth: depth,
        range: range,
        calculatedRange: range + range - 2
    }
}

function checkIfCaught(layer, seconds) {
    var range = layer.range - 1;
    var position = seconds % (range * 2);

    return position >= range ? range-- : position;
}