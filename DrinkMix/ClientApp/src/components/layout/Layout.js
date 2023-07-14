import React, { Component } from 'react';
import { Container, Row, Col } from 'reactstrap';
import { NavMenu } from '../nav-menu/NavMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
        <div>
            <Container tag="main">
                <Row>
                    <Col sm="12" md="2">
                        <NavMenu />
                    </Col>
                    <Col sm="12" md="10">
                        {this.props.children}
                    </Col>
                </Row>
        </Container>
      </div>
    );
  }
}
