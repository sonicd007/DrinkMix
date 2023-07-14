import React from 'react';
import { Row, Col } from 'reactstrap';
import Rating from '../rating/Rating';
// TODO: Styles should be coming from this module not drinkcard
import styles from './DrinkCard.module.css';

const DrinkCard = ({ name, description, ingredients, rating, imageUrl, altText }) => {
    return (
        <div className={styles["drink-card-container"]}>
            <Row>
                <Col sm="12" md="6">
                    <div className="drink-card-container__details">
                        <h3>{name}</h3>
                        <p>{description}</p>
                    </div>
                </Col>
                <Col sm="12" md="6">
                    <div className={styles["drink-card-container__drink-image"]}>
                        <img src={imageUrl} alt={altText} />
                    </div>
                </Col>
            </Row>
            <Row>
                <Col sm="12">
                    <h3>Ingredients</h3>
                    <ul className="drink-card-container__ingredients-list">
                        {ingredients.map((ingredient, index) => (
                            <li className="drink-card-container__ingredient" key={index}>
                                {ingredient}
                            </li>
                        ))}
                    </ul>
                    <Rating rating={rating} />
                </Col>
            </Row>
        </div>
    );
};

export default DrinkCard;