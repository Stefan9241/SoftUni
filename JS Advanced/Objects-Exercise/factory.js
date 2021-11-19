function ex3(obj) {
    let result = {};
    result.model = obj.model;
    if (obj.power <= 90) {
        result.engine = { power: 90, volume: 1800 }
    }else if(obj.power <= 120){
        result.engine = {power: 120, volume: 2400}
    }else{
        result.engine = {power: 200, volume: 3500}
    }

    result.carriage = {type: obj.carriage, color: obj.color};

    let wheel = obj.wheelsize % 2 == 0 ? obj.wheelsize-1 : obj.wheelsize;
    result.wheels = [wheel,wheel,wheel,wheel];
    
    return result;

}

ex3({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
});