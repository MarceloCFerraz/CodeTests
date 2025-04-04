import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useState } from "react";
import { Todo } from "../App";

export function AddTodo() {
	const queryClient = useQueryClient();

	const initialState = {
		task: "",
		completed: false,
	} as Todo;
	const [newTodo, setNewTodo] = useState<Todo>(initialState);

	const mutateTodo = useMutation({
		mutationFn: async (todo: Todo) => {
			const response = await fetch("http://localhost:3001/todos", {
				method: "POST",
				headers: {
					"Content-Type": "application/json",
				},
				body: JSON.stringify(todo),
			});
			if (!response.ok) {
				throw new Error("Network response was not ok");
			}
			return response.json();
		},

		onMutate(variables) {
			// Cancel any outgoing refetches (so they don't overwrite our optimistic update)
			queryClient.cancelQueries({ queryKey: ["todos"] });

			// Snapshot the previous value
			const previousTodos = queryClient.getQueryData<Todo[]>(["todos"]);

			// Optimistically update to the new value
			queryClient.setQueryData<Todo[]>(["todos"], (old) => {
				return [
					...(old || []),
					{
						...variables,
						id: Math.random(),
					},
				];
			});

			// Return a context object with the snapshotted value
			return { previousTodos };
		},

		onError: (error, todo, context) => {
			// Rollback the optimistic update if the mutation fails
			console.error(
				`Error adding new Todo ${JSON.stringify(todo)}, rolling back to previous state`,
				error,
			);

			if (context?.previousTodos) {
				queryClient.setQueryData<Todo[]>(["todos"], context?.previousTodos);
			}
		},

		onSettled: () => {
			// refetch the todos query to get the latest data
			queryClient.invalidateQueries({ queryKey: ["todos"] });
		},
	});

	function updateTodoValue(e: React.ChangeEvent<HTMLInputElement>) {
		setNewTodo((state) => {
			return {
				...state,
				task: e.target.value,
			};
		});
	}

	async function handleAddTodo(event: React.FormEvent<HTMLFormElement>) {
		// await new Promise((resolve) => setTimeout(resolve, 1000));
		// event.preventDefault();
		// console.log(event.currentTarget);
		// const formData = new FormData(event.currentTarget);
		// const task = formData.get("task");
		// console.log(task);
		mutateTodo.mutate(newTodo);
	}

	return (
		<div>
			<form action="submit" onSubmit={handleAddTodo}>
				<input
					type="text"
					name="task"
					placeholder="Add a new todo"
					value={newTodo.task}
					onChange={updateTodoValue}
				/>

				<button type="submit">Add</button>
			</form>
		</div>
	);
}
