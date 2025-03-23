import {
	type Dispatch,
	type SetStateAction,
	createContext,
	useState,
} from "react";
import "./App.css";
import { CountUp } from "./components/CountUp";
import { ShowCount } from "./components/ShowCount";
import { ThemeModeToggle } from "./components/ThemeModeToggle";
import { ThemeProvider } from "./components/ThemeProvider";

export type AppContextType = {
	count: number;
	setCount: Dispatch<SetStateAction<number>>;
};
const initialState: AppContextType = {
	count: 0,
	setCount: () => {},
};

export const AppContext = createContext<AppContextType>(initialState);

export function App() {
	const [count, setCount] = useState(0);

	return (
		<ThemeProvider defaultTheme="system" storageKey="vite-ui-theme">
			<ThemeModeToggle />
			<AppContext.Provider value={{ count, setCount }}>
				<h1 className="text-4xl">
					Passing <code>count</code> to children via Context API
				</h1>
				<h4 className="text-xl">Also passing the theme to all components via context</h4>
				<div className="card">
					<CountUp />
					<ShowCount />
				</div>
			</AppContext.Provider>
		</ThemeProvider>
	);
}
