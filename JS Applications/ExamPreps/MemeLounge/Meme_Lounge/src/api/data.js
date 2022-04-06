import * as api from "./api.js";

export let login = api.login;
export let register = api.register;
export let logout = api.logout;

export async function getAllMemes() {
  return api.get("/data/memes?sortBy=_createdOn%20desc");
}

export async function getItemById(id) {
  return api.get("/data/memes/" + id);
}

export async function getById(userId) {
  return api.get(
    `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
  );
}
export async function create(item) {
  return api.post("/data/memes", item);
}

export async function editById(id, item) {
  return api.put("/data/memes/" + id, item);
}
export async function deleteById(id) {
  return api.del("/data/memes/" + id);
}
