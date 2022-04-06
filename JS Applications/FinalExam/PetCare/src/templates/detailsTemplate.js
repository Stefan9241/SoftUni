import { html } from "../modules.js";
import {
  addDonation,
  checkIfUserDonated,
  deletePet,
  getOnePet,
  petDonationCount,
} from "../restFunctions.js";
import { getUserData } from "../session.js";

let detailsTemplate = (
  pet,
  isOwner,
  user,
  deletePetFunction,
  currDonationCount,
  checkIfDonated,
  donateMoney
) => html` <section id="detailsPage">
  <div class="details">
    <div class="animalPic">
      <img src=${pet.image} />
    </div>
    <div>
      <div class="animalInfo">
        <h1>Name: ${pet.name}</h1>
        <h3>Breed: ${pet.breed}</h3>
        <h4>Age: ${pet.age} years</h4>
        <h4>Weight: ${pet.weight}kg</h4>
        <h4 class="donation">Donation: ${currDonationCount}$</h4>
      </div>
      <!-- if there is no registered user, do not display div-->
      ${btnsTemplate(
        pet,
        isOwner,
        user,
        deletePetFunction,
        checkIfDonated,
        donateMoney
      )}
      
  </div>
</section>`;

let btnsTemplate = (
  pet,
  isOwner,
  user,
  deletePetFunction,
  checkIfDonated,
  donateMoney
) => {
  if (user && isOwner === false && checkIfDonated === 0) {
    return html`<div class="actionBtn">
    <!--(Bonus Part) Only for no creator and user-->
    <a @click=${donateMoney} href="javascript:void(0)" class="donate">Donate</a>
  </div>
</div>`;
  } else if (isOwner) {
    return html`<div class="actionBtn">
      <!-- Only for registered user and creator of the pets-->
      <a href="/edit/${pet._id}" class="edit">Edit</a>
      <a @click=${deletePetFunction} href="javascript:void(0)" class="remove"
        >Delete</a
      >
    </div>`;
  } else {
    return undefined;
  }
};
export async function detailsRoute(ctx) {
  let currPet = await getOnePet(ctx.params.id);
  let currUser = getUserData();
  let isOwner = currUser && currUser.id === currPet._ownerId;
  let currDonationCount = await petDonationCount(ctx.params.id);
  currDonationCount *= 100;
  let checkIfDonated = await checkIfUserDonated(ctx.params.id, currUser.id);

  async function donateMoney(event) {
    event.preventDefault();
    let petId = ctx.params.id;
    let body = { petId };
    await addDonation(body);
    currDonationCount = await petDonationCount(petId);
    currDonationCount *= 100;
    checkIfDonated = await checkIfUserDonated(petId, currUser.id);
    ctx.render(
      detailsTemplate(
        currPet,
        isOwner,
        currUser,
        deletePetFunction,
        currDonationCount,
        checkIfDonated,
        donateMoney
      )
    );
  }
  async function deletePetFunction(event) {
    event.preventDefault();
    let choice = confirm("Are you sure ?");
    if (choice) {
      await deletePet(ctx.params.id);
      ctx.page.redirect("/");
    }
  }
  return ctx.render(
    detailsTemplate(
      currPet,
      isOwner,
      currUser,
      deletePetFunction,
      currDonationCount,
      checkIfDonated,
      donateMoney
    )
  );
}
