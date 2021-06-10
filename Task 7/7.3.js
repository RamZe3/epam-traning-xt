class Service{
    constructor(){
        this.mass = [];
        this.lastKey = 0;
    }

    add(value) {
         this.mass[this.lastKey] = value;    
         this.lastKey++; 
    }

    getById(id){
        if(!this.mass[id] == null){
            return null
        }
        else{
            return this.mass[id]
        }
    }

    getAll = () => this.mass

    deleteById(id){
        let element = this.mass[id]
        delete this.mass[id]
        return element
    }

    updateById(id , value){
        for(let key of Object.keys(value)){
            this.mass[id][key] = value[key];
        }
    }

    replaceById(id , value){
        this.mass[id] = value
    }
}


let stor = new Service();

const One = {
    name : "Ramil",
    surname : "Fitkulin",
    age : "18"
}

const Two = {
    name : "Andrew",
    surname : "Sanders",
    age : "21"
}

const Three = {
    name : "Sandy",
    surname : "Martin",
    age : "40"
}

const ForUpdate = {
    name : "Санди"
}

stor.add(One);
stor.add(Two);
stor.add(Three);
console.log(stor.getById(0));
stor.deleteById(0)
stor.updateById(2, ForUpdate)
stor.replaceById(1, One)
console.log(stor.getAll())