import * as api from "./api.js";

export let login = api.login;
export let register = api.register;
export let logout = api.logout;

export function createBook(book) {
  return api.post("/data/books", book);
}
export function getAllBooks() {
  return api.get("/data/books?sortBy=_createdOn%20desc");
}

export function getBookDetails(bookId) {
  return api.get("/data/books/" + bookId);
}

export function editBook(bookId, book) {
  return api.put("/data/books/" + bookId, book);
}

export function deleteBook(bookId) {
  return api.del("/data/books/" + bookId);
}

export function getMyBooks(userId) {
  return api.get(
    `/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
  );
}

export function addLike(bookId) {
  return api.post("/data/likes", { bookId });
}

export function getBookLikes(bookId) {
  return api.get(
    `/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`
  );
}

export function checkIfLiked(bookId, userId) {
  return api.get(
    `/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`
  );
}
