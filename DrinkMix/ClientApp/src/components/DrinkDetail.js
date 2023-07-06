import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faWhiskeyGlass, faMortarPestle } from '@fortawesome/free-solid-svg-icons';
import PH337x584 from '../resources/images/placeholders/337x584.svg';
import SummaryContainer from './SummaryContainer';
export class DrinkDetail extends Component {
    static displayName = DrinkDetail.name;

    render() {
        return (
            <div>
                <Row>
                    <Col sm="12">
                        <SummaryContainer
                            title="Drink Detail"
                            description="Old Fashion"
                        />
                    </Col>
                    <Col sm="12" md="6">
                        <div className="glass-visualizer-container d-none d-md-block">
                            <img src={PH337x584} alt="visualization of drink filling with various parts of components" />
                            <span>Whiskey 70%</span>
                            <span>Simple Syrup 30%</span>
                        </div>
                    </Col>
                    <Col sm="12" md="6">
                        <div className="drink-detail-container">
                            <div className="drink-detail-container__glass-type">
                                <div className="drink-detail-container__glass-type-icon-container">
                                    <FontAwesomeIcon icon={faWhiskeyGlass} />
                                </div>
                                <div className="drink-detail-container__glass-type-information">
                                    <h3>Glass Type</h3>
                                    <p>Whiskey Glass</p>
                                </div>
                            </div>
                            <div className="drink-detail-container__ingredients">
                                <div className="drink-detail-container__ingredients-icon-container">
                                    <FontAwesomeIcon icon={faMortarPestle} />
                                </div>
                                <div className="drink-detail-container__ingredients-information">
                                    <h3>Ingredients</h3>
                                    <p>1 part Whiskey (10 oz)</p>
                                </div>
                            </div>
                            <div className="drink-detail-container__how-to-make-container">
                                <p>Pour simple syrup, water, and bitters into a whiskey glass; stir to combine. Add ice cubes and pour in bourbon. Garnish with orange slice and maraschino cherry. </p>
                            </div>
                            <hr />
                            <div className="drink-detail-container__drink-information">
                                <p>An old fashioned is a classic whiskey cocktail with bitters, simple syrup, and fruit. Experts believe the drink is called the "old fashioned" because it's one of the first widely known cocktails ever. The name comes from people ordering the drink the "old-fashioned way. </p>
                            </div>
                        </div>
                    </Col>
                </Row>
            </div >
        );
    }
}
