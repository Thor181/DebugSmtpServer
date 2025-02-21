import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import IMailShortInfo from "../../models/mailShortInfo";
import { RootState } from "../rootStore";

const defaultValue: IMailShortInfo = { subject: '', body: '' };

const selectedMailSlice = createSlice({
    name: 'selectedMail',
    initialState: defaultValue,
    reducers: {
        selectMail: (state, action: PayloadAction<IMailShortInfo>) => {
            return action.payload;
        }
    },
    selectors: {
        currentMail: (state) => state
    }
});

export const { currentMail } = selectedMailSlice.getSelectors((root: RootState) => root.selectedMail);
export const { selectMail } = selectedMailSlice.actions;

export default selectedMailSlice;
 