var input = 347991;
var sample = 12;

// Pattern of spiral is N right -> N up -> N left -> N down
// N starts at 0 and increases by 1 every 2 direction changes

var N = 0;
var distanceTravelled = 0;
var distanceToTravel = 1;

var location = [0, 0];
var dirs = [[1, 0], [0, 1], [-1, 0], [0, -1]]; // right up left down

for (var i = 1; i < input; i++) {

    var currentDir = dirs[N % 4]; // 4 directions

    location[0] += currentDir[0];
    location[1] += currentDir[1];

    distanceTravelled++;

    if(distanceTravelled === distanceToTravel) {
        
        if (!((N + 1) % 2)) { // +1 to N and then % 2 to ensure the pattern is matched of changing every 2 directions
            distanceToTravel++;
        }

        N++;
        distanceTravelled = 0;
    }
}

var total = Math.abs(location[0]) + Math.abs(location[1]);
console.log(total);