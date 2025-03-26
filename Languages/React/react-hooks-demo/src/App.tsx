import { useReducer, useState } from "react";
import "./App.css";
import { UserGen } from "./components/UserGen";

interface CountOperation {
	increment: number;
}

function App() {
	// useState defines a read-only variable which represents a specific
	// state and a function that should be used to update that state
	const [nums, setNums] = useState<number[]>([]);
	// useReducer is similar to useState and also returns two things, the difference
	// comes from the function that will always get the current state as the first param,
	// an action as the second param, and an initializer function for the initial value
	// as the third param. the action can be anything, but it is recommended to have it
	// as an object that contains some sort of "context" on how to update the current
	// state.
	// E.g.: action = {type: "add", value: 1} | action = {type: "decrease", value: 1}
	const [count, countDispatcher] = useReducer(
		(current: number, action: CountOperation) => {
			return current + action.increment;
		},
		0,
		(initialState) => {
			const valueFromLocalStorage = localStorage.getItem("myApp-object-key");

			if (valueFromLocalStorage) return Number(valueFromLocalStorage);

			return initialState;
		},
	);

	// useEffect executes once on the initial component render and every time any of its dependencies get updated
	// useEffect(() => {}, []); // this'll run only on the first component render (no dependencies)
	// useEffect(() => {}, [nums]); // this'll run on the first component render and any time nums are updated

	let sums = "[";

	if (nums.length === 0) sums += "]";

	console.log(sums);

	let sum = 0;
	for (const [i, n] of nums.entries()) {
		sum += n;
		sums += `${n}`;

		if (i + 1 >= nums.length) sums += `] = ${sum}`;
		else sums += " + ";
	}

	console.log(sums);

	function updateCounterByOne() {
		countDispatcher({ increment: 1 });

		setNums([...nums, 1]);
	}

	function updateCounterByTwo() {
		// this won't work:
		// setCount(count + 1)
		// setCount(count + 1)

		// why: https://react.dev/reference/react/useState#updating-state-based-on-the-previous-state
		// setCount(count + 1);
		// setCount((cur) => cur + 1);

		countDispatcher({ increment: 2 });

		// or simply setCount(count + 2) or setCount(cur => cur + 2)
		setNums([...nums, 2]);
	}

	return (
		<>
			<h1>Vite + React</h1>
			<div className="card">
				<h2>Current Count: {count}</h2>
				<button type="button" onClick={updateCounterByOne}>
					Update Once
				</button>
				<button type="button" onClick={updateCounterByTwo}>
					Update Twice
				</button>
			</div>
			<div className="card">
				<code>
					<span>sum: {sums}</span>
				</code>
			</div>
			{/* UserGen is an example of how useEffect can be used to call an api when rendering */}
			<UserGen />
		</>
	);
}

export default App;
