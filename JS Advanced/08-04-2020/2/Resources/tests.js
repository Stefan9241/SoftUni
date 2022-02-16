const { expect } = require("chai");
const { it } = require("mocha");
let { Repository } = require("./solution.js");

describe("Tests repository", function () {
    let properties = {
        name: "string",
        age: "number",
        birthday: "object"
    };

    let entity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7)
    };
    let entity2 = {
        name: "Pesho",
    };
    it('Constructor check: instanceOf', ()=> {
        let repo = new Repository(properties);
        expect(repo).to.be.instanceOf(Repository);
    })
    it('Constructor check: repo.data', ()=> {
        let repo = new Repository(properties);
        expect(repo.data).to.have.instanceOf(Map);
    })

    it('Get count check: correctly empty', ()=> {
        let repo = new Repository(properties);
        expect(repo.count).to.be.equal(0);
    })
    it('Get count check: correctly with entity added', ()=> {
        let repo = new Repository(properties);
        let result = repo.add(entity)
        expect(repo.count).to.be.equal(1);
        expect(result).to.be.equal(0);
    })

    it('add: Throws error correctly with wrong type',()=>{
        let repo = new Repository(properties);
        let entity5 = {
            name: 10,
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        expect(()=> repo.add(0,entity5)).to.throw();
    })
    it('add: Throws error correctly with wrong prop',()=>{
        let repo = new Repository(properties);
        let entity5 = {
            birthday: new Date(1998, 0, 7)
        };
        expect(()=> repo.add(0,entity5)).to.throw();
    })
    it('GetID: Works correctly',()=>{
        let repo = new Repository(properties);
        repo.add(entity);
        let result = repo.getId(0);
        expect(result).to.deep.equal(entity);
    })

    it('GetID: Throws error correctly',()=>{
        let repo = new Repository(properties);
        expect(()=> repo.getId(0)).to.throw();
    })

    it('update: Throws error correctly',()=>{
        let repo = new Repository(properties);
        expect(()=> repo.update(0,entity)).to.throw();
    })

    it('update: Throws error correctly with wrong type',()=>{
        let repo = new Repository(properties);
        repo.add(entity);
        let entity5 = {
            name: 10,
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
        expect(()=> repo.update(0,entity5)).to.throw();
    })

    it('update: Throws error correctly with wrong new entity',()=>{
        let repo = new Repository(properties);
        repo.add(entity);
        expect(()=> repo.update(0,entity2)).to.throw();
    })
    it('update: Throws error correctly with no entity',()=>{
        let repo = new Repository(properties);
        repo.add(entity);
        expect(()=> repo.update(0)).to.throw();
    })
    it('update: Works correctly',()=>{
        let repo = new Repository(properties);
        repo.add(entity);

        let entity3 = {
            name: "Gosho",
            age: 14,
            birthday: new Date(1998, 0, 6)
        };
        repo.update(0,entity3);

        expect(repo.getId(0)).to.be.deep.equal(entity3);
    })

    it('del: Throws error correctly with no id',()=>{
        let repo = new Repository(properties);
        repo.add(entity);
        expect(()=> repo.del()).to.throw();
    })
    it('del: correctly with 0 id',()=>{
        let repo = new Repository(properties);
        repo.add(entity);
        repo.del(0);
        expect(repo.count).to.be.equal(0);
    })
});
