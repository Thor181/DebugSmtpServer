import React, { PropsWithChildren } from 'react'
import './listEntry.css'
type Props = PropsWithChildren & {

}

const ListEntry = (props: Props) => {
    return (
        <div className='list-entry'>{props.children}</div>
    )
}

export default ListEntry