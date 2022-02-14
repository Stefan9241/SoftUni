class Story {
  constructor(title, creator) {
    this.title = title;
    this.creator = creator;
    this.comments = [];
    this._likes = [];
  }

  get likes() {
    if (this._likes.length === 0) {
      return `${this.title} has 0 likes`;
    } else if (this._likes.length === 1) {
      let person = this._likes[0];
      return `${person} likes this story!`;
    } else {
      let person = this._likes[0];
      return `${person} and ${this._likes.length - 1} others like this story!`;
    }
  }

  like(username) {
    if (this._likes.includes(username)) {
      throw new Error(`You can't like the same story twice!`);
    } else if (this.creator === username) {
      throw new Error("You can't like your own story!");
    } else {
      this._likes.push(username);
      return `${username} liked ${this.title}!`;
    }
  }

  dislike(username) {
    if (this._likes.includes(username) == false) {
      throw new Error(`You can't dislike this story!`);
    } else {
      this._likes = this._likes.filter((x) => x !== username);

      return `${username} disliked ${this.title}`;
    }
  }

  comment(username, content, id) {
    let comment = this.comments.find(x=> x.Id == id);
    if (!id || comment == undefined) {
      comment = {
        Id: this.comments.length + 1,
        Username: username,
        Content: content,
        Replies: [],
      };

      this.comments.push(comment);

      return `${username} commented on ${this.title}`;
    } else {
      comment.Replies.push({
        Id: `${id}.${comment.Replies.length + 1}`,
        Username: username,
        Content: content,
      });

      return `You replied successfully`;
    }
  }

  toString(sortingType) {
    let result = [];
    if (sortingType === "asc") {
      this.comments = this.comments.sort((a, b) => a.Id - b.Id);
      result.push(`Title: ${this.title}`);
      result.push(`Creator: ${this.creator}`);
      result.push(`Likes: ${this._likes.length}`);
      if (this.comments.length === 0) {
        result.push("Comments:");

        return result.join("\n");
      } else {
        result.push("Comments:");

        this.comments.forEach((x) => {
          result.push(`-- ${x.Id}. ${x.Username}: ${x.Content}`);
          if (x.Replies.length != 0) {
            x.Replies.sort((a,b) => a.Id - b.Id);
            x.Replies.forEach((x) => {
              result.push(`--- ${x.Id}. ${x.Username}: ${x.Content}`);
            });
          }
        });

        return result.join("\n");
      }
    } else if (sortingType === "desc") {
      this.comments = this.comments.sort((a, b) => b.Id - a.Id);

      result.push(`Title: ${this.title}`);
      result.push(`Creator: ${this.creator}`);
      result.push(`Likes: ${this._likes.length}`);
      if (this.comments.length === 0) {
        result.push("Comments:");

        return result.join("\n");
      } else {
        result.push("Comments:");

        this.comments.forEach((x) => {
          result.push(`-- ${x.Id}. ${x.Username}: ${x.Content}`);
          if (x.Replies.length != 0) {
            x.Replies.sort((a,b) => b.Id - a.Id);
            
            x.Replies.forEach((x) => {
              result.push(`--- ${x.Id}. ${x.Username}: ${x.Content}`);
            });
          }
        });

        return result.join("\n");
      }
    } else {
      this.comments = this.comments.sort((a, b) =>
        a.Username.localeCompare(b.Username)
      );

      result.push(`Title: ${this.title}`);
      result.push(`Creator: ${this.creator}`);
      result.push(`Likes: ${this._likes.length}`);
      if (this.comments.length === 0) {
        result.push("Comments:");

        return result.join("\n");
      } else {
        result.push("Comments:");

        this.comments.forEach((x) => {
          result.push(`-- ${x.Id}. ${x.Username}: ${x.Content}`);
          if (x.Replies.length != 0) {
            x.Replies.sort((a,b)=> a.Username.localeCompare(b.Username));

            x.Replies.forEach((x) => {
              result.push(`--- ${x.Id}. ${x.Username}: ${x.Content}`);
            });
          }
        });

        return result.join("\n");
      }
    }
  }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log();
console.log(art.toString("username"));
console.log();
art.like("Zane");
console.log(art.toString("desc"));
