function solve() {
  class Post {
    constructor(title, content) {
      this.title = title;
      this.content = content;
    }

    toString() {
      return `Post: ${this.title}\nContent: ${this.content}`;
    }
  }

  class SocialMediaPost extends Post {
    constructor(title, content, likes, dislikes) {
      super(title, content);
      this.likes = likes;
      this.dislikes = dislikes;
      this.comments = [];
    }

    addComment(str) {
      this.comments.push(str);
    }

    toString() {
      let result = super.toString();
      result += `\nRating: ${this.likes - this.dislikes}`;

      if (this.comments.length > 0) {
        result += `\nComments:`;
        for (let i = 0; i < this.comments.length; i++) {
          const element = this.comments[i];
          result += `\n * ${element}`;
        }
      }

      return result;
    }
  }

  class BlogPost extends Post {
    constructor(title, content,views) {
      super(title, content);
      this.views = views;
    }

    view() {
      this.views++;
      return this;
    }

    toString() {
      return super.toString() + `\nViews: ${this.views}`;
    }
  }

  return { Post, SocialMediaPost, BlogPost };
}

const classes = solve();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content
let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!
