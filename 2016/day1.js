var input = 'L5, R1, L5, L1, R5, R1, R1, L4, L1, L3, R2, R4, L4, L1, L1, R2, R4, R3, L1, R4, L4, L5, L4, R4, L5, R1, R5, L2, R1, R3, L2, L4, L4, R1, L192, R5, R1, R4, L5, L4, R5, L1, L1, R48, R5, R5, L2, R4, R4, R1, R3, L1, L4, L5, R1, L4, L2, L5, R5, L2, R74, R4, L1, R188, R5, L4, L2, R5, R2, L4, R4, R3, R3, R2, R1, L3, L2, L5, L5, L2, L1, R1, R5, R4, L3, R5, L1, L3, R4, L1, L3, L2, R1, R3, R2, R5, L3, L1, L1, R5, L4, L5, R5, R2, L5, R2, L1, L5, L3, L5, L5, L1, R1, L4, L3, L1, R2, R5, L1, L3, R4, R5, L4, L1, R5, L1, R5, R5, R5, R2, R1, R2, L5, L5, L5, R4, L5, L4, L4, R5, L2, R1, R5, L1, L5, R4, L3, R4, L2, R3, R3, R3, L2, L2, L2, L1, L4, R3, L4, L2, R2, R5, L1, R2';

var directions = input.split(', ');
var curLoc = [0, 0];
var curDir = 0; // n-0, e-1, s-3, w-4
var prevLoc = [];
var visitedLocs = [[0, 0]];
var repeatedLoc = null;

directions.forEach(function(val) {
    var dir = val[0];
    var steps = parseInt(val.substring(1));

    curDir = getDirection(dir);
    curLoc = getLocation(curDir, steps);
});

var totalBlocks = Math.abs(curLoc[0]) + Math.abs(curLoc[1]);
console.log("Total blocks away: " + totalBlocks);

var visitedBlocksAway = Math.abs(repeatedLoc[0]) + Math.abs(repeatedLoc[1]);
console.log("First block visited twice: " + repeatedLoc);
console.log("First block visited twice is: " + visitedBlocksAway + " blocks away");

function getDirection(dir) {
    if (dir === 'R') {
        curDir++;
    } else {
        curDir--;
    }

    if (curDir === -1) {
        return 3;
    }
    
    if (curDir === 4) {
        return 0;
    }

    return curDir;
}

function getLocation(curDir, steps) {
    
    for(var i = 0; i < steps; i++) {

        var curLoc = visitedLocs[visitedLocs.length - 1];
        var newLoc = [];

        switch(curDir) {

            case 0:
                newLoc = [curLoc[0] + 1, curLoc[1]];
                break;
            
            case 1:
                newLoc = [curLoc[0], curLoc[1] + 1];
                break;

            case 2:
                newLoc = [curLoc[0] - 1, curLoc[1]];
                break;

            case 3:
                newLoc = [curLoc[0], curLoc[1] - 1];
                break;
        }

        visitedLocs.push(newLoc);
        checkVisited();
    }

    return newLoc;
}

function checkVisited() {
    if (repeatedLoc == null) {
        
        var newLoc = visitedLocs[visitedLocs.length - 1];

        var visitedLoc = visitedLocs.find(function(val) {
            return val[0] === newLoc[0] && val[1] === newLoc[1];
        });

        if (visitedLoc && visitedLoc !== newLoc) {
            repeatedLoc = visitedLoc;
        }
    }
}