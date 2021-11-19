function ex6(array) {
    const catalogue = {};
    array.forEach((el) => {
        let args = el.split(' : ');
        let productName = args[0];
        let price = Number(args[1]);
        const index = productName[0];
        if (!catalogue[index]) {
            catalogue[index] = {};
        }
        catalogue[index][productName] = price;
    })
    let newSort = Object.keys(catalogue).sort((a, b) => a.localeCompare(b));

    for (const key of newSort) {
        let products = Object.entries(catalogue[key]).sort((a, b) => a[0].localeCompare(b[0]));
        console.log(key);
        products.forEach((el)=> {
            console.log(`  ${el[0]}: ${el[1]}`);
        })
    }
}
ex6(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);