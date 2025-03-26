import { AppContextProvider } from "@/context_providers/providers/AppContextProvider";
import "./App.css";
import { AnotherComponent } from "./components/AnotherComponent";
import { CountUp } from "./components/CountUp";
import { ShowCount } from "./components/ShowCount";

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
				<AnotherComponent />
			</div>
		</AppContextProvider>
	);
}
