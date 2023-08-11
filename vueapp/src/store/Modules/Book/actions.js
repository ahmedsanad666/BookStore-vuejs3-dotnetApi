
const categoryLink = "https://localhost:7130/bookstore/categories";
const bookLink = "https://localhost:7130/bookstore/books";
export default{

  //...................... category
  async Allcategory(context ){
    const response = await fetch(categoryLink);
      const responseData = await response.json();
    
      if (!response.ok) {
        const error = new Error(responseData.message || 'failed to get category');
  
        throw error;
      }
      const categories =[];
      console.log(responseData);
       responseData.forEach(element => {
        categories.push(element);       
       });

        context.commit("setCategories",categories);
    },
    async AddCat(_,paylaod ){
      const response = await fetch(categoryLink,
      {
        method:'POST',
      
        headers: {
          'Content-Type': 'application/json'
        },
        body:JSON.stringify(paylaod)
      },);

      console.log(response);
      console.log(JSON.stringify(paylaod));
    
      if (!response.ok) {
        const error = 'failed to send data';
        throw error;
      }
    },
    //...................... book

    
  async AllBooks(context ){
    const response = await fetch(bookLink);
      const responseData = await response.json();
    
      if (!response.ok) {
        const error = new Error(responseData.message || 'failed to get books');
  
        throw error;
      }
      const books =[];
      console.log(responseData);
       responseData.forEach(element => {
        books.push(element);       
       });

        context.commit("setBooks",books);
    },
      async AddBook(_,paylaod ){
        const response = await fetch(bookLink,
        {
          method:'POST',
        
        
          body:paylaod
        },);

        console.log(response);
      
        if (!response.ok) {
          const error = 'failed to send data';
          throw error;
        }
      }
}