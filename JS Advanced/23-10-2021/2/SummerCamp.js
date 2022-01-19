class SummerCamp {
  constructor(organizer, location) {
    this.organizer = organizer;
    this.location = location;
    this.priceForTheCamp = { child: 150, student: 300, collegian: 500 };
    this.listOfParticipants = [];
  }

  registerParticipant(name, condition, money) {
    let keysOfTheCamp = Object.keys(this.priceForTheCamp);
    if (keysOfTheCamp.includes(condition) == false) {
      throw new Error("Unsuccessful registration at the camp.");
    }

    if (this.listOfParticipants.some((x) => x.name == name)) {
      return `The ${name} is already registered at the camp.`;
    }

    let price = this.priceForTheCamp[condition];
    if (price > money) {
      return `The money is not enough to pay the stay at the camp.`;
    }

    this.listOfParticipants.push({
      name,
      condition,
      power: 100,
      wins: 0,
    });

    return `The ${name} was successfully registered.`;
  }

  unregisterParticipant(name) {
    let person = this.listOfParticipants.find((x) => x.name == name);

    if (person == undefined) {
      throw new Error(`The ${name} is not registered in the camp.`);
    }

    this.listOfParticipants.filter((x) => x.name != name);

    return `The ${name} removed successfully.`;
  }

  timeToPlay(typeOfGame, participant1, participant2) {
    let person1 = this.listOfParticipants.find((x) => x.name == participant1);
    let person2 = this.listOfParticipants.find((x) => x.name == participant2);
    if (typeOfGame === "WaterBalloonFights") {
      if (person1 == undefined || person2 == undefined) {
        throw new Error(`Invalid entered names.`);
      }

      if (person1.condition !== person2.condition) {
        throw new Error(`Choose players with equal condition.`);
      }

      if (person1.power > person2.power) {
        person1.wins++;
        return `The ${person1.name} is winner in the game ${typeOfGame}.`;
      } else if (person1.power < person2.power) {
        {
          person2.wins++;
          return `The ${person2.name} is winner in the game ${typeOfGame}.`;
        }
      } else {
        return `There is no winner.`;
      }
    } else {
      if (person1 == undefined) {
        throw new Error(`Invalid entered name.`);
      }

      person1.power += 20;
      return `The ${person1.name} successfully completed the game ${typeOfGame}.`;
    }
  }

  toString() {
    let result = [];
    result.push(
      `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`
    );

    let sorted = this.listOfParticipants.sort((a, b) => b.wins - a.wins);
    for (let i = 0; i < sorted.length; i++) {
      result.push(
        `${sorted[i].name} - ${sorted[i].condition} - ${sorted[i].power} - ${sorted[i].wins}`
      );
    }
    return result.join("\n");
  }
}

let camp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(camp.registerParticipant("Petar Petarson", "child", 300));

console.log(camp.registerParticipant("Sara Dickinson", "child", 200)); //"The Sara Dickinson was successfully registered."));

console.log(camp.timeToPlay("Battleship", "Sara Dickinson")); //, "The Sara Dickinson successfully completed the game Battleship.");

console.log(
  camp.timeToPlay("WaterBalloonFights", "Sara Dickinson", "Petar Petarson")
);

console.log(camp.toString());
`Jane Austen will take 2 participants on camping to Pancharevo Sofia 1137, Bulgaria
Sara Dickinson - child - 120 - 1
Petar Petarson - child - 100 - 0`;
