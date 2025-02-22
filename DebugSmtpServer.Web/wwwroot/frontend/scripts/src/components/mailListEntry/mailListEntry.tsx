import React, { PropsWithChildren } from 'react'
import './mailListEntry.css'
import ListEntry from '../listEntry/listEntry'
import IMailShortInfo from '../../models/mailShortInfo'

type Props = PropsWithChildren & {
    mail: IMailShortInfo
    onClick?: (mail: IMailShortInfo) => void
}

const MailListEntry = (props: Props) => {
    return (
        <ListEntry>
            <div className='mail-list-entry' onClick={() => props.onClick && props.onClick(props.mail)}>
                <div className='mail-list-entry__left'>
                    <div className='mail-list-entry__from text-overflow' title={props.mail.from}>{props.mail.from}</div>
                    <div className='mail-list-entry__subject text-overflow' title={props.mail.subject}>{props.mail.subject}</div>
                </div>
                <div className='mail-list-entry__right' >
                    <div className='mail-list-entry__date-container'>
                        <div>
                            {props.mail.date.toLocaleDateString()}
                        </div>
                        <div style={{fontSize: '0.7em'}}>
                            {props.mail.date.toLocaleTimeString()}
                        </div>
                    </div>
                </div>
            </div>
        </ListEntry>
    )
}

export default MailListEntry