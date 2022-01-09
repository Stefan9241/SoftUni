class Company {
  constructor() {
    this.departments = {};
  }

  addEmployee(name, salary, position, department) {
    if (!name || salary < 0 || !salary || !position || !department) {
      throw new Error("Invalid input!");
    }

    if (!this.departments[department]) {
      this.departments[department] = [];
    }

    this.departments[department].push({
      name,
      salary: Number(salary),
      position,
    });

    return `New employee is hired. Name: ${name}. Position: ${position}`;
  }

  bestDepartment() {
    let bestDep = {
      name: "",
      avg: 0,
    };

    for (const depName in this.departments) {
      let currSalary = 0;
      let count = 0;
      for (let i = 0; i < this.departments[depName].length; i++) {
        const element = this.departments[depName][i].salary;
        currSalary += element;
        count++;
      }

      let avg = currSalary / count;

      if (avg > bestDep.avg) {
        bestDep.name = depName;
        bestDep.avg = avg;
      }
    }

    this.departments[bestDep.name] = this.departments[bestDep.name].sort(
      (a, b) => {
        return b.salary - a.salary || a.name.localeCompare(b.name);
      }
    );
    let result = "";
    result += `Best Department is: ${bestDep.name}\n`;
    result += `Average salary: ${bestDep.avg.toFixed(2)}\n`;
   

    for (let i = 0; i < this.departments[bestDep.name].length; i++) {
      const element = this.departments[bestDep.name][i];
      if (i + 1 === this.departments[bestDep.name].length) {
        result += `${element.name} ${element.salary} ${element.position}`;
      } else {
        result += `${element.name} ${element.salary} ${element.position}\n`;
      }
    }

    return result;
  }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
