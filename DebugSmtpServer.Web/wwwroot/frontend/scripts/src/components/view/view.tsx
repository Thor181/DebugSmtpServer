import React from "react";
import './view.css'
import { useAppSelector } from "../../store/rootStore";
import { currentMail } from "../../store/slices/selectedMailSlice";
import { InputAdornment, TextField } from "@mui/material";
import { AccountCircle } from "@mui/icons-material";

type Props = {

}

const View: React.FC<Props> = (props: Props) => {

    const currentSelectedMail = useAppSelector(currentMail)

    return <>
        <div className="view">
            <div className="view__subject">
                
                <div>
                <TextField
                    label="От"
                    slotProps={{
                        input: {
                            startAdornment: (
                                <InputAdornment position="start">
                                    <AccountCircle />
                                </InputAdornment>
                            ),
                        },
                    }}
                    variant="standard"
                />
                <TextField
                    label="Кому"
                    slotProps={{
                        input: {
                            startAdornment: (
                                <InputAdornment position="start">
                                    <AccountCircle />
                                </InputAdornment>
                            ),
                        },
                    }}
                    variant="standard"
                />
                </div>
                <TextField className="view__subject" label="Тема" variant="filled" value={currentSelectedMail.subject} />
            </div>
            <div className="view__body">
                <div dangerouslySetInnerHTML={{ __html: currentSelectedMail.body }}>

                </div>
            </div>
        </div>
    </>;
}

export default View;