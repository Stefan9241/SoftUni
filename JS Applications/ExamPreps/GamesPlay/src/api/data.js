import * as api from "./api.js";

export let login = api.login;
export let register = api.register;
export let logout = api.logout;

export async function getAllGames() {
  return api.get("/data/games?sortBy=_createdOn%20desc");
}
export async function getAllGamesForHomePage() {
  return api.get("/data/games?sortBy=_createdOn%20desc&distinct=category");
}

export async function createGame(gameData) {
  return api.post("/data/games", gameData);
}

export async function getGameDetails(url) {
  return api.get("/data/games/" + url);
}

export async function editGame(url,gameData) {
  return api.put("/data/games/" + url, gameData);
}

export async function deleteGame(url) {
  return api.del("/data/games/" + url);
}