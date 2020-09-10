import React, { Component } from 'react';
import axiosInstance from '../axios-instance';
import Input from './UI/Input/Input';
import VehicleProperties from './UI/VehicleProperties/VehicleProperties';

import Button from 'react-bootstrap/Button'
import Container from "react-bootstrap/Container";
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import Form from 'react-bootstrap/Form'
import Alert from 'react-bootstrap/Alert'

export class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {
      vehicleTypes: [],
      selectedType: '',
      propertyValues: {
      },
      alertMessage: '',
      alertType: ''
    };
  }

  componentDidMount() {
    axiosInstance.get('/vehicletype')
        .then(
          res => {
            const vehicleTypes = []
            res.data.forEach(type => vehicleTypes.push(type));
            this.setState({vehicleTypes: vehicleTypes})
            console.log(this.state)
          }
        )
        .catch(err => {
          console.log(err)
        });
  }

  selectionChangeHandler = (event) => {
    console.log(event.target.value);
    this.setState({selectedType: event.target.value}, () => {
      console.log(this.state);
    })
  }

  createHandler = (event) => {
      event.preventDefault();
      const data = {
          VehicleType: this.state.selectedType,
          ...this.state.propertyValues
      }
      axiosInstance.post('vehiclemanagement/create-vehicle', data)
          .then(response => {
              this.setState({
                  alertMessage: 'Success',
                  alertType: 'success'
              })
          })
          .catch(err => {
              console.log(err);
              this.setState({
                  alertMessage: 'Failed',
                  alertType: 'danger'
              })
          })
  }

  propertyChangedHandler = (event, identifier) => {
      const newPropertyValues = {...this.state.propertyValues};
      newPropertyValues[identifier] = event.target.value;
      this.setState({propertyValues: newPropertyValues}, () => {
          console.log(this.state);
      })
  }

  render () {
    return (
        <Container fluid="md">
            <Row>
                <Col>
                    <Form onSubmit={this.createHandler}>
                        <Input inputtype="select" label="Types" vehicleTypes={this.state.vehicleTypes} selectionChangeHandler={this.selectionChangeHandler}/>
                        <VehicleProperties
                            selectedType={this.state.selectedType}
                            vehicleTypes={this.state.vehicleTypes}
                            propertyValues={this.state.propertyValues}
                            propertyChangedHandler={this.propertyChangedHandler}/>
                        <Button variant="primary" type="submit" disabled={this.state.selectedType === ''}>
                            Create
                        </Button>
                    </Form>
                </Col>
            </Row>
            <Row>
                <Col>
                    <p/>
                    <Alert variant={this.state.alertType}>
                        {this.state.alertMessage}
                    </Alert>
                </Col>
            </Row>
        </Container>
    );
  }
}
