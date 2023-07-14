import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
import SummaryContainer from '../summary-container/SummaryContainer';
import CreateRecipeForm from '../create-recipe/CreateRecipeForm';

export class CreateRecipe extends Component {
    static displayName = CreateRecipe.name;

    render() {
        return (
            <div>
                <Row>
                    <Col sm="12">
                        <SummaryContainer
                            title="Create Recipe"
                            description="Here you can create a recipe, ingredients, and ingredient types."
                        />
                    </Col>
                    <Col sm="12">
                        <CreateRecipeForm />
                    </Col>
                </Row>
            </div>
        )};
};

export default CreateRecipe;