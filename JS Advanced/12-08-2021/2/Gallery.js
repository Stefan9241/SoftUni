class ArtGallery {
  constructor(creator) {
    this.creator = creator;
    this.possibleArticles = {
      picture: 200,
      photo: 50,
      item: 250,
    };
    this.listOfArticles = [];
    this.guests = [];
  }

  addArticle(articleModel, articleName, quantity) {
    if (
      Object.keys(this.possibleArticles).includes(articleModel.toLowerCase()) ==
      false
    ) {
      throw new Error("This article model is not included in this gallery!");
    }

    let article = this.listOfArticles.find((x) => x.name === articleName);
    if (article == undefined) {
      this.listOfArticles.push({
        model: articleModel.toLowerCase(),
        name: articleName,
        quantity: quantity,
      });
    } else {
      article.quantity += quantity;
    }

    return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
  }

  inviteGuest(guestName, personality) {
    if (this.guests.some(x=> x.name === guestName)) {
      throw new Error(`${guestName} has already been invited.`);
    }

    let currPersonPoints = 0;
    if (personality === "Vip") {
      currPersonPoints = 500;
    } else if (personality === "Middle") {
      currPersonPoints = 250;
    } else {
      currPersonPoints = 50;
    }

    this.guests.push({
      name: guestName,
      points: currPersonPoints,
      purchaseArticle: 0,
    });

    return `You have successfully invited ${guestName}!`;
  }

  buyArticle(articleModel, articleName, guestName) {
    let article = this.listOfArticles.find(
      (x) => x.name === articleName && x.model === articleModel
    );

    let guest = this.guests.find((x) => x.name === guestName);
    if (article == undefined) {
      throw new Error("This article is not found.");
    }

    if (article.quantity === 0) {
      return `The ${articleName} is not available.`;
    }

    if (guest == undefined) {
      return `This guest is not invited.`;
    }

    let currArticleValue = this.possibleArticles[articleModel.toLowerCase()];
    if (guest.points < currArticleValue) {
      return `You need to more points to purchase the article.`;
    } else {
      guest.points -= currArticleValue;
      article.quantity--;
      guest.purchaseArticle++;
    }

    return `${guestName} successfully purchased the article worth ${currArticleValue} points.`;
  }

  showGalleryInfo(criteria) {
    let result = [];
    if (criteria === "article") {
      result.push("Articles information:");

      for (const key of this.listOfArticles) {
        result.push(`${key.model} - ${key.name} - ${key.quantity}`);
      }
    } else {
      result.push("Guests information:");

      for (const key of this.guests) {
        result.push(`${key.name} - ${key.purchaseArticle}`);
      }
    }

    return result.join("\n");
  }
}


const artGallery = new ArtGallery('Curtis Mayfield'); 
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));



