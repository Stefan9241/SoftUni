class LibraryCollection {
  constructor(capacity) {
    this.capacity = capacity;
    this.books = [];
  }

  addBook(bookName, bookAuthor) {
    if (this.books.length === this.capacity) {
      throw new Error("Not enough space in the collection.");
    }

    let book = { bookName: bookName, bookAuthor: bookAuthor, payed: false };
    this.books.push(book);

    return `The ${bookName}, with an author ${bookAuthor}, collect.`;
  }

  payBook(bookName) {
    let book = this.books.find((x) => x.bookName === bookName);
    if (!book) {
      throw new Error(`${bookName} is not in the collection.`);
    }
    if (book.payed === true) {
      throw new Error(`${bookName} has already been paid.`);
    }

    book.payed = true;

    return `${bookName} has been successfully paid.`;
  }
  removeBook(bookName) {
    let book = this.books.find((x) => x.bookName === bookName);
    if (!book) {
      throw new Error(`The book, you're looking for, is not found.`);
    }
    if (book.payed === false) {
      throw new Error(
        `${bookName} need to be paid before removing from the collection.`
      );
    }

    this.books = this.books.filter((x) => x.bookName !== bookName);

    return `${bookName} remove from the collection.`;
  }

  getStatistics(bookAuthor) {
    let result = [];
    if (bookAuthor === undefined) {
      result.push(
        `The book collection has ${
          this.capacity - this.books.length
        } empty spots left.`
      );

      let sortedBooks = this.books.sort((a, b) =>
        a.bookName.localeCompare(b.bookName)
      );
      sortedBooks.forEach((x) => {
        let paidOrNot = "Not Paid";
        if (x.payed) {
          paidOrNot = "Has Paid";
        }
        result.push(`${x.bookName} == ${x.bookAuthor} - ${paidOrNot}.`);
      });

      return result.join("\n");
    }

    let b = this.books.find((x) => x.bookAuthor === bookAuthor);
    if (!b) {
      return `${bookAuthor} is not in the collection.`;
    }

    let paidOrNot = "Not Paid";
    if (b.payed) {
      paidOrNot = "Has Paid";
    }
    return `${b.bookName} == ${b.bookAuthor} - ${paidOrNot}.`;
  }
}
const library = new LibraryCollection(2);
console.log(library.getStatistics());


