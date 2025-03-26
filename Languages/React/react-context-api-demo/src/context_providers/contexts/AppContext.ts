import { type Dispatch, type SetStateAction, createContext } from "react";

export type AppContextType = {
	count: number;
	setCount: Dispatch<SetStateAction<number>>;
};
const initialState: AppContextType = {
	count: 0,
	setCount: () => {},
};

export const AppContext = createContext<AppContextType>(initialState);
