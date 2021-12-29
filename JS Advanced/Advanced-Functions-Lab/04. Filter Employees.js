function solve(data,criteria){
    let parsed = JSON.parse(data);
    let [crit,value] = criteria.split('-');

    return parsed
    .filter(x=> x[crit] === value)
    .map((x,i) => `${i}. ${x.first_name} ${x.last_name} - ${x.email}`)
    .join('\n') 
}


let data = `[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`;
  
console.log(solve(data, 
'gender-Female'));