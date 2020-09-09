import React from 'react';

import classes from '../../../custom.css';

const input = (props) => {
    let inputElement = null;

    switch (props.inputtype) {
        case ('input'):
            inputElement = <input
                className="InputElement"
                value={props.value}
                onChange={(event) => props.inputChangeHandler(event, props.identifier)}
                {...props}/>
            break;
        case ('select'):
            const options = ['']
            props.vehicleTypes.forEach(type => options.push(type.name));

            inputElement = <select className="InputElement" value={props.value} onChange={(event) => props.selectionChangeHandler(event)}>
                {
                    options.map(option => (
                        <option key={option} value={option}>{option}</option>
                    ))
                }
            </select>
            break;
        default:
            inputElement = <input className="InputElement" {...props}/>
    }

    return (
        <div className={classes.Input}>
            <label className={classes.Label}>{props.label}</label>
            {inputElement}
        </div>
        );
};

export default input;