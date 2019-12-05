var input = `109165-576723`;

function partOne(data) {
  var numbers = data.split('-');
  var passwords = [];

  for (var i = +numbers[0]; i <= +numbers[1]; i++) {
    var password = `${i}`;

    if (sameDigits(password) && increaseOrSameDigits(password)) {
      passwords.push(password);
    }
  }

  console.log(passwords.length);
}

function partTwo(data) {
  var numbers = data.split('-');
  var passwords = [];

  for (var i = +numbers[0]; i <= +numbers[1]; i++) {
    var password = `${i}`;

    if (sameDigitsV2(password) && increaseOrSameDigits(password)) {
      passwords.push(password);
    }
  }

  console.log(passwords.length);
}

function sameDigits(password) {
  var groups = password.match(/([0-9])\1*/g);
  var doubles = groups.filter((group) => {
    return group.length >= 2;
  });

  return doubles.length > 0;
}

function increaseOrSameDigits(password) {
  var result = false;
  var digits = password.split('');

  for (var i = 0; i < digits.length - 1; i++) {
    var digit = digits[i];
    var nextDigit = digits[i + 1];

    if (digit <= nextDigit) {
      result = true;
    } else {
      result = false;
      break;
    }
  }

  return result;
}

function sameDigitsV2(password) {
  var groups = password.match(/([0-9])\1*/g);
  var doubles = groups.filter((group) => {
    return group.length === 2;
  });

  return doubles.length > 0;
}

partOne(input);
partTwo(input);