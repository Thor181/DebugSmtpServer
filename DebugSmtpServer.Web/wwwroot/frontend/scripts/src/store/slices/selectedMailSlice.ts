import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import IMailShortInfo from "../../models/mailShortInfo";
import { RootState } from "../rootStore";

export type SelectedMail = { mail: IMailShortInfo | null }
const defaultValue: SelectedMail = { mail: null };

const selectedMailSlice = createSlice({
    name: 'selectedMail',
    initialState: defaultValue,
    reducers: {
        selectMail: (state: SelectedMail, action: PayloadAction<IMailShortInfo>) => {

            state.mail = action.payload;
        }
    },
    selectors: {
        currentMail: (state) => state
    }
});

export const { currentMail } = selectedMailSlice.getSelectors((root: RootState) => root.selectedMail);
export const { selectMail } = selectedMailSlice.actions;

export default selectedMailSlice;
