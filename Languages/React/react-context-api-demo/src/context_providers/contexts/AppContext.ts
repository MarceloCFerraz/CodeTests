import type { Dispatch, SetStateAction } from "react";
import { createContext } from "use-context-selector";

export type AppContextType = {
	count: number;
	setCount: Dispatch<SetStateAction<number>>;
	doSomethingElse: () => void;
};

const initialState: AppContextType = {
	count: 0,
	setCount: () => {},
	doSomethingElse: () => {},
};

export const AppContext = createContext<AppContextType>(initialState);
