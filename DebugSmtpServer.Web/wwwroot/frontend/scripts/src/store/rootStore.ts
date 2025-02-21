import { combineReducers, configureStore } from "@reduxjs/toolkit";
import selectedMailSlice from "./slices/selectedMailSlice";
import { useDispatch, useSelector } from "react-redux";


const rootReducer = combineReducers({
    selectedMail: selectedMailSlice.reducer
});

const rootStore = configureStore({
    reducer: rootReducer
});

export type RootState = ReturnType<typeof rootStore.getState>
export type AppDispatch = typeof rootStore.dispatch;

export const useAppDispatch = useDispatch.withTypes<AppDispatch>();
export const useAppSelector = useSelector.withTypes<RootState>();

export default rootStore;
