import React from 'react';
import styles from './SummaryContainer.module.css'

const SummaryContainer = ({ title, description, imageUrl, altText }) => {
    return (
        <div className={styles['summary-container']} >
            <div className="summary-container__summary-text">
                <h2>{title}</h2>
                <p>{description}</p>
            </div>

            {
                // Only render when both imageUrl and altText is passed in
                imageUrl && altText ? (
                <div className="summary-container__people-drinking-image d-none d-md-block">
                    <img src={imageUrl} alt={altText} />
                </div>
            ) : null}
        </div>
    );
};

export default SummaryContainer;
