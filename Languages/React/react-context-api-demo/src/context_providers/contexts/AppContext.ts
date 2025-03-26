import { createContext } from "use-context-selector";

export type AppContextType = {
	count: number;
	increaseCount: () => Promise<void>;
	doSomethingElse: () => void;
};

const initialState: AppContextType = {
	count: 0,
	increaseCount: async () => {},
	doSomethingElse: () => {},
};

export const AppContext = createContext<AppContextType>(initialState);
