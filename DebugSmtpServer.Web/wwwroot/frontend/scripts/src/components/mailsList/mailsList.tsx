import React, { useCallback, useEffect, useState } from 'react'
import { Avatar, Button, IconButton, List, ListItem, ListItemAvatar, ListItemButton, ListItemText } from '@mui/material'
import MailIcon from '@mui/icons-material/Mail';
import DeleteIcon from '@mui/icons-material/Delete';
import IMailShortInfo from '../../models/mailShortInfo';
import * as signalR from '../../signalr/signalrConnection'
import './mailsList.css'
import { useAppDispatch } from '../../store/rootStore';
import { selectMail } from '../../store/slices/selectedMailSlice';

interface IProps {
}

const stubMail: IMailShortInfo = { body: 'Тело письма <b>жирный</b>. <i>Курсив</i>', subject: 'Тема письма' }
const stubArray = [stubMail, stubMail, stubMail,stubMail,stubMail,stubMail,stubMail,stubMail,stubMail,stubMail,stubMail,stubMail,stubMail,stubMail,stubMail,stubMail,stubMail,];

const MailsList = () => {
    const dispatch = useAppDispatch();
    const [mails, setMails] = useState<IMailShortInfo[]>(stubArray);

    const onReceiveMails = useCallback((mailsInfo: IMailShortInfo[]) => {
        setMails([...mails, mailsInfo[0]])
    }, [mails]);

    useEffect(() => {
        signalR.subscribe('ReceiveMails', onReceiveMails);

        return () => signalR.unsubscribe('ReceiveMails', onReceiveMails);

    }, [onReceiveMails])

    return <>
        <List className='mails-list'>
            {mails.map((x, i) =>
                <ListItem key={'ListItem' + i} className='mails-list__item' onClick={(e) => dispatch(selectMail(x))}>
                    <ListItemText primary={x.subject} secondary={x.body} />
                    <IconButton>
                        <DeleteIcon />
                    </IconButton>
                </ListItem>
            )}
        </List>
    </>




}

export default MailsList