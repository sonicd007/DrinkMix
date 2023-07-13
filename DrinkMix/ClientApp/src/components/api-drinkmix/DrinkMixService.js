// apiService.js

export class DrinkMixService {
    BASE_URL = 'https://localhost:44478/api'; // Replace with your API base URL

    handleResponse = (response) => {
        if (!response.ok) {
            throw new Error(response.statusText);
        }
        return response.json();
    };

    getRecipes = async () => {
        return fetch(`${this.BASE_URL}/recipes`)
            .then(this.handleResponse);
    };

    createRecipe = async (recipeData) => {
        try {
            const response = await fetch(`${this.BASE_URL}/recipes`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(recipeData),
            });

            const data = await response.json();
            return data;
        } catch (error) {
            // Handle any errors that occurred during the API call
            console.error(error);
            throw error;
        }
    };

    static get instance() { return drinkMixService }
}

const drinkMixService = new DrinkMixService();

export default drinkMixService;
// Additional API methods...

//export default drinkmixService = {
//    getRecipes,
//    createRecipe,
//    // Add other methods here
//};
