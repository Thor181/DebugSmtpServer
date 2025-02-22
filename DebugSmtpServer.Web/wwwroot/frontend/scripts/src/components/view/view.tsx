import React from "react";
import './view.css'
import { useAppSelector } from "../../store/rootStore";
import { currentMail } from "../../store/slices/selectedMailSlice";
import IMailShortInfo from "../../models/mailShortInfo";
import ReadonlyInput from "../readonlyInput/readonlyInput";

type Props = {

}

const View: React.FC<Props> = (props: Props) => {

    const currentSelectedMail: IMailShortInfo = useAppSelector(currentMail)

    return <>
        <div className="view">
            <div className="view__subject text-overflow" title={currentSelectedMail.subject}>
                {currentSelectedMail.subject}
            </div>
            <div className="view__head">
                <div style={{ display: "flex", flexDirection: "column", gap: 2 }}>
                    <ReadonlyInput value={currentSelectedMail.from} label="От:"/>
                    <ReadonlyInput value={currentSelectedMail.to.join("; ")} label="Кому:"/>
                </div>
            </div>

            <div className="view__body">
                <div dangerouslySetInnerHTML={{ __html: currentSelectedMail.body }}>

                </div>
            </div>
        </div>
    </>;
}

export default View;