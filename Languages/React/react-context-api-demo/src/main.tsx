import { ThemeContextProvider } from "@/context_providers/providers/ThemeContextProvider";
import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { App } from "./App.tsx";
import { ThemeModeToggle } from "./components/ThemeModeToggle.tsx";
import "./index.css";

createRoot(document.getElementById("root")!).render(
	<StrictMode>
		<ThemeContextProvider defaultTheme="system" storageKey="vite-ui-theme">
			<ThemeModeToggle />
			<App />
		</ThemeContextProvider>
	</StrictMode>,
);
