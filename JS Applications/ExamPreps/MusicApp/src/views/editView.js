import { html } from "../modules.js";
import { editAlbum, getOneAlbum } from "../restFunctions.js";

let editTemplate = (item, onSubmit) => html` <section class="editPage">
  <form @submit=${onSubmit}>
    <fieldset>
      <legend>Edit Album</legend>

      <div class="container">
        <label for="name" class="vhide">Album name</label>
        <input
          id="name"
          name="name"
          class="name"
          type="text"
          value=${item.name}
        />

        <label for="imgUrl" class="vhide">Image Url</label>
        <input
          id="imgUrl"
          name="imgUrl"
          class="imgUrl"
          type="text"
          value=${item.imgUrl}
        />

        <label for="price" class="vhide">Price</label>
        <input
          id="price"
          name="price"
          class="price"
          type="text"
          value=${item.price}
        />

        <label for="releaseDate" class="vhide">Release date</label>
        <input
          id="releaseDate"
          name="releaseDate"
          class="releaseDate"
          type="text"
          value=${item.releaseDate}
        />

        <label for="artist" class="vhide">Artist</label>
        <input
          id="artist"
          name="artist"
          class="artist"
          type="text"
          value=${item.artist}
        />

        <label for="genre" class="vhide">Genre</label>
        <input
          id="genre"
          name="genre"
          class="genre"
          type="text"
          value=${item.genre}
        />

        <label for="description" class="vhide">Description</label>
        <textarea name="description" class="description" rows="10" cols="10">
${item.description}</textarea
        >

        <button class="edit-album" type="submit">Edit Album</button>
      </div>
    </fieldset>
  </form>
</section>`;

export async function showEdit(ctx) {
  let albumToEdit = await getOneAlbum(ctx.params.id);

  async function onSubmit(event) {
    event.preventDefault();

    let formData = new FormData(event.target);
    let name = formData.get("name");
    let imgUrl = formData.get("imgUrl");
    let price = formData.get("price");
    let releaseDate = formData.get("releaseDate");
    let artist = formData.get("artist");
    let genre = formData.get("genre");
    let description = formData.get("description");

    if (
      name == "" ||
      imgUrl == "" ||
      price == "" ||
      releaseDate == "" ||
      artist == "" ||
      genre == "" ||
      description == ""
    ) {
      return alert("All fields are required!");
    }
    let newAlbumData = {
      name,
      imgUrl,
      price,
      releaseDate,
      artist,
      genre,
      description,
    };

    await editAlbum(albumToEdit._id, newAlbumData);
    ctx.page.redirect("/catalog");
  }

  return ctx.render(editTemplate(albumToEdit, onSubmit));
}
