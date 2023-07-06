import React from 'react';
import { StarFill, StarHalf, Star } from 'react-bootstrap-icons';
import styles from './Rating.module.css'

const Rating = ({ rating }) => {
    const renderStars = () => {
        const filledStars = Math.floor(rating); // Get the number of filled stars (whole number part)
        const hasHalfStar = rating % 1 !== 0; // Check if there is a half star
        const starIcons = [];

        for (let i = 0; i < filledStars; i++) {
            starIcons.push(<StarFill key={i} />);
        }

        if (hasHalfStar) {
            starIcons.push(<StarHalf key={filledStars} />);
        }

        const remainingStars = 5 - Math.ceil(rating); // Get the number of remaining unfilled stars

        for (let i = 0; i < remainingStars; i++) {
            starIcons.push(<Star key={filledStars + (hasHalfStar ? 1 : 0) + i} />);
        }

        return starIcons;
    };

    return <div className={styles["drink-card-container__rating"]}>
        {renderStars()}
        </div>;
};

export default Rating;
