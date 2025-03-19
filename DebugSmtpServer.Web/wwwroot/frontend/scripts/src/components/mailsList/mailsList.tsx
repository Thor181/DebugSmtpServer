import React, { useCallback, useEffect, useState } from 'react'
import IMailShortInfo from '../../models/mailShortInfo';
import * as signalR from '../../signalr/signalrConnection'
import './mailsList.css'
import { useAppDispatch } from '../../store/rootStore';
import { selectMail } from '../../store/slices/selectedMailSlice';
import List from '../list/list';
import ListEntry from '../listEntry/listEntry';
import MailListEntry from '../mailListEntry/mailListEntry';

interface IProps {
}

const MailsList = () => {
    const dispatch = useAppDispatch();
    const [mails, setMails] = useState<IMailShortInfo[]>([]);

    React.useEffect(() => {
        signalR.getMails().then(x => {
            setMails(mails => [...x])
        });
    },[])

    const onReceiveMails = useCallback((mailsInfo: IMailShortInfo[]) => {
        setMails(e => [mailsInfo[0], ...e])
    }, []);

    useEffect(() => {
        signalR.subscribe('ReceiveMails', onReceiveMails);

        return () => signalR.unsubscribe('ReceiveMails', onReceiveMails);
    }, [])

   

    return <>
        <List >
            {mails.map((x,i) => <MailListEntry key={'maillistentry' + i} mail={x} onClick={(e) => dispatch(selectMail(e))}/>)}
        </List>
    </>
}

export default MailsList