import * as api from "./fetchRequests.js";

export let login = api.login;
export let register = api.register;
export let logout = api.logout;

export async function getAllTheathers() {
  return api.get("/data/theaters?sortBy=_createdOn%20desc&distinct=title");
}

export async function createTheather(newTheatherInfo) {
  return api.post("/data/theaters", newTheatherInfo);
}
export async function getProfileTheathers(userId) {
  return api.get(
    `/data/theaters?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
  );
}

export async function getOneTheather(id) {
  return api.get("/data/theaters/" + id);
}

export async function deleteTheather(id) {
  return api.del("/data/theaters/" + id);
}

export async function editTheather(id, newData) {
  return api.put("/data/theaters/" + id, newData);
}

export async function getTheatherLikes(theatherId) {
  return api.get(
    `/data/likes?where=theaterId%3D%22${theatherId}%22&distinct=_ownerId&count`
  );
}

export async function checkIfLiked(theaterId, userId) {
  return api.get(
    `/data/likes?where=theaterId%3D%22${theaterId}%22%20and%20_ownerId%3D%22${userId}%22&count`
  );
}

export async function sendLike(data) {
  return api.post("/data/likes", data);
}
