import React from "react";
import './view.css'
import { useAppSelector } from "../../store/rootStore";
import { currentMail, SelectedMail } from "../../store/slices/selectedMailSlice";
import ReadonlyInput from "../readonlyInput/readonlyInput";
import MailSvg from  '../../../public/mail.svg'

type Props = {

}

const View: React.FC<Props> = (props: Props) => {

    const currentSelectedMail: SelectedMail = useAppSelector(currentMail)

    return <>
        <div className="view">
            {currentSelectedMail.mail === null ?
                <ViewMailDummy></ViewMailDummy>
                : <>
                    <div className="view__subject text-overflow" title={currentSelectedMail.mail.subject}>
                        {currentSelectedMail.mail.subject}
                    </div>
                    <div className="view__head">
                        <div style={{ display: "flex", flexDirection: "column", gap: 2 }}>
                            <ReadonlyInput value={currentSelectedMail.mail.from} label="От:" />
                            <ReadonlyInput value={currentSelectedMail.mail.to.join("; ")} label="Кому:" />
                        </div>
                    </div>

                    <div className="view__body">
                        <div dangerouslySetInnerHTML={{ __html: currentSelectedMail.mail.body }}>

                        </div>
                    </div>
                </>
            }

        </div>
    </>;
}

export default View;

const ViewMailDummy = () => {
    return <div style={{display: "flex", flexDirection: 'column', justifyContent: 'center', alignItems: 'center', width: '100%', height: '100%'}}>
        <h1 style={{color:'gray', marginBottom: 0}}>Выберите письмо</h1>
        <img src={MailSvg} width={80} height={80}/>
    </div>;
}