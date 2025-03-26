import { type ReactNode, memo } from "react";

// this component will re-render every time "count" from its parent changes
// to prevent this, we can use "memo"
// export function Fruit({ fruit }: { fruit: string }): ReactNode {
// 	return <p>here's a {fruit}!</p>;
// }

function FruitComponent({ fruit }: { fruit: string }): ReactNode {
	return <p>here's a {fruit}!</p>;
}

export const Fruit = memo(FruitComponent);

// what memo does is compare props and hooks used by this component coming from parent components
// and only allow a refresh if any of them change. We can also pass a comparison function to define
// when to refresh:
//      export const Fruit = memo(FruitComponent, comparisonFunc)
//      function comparisonFunc(prev, next): boolean {
//          return prev !== next;
//      }
// without memo, react does this:
// 1. generate new HTML for component
// 2. compare new HTML with old
// 3. IF new is different (reference count too), re-render
// memo basically adds a step 0 that is more costly than default behavior, for that reason, it
// should be used only for components with large HTML or complex calculus, where generation would be
// more expensive than the comparison and for cases where we don't want the component to re-render for
// a specific reason. E.g. a prop that doesn't matter to the component changed
