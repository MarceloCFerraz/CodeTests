import { AddTodo } from "./components/AddTodo";
import { ListTodos } from "./components/ListTodos";

export type Todo = {
	id: number;
	task: string;
	completed: boolean;
};

export function App() {
	return (
		<div>
			<h1>
				A stupid TODOs app to learn React Query <pre>:)</pre>
			</h1>
			<ListTodos />
			<AddTodo />
		</div>
	);
}
