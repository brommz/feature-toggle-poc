import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import { NavMenu } from './NavMenu';
//import { LaunchDarkly } from "react-launch-darkly";

export class Layout extends Component {
    displayName = Layout.name

    render() {
        //var key = '5bbef41363c55a38671bf6af';
        return (
            //<LaunchDarkly clientId={key} user={{ key: "user-poc-js" }}>
                <Grid fluid>
                    <Row>
                        <Col sm={3}>
                            <NavMenu />
                        </Col>
                        <Col sm={9}>
                            {this.props.children}
                        </Col>
                    </Row>
                </Grid>
            //</LaunchDarkly>
        );
    }
}
