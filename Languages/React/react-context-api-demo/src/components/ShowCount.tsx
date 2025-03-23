import { useContext } from "react";
import { AppContext } from "../App";

export function ShowCount() {
	const { count } = useContext(AppContext);
	return (
		<p className="mt-2.5">
			Count is <code className="bg-accent text-balance p-2">{count}</code>
		</p>
	);
}
