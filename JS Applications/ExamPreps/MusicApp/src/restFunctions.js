import * as api from "./fetchRequests.js";

export let login = api.login;
export let register = api.register;
export let logout = api.logout;

//export async function getAllGames() {
//  return api.get("/data/games?sortBy=_createdOn%20desc"); --- Example
//}

export async function getAllAlbums() {
  return api.get("/data/albums?sortBy=_createdOn%20desc&distinct=name");
}

export async function createAlbum(albumData) {
  return api.post("/data/albums", albumData);
}

export async function getOneAlbum(albumId) {
  return api.get("/data/albums/" + albumId);
}

export async function delAlbum(albumId) {
  return api.del("/data/albums/" + albumId);
}

export async function editAlbum(albumId, data) {
  return api.put("/data/albums/" + albumId, data);
}

export async function searchAlbums(query) {
  return api.get(`/data/albums?where=name%20LIKE%20%22${query}%22`);
}
