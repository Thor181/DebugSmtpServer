import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import IMailShortInfo from "../../models/mailShortInfo";
import { RootState } from "../rootStore";
import mailStub from "../../utils/mailStub";

const defaultValue: IMailShortInfo = {...mailStub}

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
 