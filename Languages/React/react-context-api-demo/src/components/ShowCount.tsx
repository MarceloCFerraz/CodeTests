import { AppContext } from "@/context_providers/contexts/AppContext";
import { useContextSelector } from "use-context-selector";

export function ShowCount() {
	const count = useContextSelector(AppContext, (ctx) => {
		return ctx.count;
	});

	return (
		<p className="mt-2.5">
			Count is <code className="bg-accent text-balance p-2">{count}</code>
		</p>
	);
}
