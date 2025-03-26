import { Fruit } from "@/components/Fruit";
import { AppContext } from "@/context_providers/contexts/AppContext";
import { useContextSelector } from "use-context-selector";

export function ShowCount() {
	const count = useContextSelector(AppContext, (ctx) => {
		return ctx.count;
	});

	// setting fruit as a const here to illustrate a scenario where a prop doesn't change much
	const fruit = "banana";
	// const [fruit, setFruit] = useState<string>("");

	// const updateFruit = (anotherFruit:string) => {
	// 	setFruit(anotherFruit)
	// }
	// another option is to use useMemo to avoid the variable from being created again every time the
	// component renders. This will prevent unnecessary and expensive (not this case) calculations
	// and rendering again all child components for no reason. useMemo has a function that returns
	// the value for the variable/const and a dependencies list for it to check and update only when that
	// specific dependency change
	// const fruit = useMemo(() => "banana", []);

	return (
		<div>
			<p className="mt-2.5">
				Count is <code className="bg-accent text-balance p-2">{count}</code>
			</p>
			<Fruit fruit={fruit} />
		</div>
	);
}
