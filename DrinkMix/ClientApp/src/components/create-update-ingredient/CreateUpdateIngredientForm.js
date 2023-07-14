import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';
import drinkMixService from '../api-drinkmix/DrinkMixService';

const IngredientForm = ({ ingredientId }) => {
    const [name, setName] = useState('');
    const [ingredientType, setIngredientType] = useState('');
    const history = useHistory();

    useEffect(() => {
        if (ingredientId) {
            // Fetch ingredient data for update
            drinkMixService.getIngredientById(ingredientId)
                .then((data) => {
                    setName(data.name);
                    setIngredientType(data.ingredientType);
                })
                .catch((error) => {
                    console.error(error);
                });
        }
    }, [ingredientId]);

    const handleSubmit = (e) => {
        e.preventDefault();

        const ingredientData = {
            name,
            ingredientType,
        };

        if (ingredientId) {
            // Update existing ingredient
            drinkMixService.updateIngredient(ingredientId, ingredientData)
                .then(() => {
                    console.log('Ingredient updated successfully');
                    history.push('/ingredients');
                })
                .catch((error) => {
                    console.error(error);
                });
        } else {
            // Create new ingredient
            drinkMixService.createIngredient(ingredientData)
                .then(() => {
                    console.log('Ingredient created successfully');
                    history.push('/ingredients');
                })
                .catch((error) => {
                    console.error(error);
                });
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="name">Name:</label>
                <input type="text" id="name" value={name} onChange={(e) => setName(e.target.value)} required />
            </div>
            <div>
                <label htmlFor="ingredientType">Ingredient Type:</label>
                <input type="text" id="ingredientType" value={ingredientType} onChange={(e) => setIngredientType(e.target.value)} required />
            </div>
            <button type="submit">Save</button>
        </form>
    );
};

export default IngredientForm;
