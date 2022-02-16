class Bank {
  constructor(bankName) {
    this.bankName = bankName;
    this.allCustomers = [];
  }

  newCustomer(customer) {
    let firstName = customer.firstName;
    let lastName = customer.lastName;
    let personalId = customer.personalId;
    let person = this.allCustomers.find(x=> x.personalID === personalId)
    
    if (person) {
      throw new Error(`${firstName} ${lastName} is already our customer!`);
    }
    person = {
      firstName,
      lastName,
      personalID: personalId,
      transactions: [],
      'totalMoney': 0,
    };
    this.allCustomers.push(person);

    return customer;
  }

  depositMoney(personalId, amount) {
    let person = this.allCustomers.find((x) => x.personalID === personalId);
    if (!person) {
      throw new Error(`We have no customer with this ID!`);
    }

    person.totalMoney += Number(amount);
    person.transactions.push(
      `${person.transactions.length + 1}. ${person.firstName} ${
        person.lastName
      } made deposit of ${amount}$!`
    );

    return `${person.totalMoney}$`;
  }

  withdrawMoney(personalId, amount) {
    let person = this.allCustomers.find((x) => x.personalID === personalId);
    if (!person) {
      throw new Error(`We have no customer with this ID!`);
    }

    if (person.totalMoney < amount) {
      throw new Error(`${person.firstName} ${person.lastName} does not have enough money to withdraw that amount!
      `);
    }

    person.totalMoney -= amount;
    person.transactions
      .push(`${person.transactions.length + 1}. ${person.firstName} ${person.lastName} withdrew ${amount}$!`);
    return `${person.totalMoney}$`;
  }

  customerInfo(personalId) {
    let person = this.allCustomers.find((x) => x.personalID === personalId);
    if (!person) {
      throw new Error(`We have no customer with this ID!`);
    }
    let sortedTransactions = person.transactions.sort((a, b) => b.localeCompare(a));

    let result = [];
    result.push(`Bank name: ${this.bankName}`);
    result.push(`Customer name: ${person.firstName} ${person.lastName}`);
    result.push(`Customer ID: ${person.personalID}`);
    result.push(`Total Money: ${person.totalMoney}$`);
    result.push(`Transactions:`);
    sortedTransactions.forEach((element) => {
      result.push(element);
    });

    return result.join("\n");
  }
}

let bank = new Bank("SoftUni Bank");

console.log(
  bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 1111111 })
);
console.log(
  bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 1111111 })
);

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
