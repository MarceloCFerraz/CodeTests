import { type ReactNode, useState } from "react";
import { AppContext } from "@/context_providers/contexts/AppContext";

interface AppProviderProps {
	children: ReactNode;
}

export function AppContextProvider({ children }: AppProviderProps) {
	const [count, setCount] = useState(0);

	return (
		<AppContext.Provider value={{ count, setCount }}>
			{children}
		</AppContext.Provider>
	);
}
