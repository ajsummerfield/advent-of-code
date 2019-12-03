var sampleInput = [1,9,10,3,2,3,11,0,99,30,40,50];
var input = [1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,9,1,19,1,19,5,23,1,9,23,27,2,27,6,31,1,5,31,35,2,9,35,39,2,6,39,43,2,43,13,47,2,13,47,51,1,10,51,55,1,9,55,59,1,6,59,63,2,63,9,67,1,67,6,71,1,71,13,75,1,6,75,79,1,9,79,83,2,9,83,87,1,87,6,91,1,91,13,95,2,6,95,99,1,10,99,103,2,103,9,107,1,6,107,111,1,10,111,115,2,6,115,119,1,5,119,123,1,123,13,127,1,127,5,131,1,6,131,135,2,135,13,139,1,139,2,143,1,143,10,0,99,2,0,14,0];

function partOne(data) {
  data[1] = 12; // noun
  data[2] = 2; // verb

  for (var i = 0; i < data.length; i += 4) {
    var opCode = data[i];
    var numberOnePosition = data[i + 1];
    var numberTwoPosition = data[i + 2];
    var outputNumberPosition = data[i + 3];
    var numberOne = data[numberOnePosition];
    var numberTwo = data[numberTwoPosition];

    if (opCode === 1) { // addition
      var additionResult = numberOne + numberTwo;
      data[outputNumberPosition] = additionResult;
    } else if (opCode === 2) { // multiplication
      var multiplicationResult = numberOne * numberTwo;
      data[outputNumberPosition] = multiplicationResult;
    } else if (opCode === 99) { // halt
      console.log(data[0]);
      break;
    }
    else { // error
      console.log('error');
      break;
    }
  }
}

function partTwo(data) {

  for (var x = 0; x < 100; x++) {
    var program = data.slice();
    program[1] = x;

    for (var y = 0; y < 100; y++) {
      program = data.slice();
      program[1] = x;
      program[2] = y;
      
      for (var i = 0; i < program.length; i += 4) {
        var opCode = program[i];
        var numberOnePosition = program[i + 1];
        var numberTwoPosition = program[i + 2];
        var outputNumberPosition = program[i + 3];
        var numberOne = program[numberOnePosition];
        var numberTwo = program[numberTwoPosition];
    
        if (opCode === 1) { // addition
          var additionResult = numberOne + numberTwo;
          program[outputNumberPosition] = additionResult;
        } else if (opCode === 2) { // multiplication
          var multiplicationResult = numberOne * numberTwo;
          program[outputNumberPosition] = multiplicationResult;
        } else if (opCode === 99) { // halt
          if (program[0] === 19690720) {
            var noun = program[1];
            var verb = program[2];
            console.log(program[0]);
            console.log('noun: ' + noun);
            console.log('verb: ' + verb);
            console.log(100 * noun + verb);
          }
          break;
        }
        else { // error
          //console.log('error');
          break;
        }
      }
    }
  }
}

//partOne(sampleInput);
//partOne(input); // 6568671

partTwo(input);