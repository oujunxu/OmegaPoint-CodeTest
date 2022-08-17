import React, {Component} from "react";
import {Navbar, Nav, NavDropdown, Form, FormControl, Button, Container, useLocation} from 'react-bootstrap';
import "../../Resources/Css/site.css";
import ProductList from '../ProductList/ProductList';
import Home from '../Home/Home';

import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link,
    Redirect
  } from "react-router-dom";
import Product from "../Product/Product";
  

export default class NavComp extends Component{
    render() {
        return (
          <Router>
            <div>
              <Navbar bg="text-white" expand="lg">
                <Container>
                  <Navbar.Toggle aria-controls="basic-navbar-nav" />
                  <Navbar.Collapse id="basic-navbar-nav">
                    <a href="../Home"><img src="Resources/Images/storeStore.png" width="150px" height="80px"/></a>
                    <Nav className="me-auto">
                      <Nav.Link
                        as={Link}
                        to={"../Home"}
                        className="text-white"
                      >
                        Home
                      </Nav.Link>
                      <Nav.Link
                        as={Link}
                        to={"../ProductList"}
                        className="text-white"
                      >
                        ProductList
                      </Nav.Link>
                    </Nav>
                  </Navbar.Collapse>
                </Container>
              </Navbar>
            </div>
            <div>
            <Switch>
                /* This below is used for redirection to home */ 
                <Route
                  exact
                  path="/"
                  render={() => {
                    return <Redirect to="/home" />;
                  }}
                />
                <Route path="/ProductList">
                  <ProductList />
                </Route>
                <Route path="/Home">
                  <Home />
                </Route>
                <Route render={(props)=><Product {...props}/>} path="/Product/:id" />
          
              </Switch>
            </div>
          </Router>
        );
    }
}
