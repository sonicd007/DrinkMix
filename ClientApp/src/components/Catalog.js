import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
import { Pagination, PaginationItem, PaginationLink } from 'reactstrap';
import HappyAlcoholicsImage from '../resources/images/happy-alcoholics-placeholder.jpg';
import PH300x300 from '../resources/images/placeholders/300x300.svg';
import { Star, StarFill, StarHalf } from 'react-bootstrap-icons';
import SummaryContainer from './SummaryContainer';
import Rating from './Rating';
import DrinkCard from './DrinkCard';
export class Catalog extends Component {
    static displayName = Catalog.name;

    render() {
        var drink_cards = [];
        for (let i = 0; i < 6; i++) {
            drink_cards.push(<Col sm="6" md="4">
                <DrinkCard name="Old Fashioned"
                    altText="Image of whiskey glass with whiskey and cherry"
                    description="The old fashioned is a classic cocktail that was invented in Louisville, KY. You can make it with bourbon, rye, or a blended whiskey."
                    imageUrl={PH300x300}
                    ingredients={["Whiskey", "Simple Syrup", "Orange Bitters", "Maraschino Cherry"]}
                    rating="4.5"
                    key={i}
                /></Col>)
        }
        return (
            <div>
                <Row>
                    <Col sm="12">
                        <SummaryContainer
                            title="Catalog"
                            description="Welcome to DrinkMix! On this page you'll find our catalog of drink recipes. You can view the ingredients, ratings (coming soon), name, and even favorite any drinks you think you may like!"
                            imageUrl={HappyAlcoholicsImage}
                            altText="Three women happily drinking alcohol near enlarged glasses and pitchers filled with lime, ice, and oranges."
                        />
                    </Col>
                </Row>
                <Row>
                    { drink_cards }
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
