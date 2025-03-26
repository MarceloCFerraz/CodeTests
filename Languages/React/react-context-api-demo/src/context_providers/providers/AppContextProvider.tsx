import { AppContext } from "@/context_providers/contexts/AppContext";
import { type ReactNode, useCallback, useState } from "react";

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
// basically observe only what the component depends on and avoid unnecessary refreshes due to context change,
// though it won't prevent a re-render due to any of the other two reasons above (props or parent).
// to avoid a re-render
export function AppContextProvider({ children }: AppProviderProps) {
	const [count, setCount] = useState(0);

	// every time something on the context updates, everything gets rendered again.
	// to make a property from context update only when it has updated, use useCallback
	const doSomethingElse = useCallback(async () => {
		console.log("I definitely don't need count");
	}, []);

	// here we're saying this: unless setCount change, don't re-render components that
	// depend only on it: CountUp, AnotherComponent
	const increaseCount = useCallback(async () => {
		setCount((state) => state + 1);
	}, []);

	return (
		<AppContext.Provider value={{ count, increaseCount, doSomethingElse }}>
			{children}
		</AppContext.Provider>
	);
}
