import * as api from "./fetchRequests.js";

export let login = api.login;
export let register = api.register;
export let logout = api.logout;

export async function getAllMemes() {
  return api.get("/data/memes?sortBy=_createdOn%20desc");
}
export async function getOneMeme(id) {
  return api.get("/data/memes/" + id);
}
export async function createMeme(data) {
  return api.post("/data/memes", data);
}
export async function deleteMeme(id) {
  return api.del("/data/memes/" + id);
}

export async function editMeme(id, newData) {
  return api.put("/data/memes/" + id, newData);
}
export async function getUserMemes(userId) {
  return api.get(
    `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
  );
}
