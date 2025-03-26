import "./App.css";
import { CountUp } from "./components/CountUp";
import { ShowCount } from "./components/ShowCount";
import { AppContextProvider } from "@/context_providers/providers/AppContextProvider";

export function App() {
	return (
		<AppContextProvider>
			<h1 className="text-4xl">
				Passing <code>count</code> to children via Context API
			</h1>
			<h4 className="text-xl">
				Also passing the theme to all components via context
			</h4>
			<div className="card">
				<CountUp />
				<ShowCount />
			</div>
		</AppContextProvider>
	);
}
