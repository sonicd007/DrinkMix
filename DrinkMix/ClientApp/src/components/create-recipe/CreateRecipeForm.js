import React, { useState } from 'react';
import drinkMixService from '../api-drinkmix/DrinkMixService';

const CreateRecipeForm = () => {
    const [recipeData, setRecipeData] = useState({
        name: '',
        description: '',
        glassTypeId: '',
        imageUrl: '',
        recipeIngredients: [
            { ingredientId: '', unitOfMeasurement: '', quantity: '' },
        ],
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setRecipeData({ ...recipeData, [name]: value });
    };

    const handleIngredientChange = (e, index) => {
        const { name, value } = e.target;
        const propertyName = name.replace(`_${index}`, "");
        const updatedIngredients = [...recipeData.recipeIngredients];
        updatedIngredients[index][propertyName] = value;
        setRecipeData({ ...recipeData, recipeIngredients: updatedIngredients });
    };

    const handleAddIngredient = () => {
        setRecipeData({
            ...recipeData,
            recipeIngredients: [
                ...recipeData.recipeIngredients,
                { ingredientId: '', unitOfMeasurement: '', quantity: '' },
            ],
        });
    };

    const handleRemoveIngredient = (index) => {
        const updatedIngredients = [...recipeData.recipeIngredients];
        console.log(updatedIngredients);
        updatedIngredients.splice(index, 1);
        setRecipeData({ ...recipeData, recipeIngredients: updatedIngredients });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        // Perform form submission logic here
        try {
            let test = await drinkMixService.createRecipe(recipeData);
            console.log(test); // Handle the response data
        } catch (error) {
            console.error(error); // Handle any errors
        }
        console.log(recipeData);
    };

    return (
        <div className="form-container">
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="name">Name:</label>
                    <input type="text" name="name" value={recipeData.name} onChange={handleInputChange} />
                </div>
                <div>
                    <label htmlFor="description">Description:</label>
                    <textarea name="description" value={recipeData.description} onChange={handleInputChange} />
                </div>
                <div>
                    <label htmlFor="glassTypeId">Glass Type ID:</label>
                    <input type="text" name="glassTypeId" value={recipeData.glassTypeId} onChange={handleInputChange} />
                </div>
                <div>
                    <label htmlFor="imageUrl">Image URL:</label>
                    <input type="text" name="imageUrl" value={recipeData.imageUrl} onChange={handleInputChange} />
                </div>
                <div>
                    <h4>Recipe Ingredients:</h4>
                    {recipeData.recipeIngredients.map((ingredient, index) => (
                        <div key={index}>
                            <label htmlFor={`ingredientId_${index}`}>Ingredient ID:</label>
                            <input type="text" name={`ingredientId_${index}`} value={ingredient.ingredientId} onChange={(e) => handleIngredientChange(e, index)} />
                            <label htmlFor={`unitOfMeasurement_${index}`}>Unit of Measurement:</label>
                            <input type="text" name={`unitOfMeasurement_${index}`} value={ingredient.unitOfMeasurement} onChange={(e) => handleIngredientChange(e, index)} />
                            <label htmlFor={`quantity_${index}`}>Quantity:</label>
                            <input type="text" name={`quantity_${index}`} value={ingredient.quantity} onChange={(e) => handleIngredientChange(e, index)} />
                            <button type="button" onClick={() => handleRemoveIngredient(index)}>Remove</button>
                        </div>
                    ))}
                    <button type="button" onClick={handleAddIngredient}>Add Ingredient</button>
                </div>
                <button type="submit">Create Recipe</button>
            </form>
        </div>
    );
};

export default CreateRecipeForm;
