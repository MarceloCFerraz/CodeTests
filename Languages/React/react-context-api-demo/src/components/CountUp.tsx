import { AppContext } from "@/context_providers/contexts/AppContext";
import { useContext } from "react";

export function CountUp() {
	const { count, setCount } = useContext(AppContext);

	function increaseCount() {
		setCount(count + 1);
	}

	return (
		<button
			className={
				"align-middle max-w-[250px] w-full p-2 rounded-sm bg-accent text-accent-foreground"
			}
			type="button"
			onClick={increaseCount}
		>
			Increase Count
		</button>
	);
}
