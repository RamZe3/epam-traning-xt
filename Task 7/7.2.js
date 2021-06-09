function calculate(operator, Num1, Num2){
    switch(operator){
        case "*": 
            return Num1 * Num2;
        case "/": 
            return Num1 / Num2;
        case "+": 
            return Num1 + Num2;
        case "-": 
            return Num1 - Num2;

    }
}

function deleteEmptyElInMass(mass){
    let answer = [];
    for(let i = 0 ; i < mass.length; i++){
        if(mass[i].length > 0){

            answer.push(mass[i])
        }
    }
    return answer
}

function MATH_CALCULATOR(str){
    let mathematicalOperators = [ "+" , "-" , "*" , "/", "=" ]
    massOfNumbers = str;
    for(let i = 0 ; i < 5; i++){
        massOfNumbers = massOfNumbers.split(mathematicalOperators[i]).join(" ");
    }
    massOfNumbers = massOfNumbers.split(" ");
    massOfNumbers = deleteEmptyElInMass(massOfNumbers)
    for(let i = 0 ; i < massOfNumbers.length; i++){
        massOfNumbers[i] = parseFloat(massOfNumbers[i]);
    }

    massOfOperators = str;
    for(let i = 0 ; i < massOfNumbers.length; i++){
        massOfOperators = massOfOperators.split(massOfNumbers[i]).join(" ");
    }
    massOfOperators = massOfOperators.split(" ");
    massOfOperators = deleteEmptyElInMass(massOfOperators)

    let answer = massOfNumbers[0];
    for(let i = 0 ; i < massOfOperators.length - 1; i++){
        answer = calculate(massOfOperators[i], answer, massOfNumbers[i+1])
    }
    return answer
}
alert(MATH_CALCULATOR("3.5 +4*10-5.3 /5 = ") )