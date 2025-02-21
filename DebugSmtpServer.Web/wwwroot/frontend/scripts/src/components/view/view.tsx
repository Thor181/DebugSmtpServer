import React from "react";
import './view.css'
import { useAppSelector } from "../../store/rootStore";
import { currentMail } from "../../store/slices/selectedMailSlice";
import { TextField } from "@mui/material";
type Props = {

}

const View: React.FC<Props> = (props: Props) => {

    const currentSelectedMail = useAppSelector(currentMail)

    return <>
        <div className="view">
            <div>
                <TextField  className="view__subject" label="Тема" variant="filled" value={currentSelectedMail.subject} />
            </div>
            <div style={{ height: '100%' }}>
                <div dangerouslySetInnerHTML={{__html: currentSelectedMail.body}}>
                    
                </div>
            </div>
        </div>
    </>;
}

export default View;