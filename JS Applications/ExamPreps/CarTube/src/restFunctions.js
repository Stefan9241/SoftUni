import * as api from "./fetchRequests.js";

export let login = api.login;
export let register = api.register;
export let logout = api.logout;

export async function getAllCars() {
  return api.get("/data/cars?sortBy=_createdOn%20desc");
}

export async function createCar(data) {
  return api.post("/data/cars", data);
}

export async function getOneCar(carId) {
  return api.get("/data/cars/" + carId);
}

export async function deleteCar(carId) {
  return api.del("/data/cars/" + carId);
}
export async function editCar(carId, newData) {
  return api.put("/data/cars/" + carId, newData);
}

export async function getMyCars(userId) {
  return api.get(
    `/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
  );
}

export async function searchItems(query) {
  return api.get(`/data/cars?where=year%3D${query}`);
}
