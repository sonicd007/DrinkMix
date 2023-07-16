import React from 'react';
import { Row, Col } from 'reactstrap';
import SummaryContainer from '../summary-container/SummaryContainer';
import CreateRecipeForm from '../create-recipe/CreateRecipeForm';
import CreateUpdateIngredientForm from '../create-update-ingredient/CreateUpdateIngredientForm';
import CreateUpdateIngredientTypeForm from '../create-update-ingredienttype/CreateUpdateIngredientTypeForm';

const CreateRecipe = () => {
    const handleSubmit = (formData) => {
        // Submit the form data to the API or perform other actions
        console.log(formData);
    };

    return (
        <div>
            <Row>
                <Col sm="12">
                    <SummaryContainer
                        title="Create Recipe"
                        description="Here you can create a recipe, ingredients, and ingredient types."
                    />
                </Col>
                <Col sm="6">
                    <CreateUpdateIngredientTypeForm initialData={{ name: '' }} onSubmit={handleSubmit} />
                </Col>
                <Col sm="6">
                    <CreateUpdateIngredientForm />
                </Col>
                <Col sm="12">
                    <CreateRecipeForm />
                </Col>
            </Row>
        </div>
    );
};

export default CreateRecipe;
