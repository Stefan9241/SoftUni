function solve() {
  class Employee {
    constructor(name, age) {
      this.name = name;
      this.age = age;
      this.salary = 0;
      this.tasks = [];
      this.taskCount = 0;
    }

    work() {
      return undefined;
    }

    collectSalary() {
      console.log(`${this.name} received ${this.salary} this month.
      `);
    }
  }

  class Junior extends Employee {
    constructor(name, age) {
      super(name, age);
      this.tasks.push(`${this.name} is working on a simple task.`);
    }

    work() {
      console.log(this.tasks[0]);
    }
  }

  class Senior extends Employee {
    constructor(name, age) {
      super(name, age);
      this.tasks.push(`${this.name} is working on a complicated task.`);
      this.tasks.push(`${this.name} is taking time off work.`);
      this.tasks.push(`${this.name} is supervising junior workers.`);
    }

    work() {
      if (this.taskCount === 3) {
        this.taskCount = 0;
      }
      console.log(this.tasks[this.taskCount]);

      this.taskCount++;
    }
  }

  class Manager extends Employee {
    constructor(name, age) {
      super(name, age);
      this.dividend = 0;
      this.tasks.push(`${this.name} scheduled a meeting.`);
      this.tasks.push(`${this.name} is preparing a quarterly report.`);
    }

    collectSalary() {
      console.log(
        `${this.name} received ${this.salary + this.dividend} this month.`
      );
    }

    work() {
      if (this.taskCount == 2) {
        this.taskCount = 0;
      }

      console.log(this.tasks[this.taskCount]);

      this.taskCount++;
    }
  }

  return { Employee, Junior, Senior, Manager };
}
let classes = solve();
var guy1 = new classes.Junior('Peter', 27);
guy1.salary = 1200;
guy1.collectSalary();
