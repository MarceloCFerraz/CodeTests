import { AppContext } from "@/context_providers/contexts/AppContext";
import { useContext } from "react";

export function ShowCount() {
	const { count } = useContext(AppContext);
	return (
		<p className="mt-2.5">
			Count is <code className="bg-accent text-balance p-2">{count}</code>
		</p>
	);
}
