import React, { useCallback, useEffect, useState } from 'react'
import { Avatar, Button, IconButton, List, ListItem, ListItemAvatar, ListItemButton, ListItemText } from '@mui/material'
import MailIcon from '@mui/icons-material/Mail';
import DeleteIcon from '@mui/icons-material/Delete';
import IMailShortInfo from '../../models/mailShortInfo';
import * as signalR from '../../signalr/signalrConnection'
import './mailsList.css'

interface IProps {
}

const MailsList = () => {

    const [mails, setMails] = useState<IMailShortInfo[]>([]);

    const onReceiveMails = useCallback((mailsInfo: IMailShortInfo[]) => {

        setMails([mailsInfo[0]])
    }, []);

    useEffect(() => {
        signalR.subscribe('ReceiveMails', onReceiveMails);

        return () => signalR.unsubscribe('ReceiveMails', onReceiveMails);

    }, [])

    return (
        <List >
            {mails.map(x =>
                <>
                    <ListItem className='mails-list__item' onClick={(e) => console.log(x)}>
                        <ListItemText primary={x.subject} secondary={x.body} />
                        <IconButton>
                            <DeleteIcon />
                        </IconButton>
                    </ListItem>
                </>
            )}
        </List>
    )
}

export default MailsList