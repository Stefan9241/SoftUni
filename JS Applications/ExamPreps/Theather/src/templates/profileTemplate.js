import { html } from "../modules.js";
import { getProfileTheathers } from "../restFunctions.js";
import { getUserData } from "../session.js";
let profileTemplate = (user, myTheathers) => html` <section id="profilePage">
  <div class="userInfo">
    <div class="avatar">
      <img src="./images/profilePic.png" />
    </div>
    <h2>${user.email}</h2>
  </div>
  <div class="board">
    <!--If there are event-->
    ${myTheathers && myTheathers.length != 0
      ? myTheathers.map(oneItemCard)
      : html`<div class="no-events">
          <p>This user has no events yet!</p>
        </div>`}

    <!--If there are no event-->
  </div>
</section>`;

let oneItemCard = (item) => html` <div class="eventBoard">
  <div class="event-info">
    <img src=${item.imageUrl} />
    <h2>${item.title}</h2>
    <h6>${item.date}</h6>
    <a href="/details/${item._id}" class="details-button">Details</a>
  </div>
</div>`;

export async function profileRoute(ctx) {
  let user = getUserData();
  let myTheathers = await getProfileTheathers(user.id);
  return ctx.render(profileTemplate(user, myTheathers));
}
