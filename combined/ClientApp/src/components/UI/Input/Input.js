import React from 'react';

import Form from 'react-bootstrap/Form'

const input = (props) => {
    let inputElement = null;

    switch (props.inputtype) {
        case ('input'):
            inputElement = (
                <Form.Control as="input"
                              value={props.value}
                              onChange={(event) => props.inputChangeHandler(event, props.identifier)}
                              placeholder={props.label}
                              {...props}>
                </Form.Control>
            )
            break;
        case ('select'):
            const options = ['']
            props.vehicleTypes.forEach(type => options.push(type.name));

            inputElement = (
                <Form.Control as="select" placeholder={props.label} value={props.value} onChange={(event) => props.selectionChangeHandler(event)}>
                    {
                        options.map(option => (
                            <option key={option}>{option}</option>
                        ))
                    }
                </Form.Control>

            );
            break;
        default:
            inputElement = <input className="InputElement" {...props}/>
    }

    return (
        <Form.Group controlId={props.label}>
            <Form.Label>{props.label}</Form.Label>
            {inputElement}
        </Form.Group>
        );
};

export default input;