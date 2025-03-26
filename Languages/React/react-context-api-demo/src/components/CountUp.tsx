import {
	AppContext,
	type AppContextType,
} from "@/context_providers/contexts/AppContext";
import { useContextSelector } from "use-context-selector";

export function CountUp() {
	const increaseCount = useContextSelector(
		AppContext,
		(ctx: AppContextType) => ctx.increaseCount,
	);

	return (
		<div className="block m-auto ">
			<button
				className={
					"align-middle my-5 max-w-[250px] w-full p-2 rounded-sm bg-accent text-accent-foreground"
				}
				type="button"
				onClick={increaseCount}
			>
				Increase Count
			</button>
		</div>
	);
}
