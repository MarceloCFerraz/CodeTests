import { AppContext } from "@/context_providers/contexts/AppContext";
import { useContextSelector } from "use-context-selector";

export function AnotherComponent() {
	const doSomethingElse = useContextSelector(
		AppContext,
		(ctx) => ctx.doSomethingElse,
	);

	doSomethingElse();

	return (
		<>
			I definitely don't need count, so i'll call <code>doSomethingElse</code>
		</>
	);
}
