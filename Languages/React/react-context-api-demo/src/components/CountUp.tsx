import {
	AppContext,
	type AppContextType,
} from "@/context_providers/contexts/AppContext";
import { useContextSelector } from "use-context-selector";

export function CountUp() {
	const { count, setCount } = useContextSelector(
		AppContext,
		(ctx: AppContextType) => {
			return { ...ctx };
		},
	);

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
