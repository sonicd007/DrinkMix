import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
import { Pagination, PaginationItem, PaginationLink } from 'reactstrap';
import HappyAlcoholicsImage from '../resources/images/happy-alcoholics-placeholder.jpg';
import PH300x300 from '../resources/images/placeholders/300x300.svg';
import { Star, StarFill, StarHalf } from 'react-bootstrap-icons';
export class Catalog extends Component {
    static displayName = Catalog.name;

    render() {
        return (
            <div>
                <Row>
                    <Col sm="12">
                        <div className="catalog-page-summary-container">
                            <div className="catalog-page-summary-container__summary-text">
                                <h2>Catalog</h2>
                                <p>Welcome to DrinkMix! On this page you'll find our catalog of drink recipes. You can view the ingredients, ratings (coming soon), name, and even favorite any drinks you think you may like! </p>
                            </div>
                            <div className="catalog-page-summary-container__people-drinking-image d-none d-md-block">
                                <img src={HappyAlcoholicsImage} alt="Three women happily drinking alcohol near enlarged glasses and pitchers filled with lime, ice, and oranges." />
                            </div>
                        </div>
                    </Col>
                </Row>
                <Row>
                    {// TODO: React component for drink cards 
                    }
                    <Col sm="6" md="4">
                        <div className="drink-card-container">
                            <h3>Old Fashioned</h3>
                            <div className="drink-card-container__mobile-cocktail-image d-small-block d-md-none">
                                <img src={PH300x300} alt="lorem ipsum" />
                            </div>
                            <p>The old fashioned is a classic cocktail that was invented in Louisville, KY. You can make it with bourbon, rye, or a blended whiskey.</p>
                            <h3>Ingredients</h3>
                            <span className="drink-card-container__ingredient">Whiskey</span>
                            <span className="drink-card-container__ingredient">Simple Syrup</span>
                            <span className="drink-card-container__ingredient">Orange Bitters</span>
                            <span className="drink-card-container__ingredient">Maraschino Cherry</span>
                            <div className="drink-card-container__rating">
                                <StarFill />
                                <StarFill />
                                <StarFill />
                                <StarHalf />
                                <Star />
                            </div>
                        </div>
                        <div className="drink-card-container__drink-image d-none d-md-block">
                            <img src={PH300x300} alt="lorem ipsum" />
                        </div>
                    </Col>
                    <Col sm="6" md="4">
                        <div className="drink-card-container">
                            <div className="drink-card-container__information">
                                <h3>Old Fashioned</h3>
                                <div className="drink-card-container__mobile-cocktail-image d-small-block d-md-none">
                                    <img src={PH300x300} alt="lorem ipsum" />
                                </div>
                                <p>The old fashioned is a classic cocktail that was invented in Louisville, KY. You can make it with bourbon, rye, or a blended whiskey.</p>
                                <h3>Ingredients</h3>
                                <span className="drink-card-container__ingredient">Whiskey</span>
                                <span className="drink-card-container__ingredient">Simple Syrup</span>
                                <span className="drink-card-container__ingredient">Orange Bitters</span>
                                <span className="drink-card-container__ingredient">Maraschino Cherry</span>
                            </div>
                            <div className="drink-card-container__rating">
                                <StarFill />
                                <StarFill />
                                <StarFill />
                                <StarHalf />
                                <Star />
                            </div>
                        </div>
                        <div className="drink-card-container__drink-image d-none d-md-block">
                            <img src={PH300x300} alt="lorem ipsum" />
                        </div>
                    </Col>
                    <Col sm="6" md="4">
                        <div className="drink-card-container">
                            <div className="drink-card-container__information">
                                <h3>Old Fashioned</h3>
                                <div className="drink-card-container__mobile-cocktail-image d-small-block d-md-none">
                                    <img src={PH300x300} alt="lorem ipsum" />
                                </div>
                                <p>The old fashioned is a classic cocktail that was invented in Louisville, KY. You can make it with bourbon, rye, or a blended whiskey.</p>
                                <h3>Ingredients</h3>
                                <span className="drink-card-container__ingredient">Whiskey</span>
                                <span className="drink-card-container__ingredient">Simple Syrup</span>
                                <span className="drink-card-container__ingredient">Orange Bitters</span>
                                <span className="drink-card-container__ingredient">Maraschino Cherry</span>
                            </div>
                            <div className="drink-card-container__rating">
                                <StarFill />
                                <StarFill />
                                <StarFill />
                                <StarHalf />
                                <Star />
                            </div>
                        </div>
                        <div className="drink-card-container__drink-image d-none d-md-block">
                            <img src={PH300x300} alt="lorem ipsum" />
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col sm="12" className="d-flex justify-content-center">
                        <Pagination>
                            <PaginationItem>
                                <PaginationLink
                                    first
                                    href="#"
                                />
                            </PaginationItem>
                            <PaginationItem>
                                <PaginationLink
                                    href="#"
                                    previous
                                />
                            </PaginationItem>
                            <PaginationItem>
                                <PaginationLink href="#">
                                    1
                                </PaginationLink>
                            </PaginationItem>
                            <PaginationItem>
                                <PaginationLink href="#">
                                    2
                                </PaginationLink>
                            </PaginationItem>
                            <PaginationItem>
                                <PaginationLink href="#">
                                    3
                                </PaginationLink>
                            </PaginationItem>
                            <PaginationItem>
                                <PaginationLink href="#">
                                    4
                                </PaginationLink>
                            </PaginationItem>
                            <PaginationItem>
                                <PaginationLink href="#">
                                    5
                                </PaginationLink>
                            </PaginationItem>
                            <PaginationItem>
                                <PaginationLink
                                    href="#"
                                    next
                                />
                            </PaginationItem>
                            <PaginationItem>
                                <PaginationLink
                                    href="#"
                                    last
                                />
                            </PaginationItem>
                        </Pagination>
                    </Col>
                </Row>
            </div >
        );
    }
}
