import React, { useCallback, useEffect, useState } from 'react'
import IMailShortInfo from '../../models/mailShortInfo';
import * as signalR from '../../signalr/signalrConnection'
import './mailsList.css'
import { useAppDispatch } from '../../store/rootStore';
import { selectMail } from '../../store/slices/selectedMailSlice';
import List from '../list/list';
import ListEntry from '../listEntry/listEntry';
import MailListEntry from '../mailListEntry/mailListEntry';
import mailStub from '../../utils/mailStub';

interface IProps {
}

const stubArray = [mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,mailStub,];

const MailsList = () => {
    const dispatch = useAppDispatch();
    const [mails, setMails] = useState<IMailShortInfo[]>(stubArray);

    const onReceiveMails = useCallback((mailsInfo: IMailShortInfo[]) => {
        setMails(e => [...e, mailsInfo[0]])
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