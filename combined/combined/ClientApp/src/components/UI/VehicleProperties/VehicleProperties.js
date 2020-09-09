import React from 'react';

import Input from '../Input/Input';

const vehicleProperties = (props) => {
    const inputs = [];

    if (props.selectedType !== ''){
        inputs.push(<Input inputtype="input" key="Make" label="Make"
                           placeholder="Make" identifier="Make"
                           inputChangeHandler={props.propertyChangedHandler}
                           value={props.propertyValues["Make"]}/>)
        inputs.push(<Input inputtype="input" key="Model" label="Model"
                           placeholder="Model" identifier="Model"
                           inputChangeHandler={props.propertyChangedHandler}
                           value={props.propertyValues["Model"]}/>)
        const vehicleType = props.vehicleTypes.find(type => type.name === props.selectedType);
        vehicleType.customProperties.map(property => {
            return inputs.push(<Input inputtype="input"
                                      key={property.Name}
                                      label={property.name}
                                      placeholder={property.name}
                                      identifier={property.name}
                                      inputChangeHandler={props.propertyChangedHandler}
                                      value={props.propertyValues[property.Name]}/>)
        });

    }

    return(
        <div>
            {inputs}
        </div>
    );
};

export default vehicleProperties;