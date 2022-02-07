const { expect } = require("chai");
let cinema = require("./cinema.js");

describe("Testing cinema", function () {
  describe("ShowMovies", function () {
    it("Works correctly", function () {
      let result = cinema.showMovies(["movie", "movie2", "movie3"]);
      let expected = ["movie", "movie2", "movie3"].join(", ");

      expect(result).to.be.equal(expected);
    });
    it("Works Uncorrectly", function () {
      let result = cinema.showMovies([]);
      let expected = "There are currently no movies to show.";

      expect(result).to.be.equal(expected);
    });
  });

  describe("TicketPrice", function () {
    it("Works correctly", function () {
      let result = cinema.ticketPrice("Premiere");
      let expected = 12.0;

      expect(result).to.be.equal(expected);
    });
    it("Works Uncorrectly and Throws Error", function () {
      expect(() => cinema.ticketPrice("asdasd")).to.throw();
    });
  });

  describe("SwapSeatsInHall", function () {
    it("Works correctly with (1,2)", function () {
      let result = cinema.swapSeatsInHall(1, 2);
      let expected = "Successful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });

    it("Works Uncorrectly with ('asdasd',1)", function () {
      let result = cinema.swapSeatsInHall("asdasd", 2);
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });

    it("Works Uncorrectly with (1,asdasd)", function () {
      let result = cinema.swapSeatsInHall(1, "asdasd");
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });

    it("Works Uncorrectly with (25,1)", function () {
      let result = cinema.swapSeatsInHall(25, 1);
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });


    it("Works Uncorrectly with (1,25)", function () {
      let result = cinema.swapSeatsInHall(1, 25);
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });

    it("Works Uncorrectly with (-1,2)", function () {
      let result = cinema.swapSeatsInHall(-1, 2);
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });

    it("Works Uncorrectly with (1,-2)", function () {
      let result = cinema.swapSeatsInHall(1, -2);
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });

    it("Works Uncorrectly with (1,0)", function () {
      let result = cinema.swapSeatsInHall(1, 0);
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });

    it("Works Uncorrectly with (0,10)", function () {
      let result = cinema.swapSeatsInHall(0, 10);
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });

    it("Works Uncorrectly with ()", function () {
      let result = cinema.swapSeatsInHall();
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });

    it("Works Uncorrectly with (0,21)", function () {
      let result = cinema.swapSeatsInHall(0,21);
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });

    it("Works Uncorrectly with ([],{})", function () {
      let result = cinema.swapSeatsInHall([],{});
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });

    it("Works Uncorrectly with (1,1)", function () {
      let result = cinema.swapSeatsInHall(1,1);
      let expected = "Unsuccessful change of seats in the hall.";

      expect(result).to.be.equal(expected);
    });
  });
});
