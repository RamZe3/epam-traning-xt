function deleteEmptyElInMass(mass){
    let answer = [];
    for(let i = 0 ; i < mass.length; i++){
        if(mass[i].length > 0){

            answer.push(mass[i])
        }
    }
    return answer
}

function CHAR_REMOVER(str){
    let punctuationMarks = [ "?" , "!" , ":" , ";" , "," , "." , " " ]

    let strMass = str.split(" ").join("!")
                     .split("!").join("?")
                     .split("?").join(":")
                     .split(":").join(";")
                     .split(";").join(",")
                     .split(",").join(".")
                     .split(".")


    let punctuationMarksMass = str.replace(strMass[0], "");
    for(let i = 1 ; i < strMass.length; i++){
        if(strMass[i].length != 0){
            punctuationMarksMass = punctuationMarksMass.split(strMass[i]).join("word");
        }
    }
    punctuationMarksMass = punctuationMarksMass.split("word");


    for(let i = 0 ; i < strMass.length; i++){
        for(let j = 0 ; j < strMass[i].length-1; j++){
            for(let k = j+1 ; k < strMass[i].length; k++){
                if(strMass[i][j] == strMass[i][k]){
                    strMass[i] = strMass[i].replaceAll(strMass[i][j], "");
                }
            }
        }
    }

    strMass = deleteEmptyElInMass(strMass)
    let answer = "";

    for(let i = 0 ; i < strMass.length; i++){
        answer = answer.concat(strMass[i]);
        answer = answer.concat(punctuationMarksMass[i]);
    }
    return answer
}
alert(CHAR_REMOVER("test!! asaad. zxc."))