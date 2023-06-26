import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
import { Search as MagnifyingGlass } from 'react-bootstrap-icons';
export class Search extends Component {
    static displayName = Search.name;

    render() {
        return (
            <div>
                <Row>
                    <Col sm="12">
                        <div className="page-summary-container">
                            <div className="page-summary-container__summary-text">
                                <h2>Search</h2>
                                <p>On this page, you can search for drink recipes by name, alcoholic/non-alcoholic, glass type, and other drink attributes.</p>
                            </div>
                        </div>
                    </Col>
                    <Col sm="12">
                        <div className="search-container">
                            <div className="search-container__search-box">
                                <MagnifyingGlass />
                                <input type="text" />
                            </div>
                            <div className="search-container__search-attributes">
                                <ul>
                                    <li>Alcoholic</li>
                                    <li>Non-Alcoholic</li>
                                    <li>Glasstype</li>
                                </ul>
                            </div>
                            <div className="search-container__search-button">
                                <input type="button" value="Search" />
                                <MagnifyingGlass />
                            </div>
                        </div>
                    </Col>
                </Row>
            </div >
        );
    }
}
