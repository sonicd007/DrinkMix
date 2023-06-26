import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
export class WhatCanIMake extends Component {
    static displayName = WhatCanIMake.name;

    render() {
        return (
            <div>
                <Row>
                    <Col sm="12">
                        <div className="page-summary-container">
                            <div className="page-summary-container__summary-text">
                                <h2>What can I make?</h2>
                                <p>On this page, you can select the ingredients on hand to get a list of drinks you may be able to make.</p>
                            </div>
                        </div>
                    </Col>
                    <Col sm="12">
                        <h3>Base liquors</h3>
                        <ul>
                            <li>Gin</li>
                            <li>Vodka</li>
                            <li>Tequila</li>
                            <li>Rum</li>
                            <li>Brandy</li>
                        </ul>
                    </Col>
                    <Col sm="12">
                        <h3>Liqueurs</h3>
                        <ul>
                            <li>Amaretto</li>
                            <li>Kahlua</li>
                            <li>Campari</li>
                            <li>Baileys</li>
                            <li>Rumchata</li>
                        </ul>
                    </Col>
                    <Col sm="12">
                        <h3>Fortified Wines</h3>
                        <ul>
                            <li>Sweet Vermouth</li>
                            <li>Dry Vermouth</li>
                            <li>Sherry</li>
                            <li>Marsala</li>
                        </ul>
                    </Col>
                </Row>
            </div >
        );
    }
}
