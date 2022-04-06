import * as api from "./fetchRequests.js";

export let login = api.login;
export let register = api.register;
export let logout = api.logout;

export async function getAllAnimals() {
  return api.get("/data/pets?sortBy=_createdOn%20desc&distinct=name");
}

export async function createPet(petInfo) {
  return api.post("/data/pets", petInfo);
}

export async function getOnePet(petId) {
  return api.get("/data/pets/" + petId);
}

export async function deletePet(petId) {
  return api.del("/data/pets/" + petId);
}

export async function editPet(petId, newData) {
  return api.put("/data/pets/" + petId, newData);
}

export async function addDonation(body) {
  return api.post("/data/donation", body);
}

export async function petDonationCount(petId) {
  return api.get(
    `/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`
  );
}

export async function checkIfUserDonated(petId, userId) {
  return api.get(
    `/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`
  );
}
