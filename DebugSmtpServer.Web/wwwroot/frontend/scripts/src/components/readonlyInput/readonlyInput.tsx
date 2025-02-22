import React, { useId } from 'react'
import './readonlyInput.css'
type Props = {
    label?: string,
    value: string
}

const ReadonlyInput = (props: Props) => {

    const id = useId();

    return (
        <div className='readonly-input'>
            {props.label !== null
                ? <><label htmlFor={id}>{props.label}</label> <span style={{width: 10}}></span></>
                : <></>}
            <input id={id} className='readonly-input__input' value={props.value} />
        </div>
    )
}

export default ReadonlyInput;