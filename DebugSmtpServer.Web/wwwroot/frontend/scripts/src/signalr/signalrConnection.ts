import { HubConnectionBuilder } from "@microsoft/signalr";
import IMailShortInfo from "../models/mailShortInfo";

const signalRConnection = new HubConnectionBuilder().withUrl('/mailhub').withAutomaticReconnect().build();

export const start = () => signalRConnection.start();

type method = "ReceiveMails";

export const subscribe = (methodName: method, callback: (...args: any[]) => any) => {
    signalRConnection.on(methodName, callback);
}

export const unsubscribe = (methodName: method, callback: (...args: any[]) => any) => {
    signalRConnection.off(methodName, callback);
}

export const getMails = () => {
    return signalRConnection.invoke<IMailShortInfo[]>("GetMails");
}

// export const sendMessageToServer = (message: ISendMessage) => {
//     const json = JSON.stringify(message);
//     signalRConnection.invoke("Send", json);
// }

// export const sendMemberingActionToServer = async (data: IMemberingInfo): Promise<IPayloadResult<IUser[]>> => {
//     return signalRConnection.invoke("SendMemberingAction", data);
// }