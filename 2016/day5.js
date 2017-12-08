var md5 = require('md5');

var input = 'ugkcyxxp';
var sample = 'abc';

//doIt(sample);
//doIt(input);

doItAgain(sample);
doItAgain(input);

function doIt(data) {
    var index = 0;
    var password = '';

    while (password.length < 8) {
        var result = md5(data + index);
        
        if (hasFiveZeroes(result)) {
            var character = result.charAt(5);
            password += character;
        }
    
        index++;
        
    }
    
    console.log(password);
};


function doItAgain(data) {
    var index = 0;
    var password = [];
    var passwordCount = 0;

    while (passwordCount < 8) {
        var result = md5(data + index);
        
        if (hasFiveZeroes(result)) {
            var position = parseInt(result.charAt(5));
            
            if (!isNaN(position) && position >= 0 && position < 8 && !password[position]) {
                var character = result.charAt(6);
                password[position] = character;
                passwordCount++;
            }
        }
    
        index++;
    }
    
    console.log(password.join(''));
};

function hasFiveZeroes(result) {
    return result.indexOf('00000') === 0;
}