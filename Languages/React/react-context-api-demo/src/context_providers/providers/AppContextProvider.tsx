import { AppContext } from "@/context_providers/contexts/AppContext";
import { type ReactNode, useState } from "react";

interface AppProviderProps {
	children: ReactNode;
}

// react re-renders components on 3 occasions:
// 1. context/hooks changed
// 2. props changed
// 3. parent re-rendered
// if for some reason the context provider have to re-render, everything down the line will do the same.
// however, not everything need to re-render every time. For instance, if count changes, a component that
// depends only on doSomethingElse shouldn't have to re-render only because count changed, right?
// react's native Context api don't care for that. If count changes, everything changes. To avoid that
// we can use use-context-selector on AppContext.ts and in every file that uses it. What it'll do is
// basically observe only what the component depends on and avoid unnecessary refreshes due to context change
export function AppContextProvider({ children }: AppProviderProps) {
	const [count, setCount] = useState(0);

	const doSomethingElse = () => {
		console.log("I definitely don't need count");
	};

	return (
		<AppContext.Provider value={{ count, setCount, doSomethingElse }}>
			{children}
		</AppContext.Provider>
	);
}
