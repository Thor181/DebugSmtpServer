import React, { PropsWithChildren } from 'react'
import './list.css'

type Props = PropsWithChildren & {
    className?: string
}

const List = (props: Props) => {
    return (
        <div className={'list' + (props.className ? ' ' + props.className : '')}>
            {props.children}
        </div>
    )
}

export default List