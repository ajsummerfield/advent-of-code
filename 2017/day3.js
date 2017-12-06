var input = 347991;
var sample = 12;

// Pattern of spiral is N right -> N up -> N left -> N down
// N starts at 0 and increases by 1 every 2 direction changes

//doIt(sample); // 3
//doIt(input); // 480

doItAgain(sample); // 23
doItAgain(input); // 349975

function doIt(data) {
    var N = 0;
    var distanceTravelled = 0;
    var distanceToTravel = 1;

    var location = [0, 0];
    var dirs = [[1, 0], [0, 1], [-1, 0], [0, -1]]; // right up left down

    for (var i = 1; i < data; i++) {

        var currentDir = dirs[N % 4]; // 4 directions

        location[0] += currentDir[0];
        location[1] += currentDir[1];

        distanceTravelled++;

        if(distanceTravelled === distanceToTravel) {
            
            if (!((N + 1) % 2)) { // +1 to N and then % 2 to ensure the pattern is matched of changing every 2 directions whilst travel distance increases
                distanceToTravel++;
            }

            distanceTravelled = 0; // reset distance back to 0 for new direction

            N++; // increase N so direction can change
        }
    }

    var total = Math.abs(location[0]) + Math.abs(location[1]);
    console.log(total);
};

function doItAgain(data) {
    var N = 0;
    var distanceTravelled = 0;
    var distanceToTravel = 1;

    var location = [0, 0];
    var grid = initialiseGrid(data);

    var dirs = [[1, 0], [0, 1], [-1, 0], [0, -1]]; // right up left down

    var total = 0;

    for (var i = 1; i < data; i++) {

        var currentDir = dirs[N % 4]; // 4 directions

        location[0] += currentDir[0];
        location[1] += currentDir[1];

        grid[location[0]][location[1]] = sumOfAdjacent(grid, location);

        if (grid[location[0]][location[1]] > data) {
            total = grid[location[0]][location[1]];
            break;
        }

        distanceTravelled++;

        if(distanceTravelled === distanceToTravel) {
            
            if (!((N + 1) % 2)) { // +1 to N and then % 2 to ensure the pattern is matched of changing every 2 directions whilst travel distance increases
                distanceToTravel++;
            }

            distanceTravelled = 0; // reset distance back to 0 for new direction

            N++; // increase N so direction can change
        }
    }

    console.log(total);
};

function initialiseGrid(data) {
    var grid = [];
    var size = Math.floor(Math.sqrt(data));

    for (var i = -size; i < size; i++) {
        grid[i] = [];
    }

    grid[0][0] = 1;

    return grid;
};

function sumOfAdjacent(grid, location) {
    var total = 0;
    var x = parseInt(location[0]);
    var y = parseInt(location[1]);

    total += grid[x - 1][y -1] || 0;
    total += grid[x - 1][y] || 0;
    total += grid[x - 1][y + 1] || 0;

    total += grid[x][y + 1] || 0;
    total += grid[x][y - 1] || 0;

    total += grid[x + 1][y - 1] || 0;
    total += grid[x + 1][y] || 0;
    total += grid[x + 1][y + 1] || 0;

    grid[x][y] = total;

    return total;
};

