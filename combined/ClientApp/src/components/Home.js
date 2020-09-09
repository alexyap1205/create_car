import React, { Component } from 'react';
import axiosInstance from '../axios-instance';
import Input from './UI/Input/Input';
import VehicleProperties from './UI/VehicleProperties/VehicleProperties';

import classes from '../custom.css';

export class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {
      vehicleTypes: [],
      selectedType: '',
      propertyValues: {
      }
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
              console.log('posted');
          })
          .catch(err => {
              console.log(err);
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
        <form onSubmit={this.createHandler}>
          <Input inputtype="select" label="Types" vehicleTypes={this.state.vehicleTypes} selectionChangeHandler={this.selectionChangeHandler}/>
          <VehicleProperties
              selectedType={this.state.selectedType}
              vehicleTypes={this.state.vehicleTypes}
              propertyValues={this.state.propertyValues}
              propertyChangedHandler={this.propertyChangedHandler}/>
          <div>
              <button className="btn-primary" disabled={this.state.selectedType === ''}>CREATE</button>
          </div>
        </form>
    );
  }
}
