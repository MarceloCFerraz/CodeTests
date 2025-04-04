import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";

type Todo = {
	id: string;
	task: string;
	completed: boolean;
};

async function patchTodo(todo: Todo) {
	return await fetch(`http://localhost:3001/todos/${todo.id}`, {
		method: "PATCH",
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify(todo),
	});
}

export function ListTodos() {
	const queryClient = useQueryClient();
	const { data, isLoading, isError } = useQuery<Todo[]>({
		initialData: [],
		queryKey: ["todos"],
		queryFn: async () => {
			const response = await fetch("http://localhost:3001/todos");
			if (!response.ok) {
				throw new Error("Network response was not ok");
			}
			return response.json();
		},
	});

	const mutateTodo = useMutation({
		mutationFn: async (todo: Todo) => {
			const response = await patchTodo({ ...todo, completed: !todo.completed });

			if (!response.ok) {
				throw new Error("Network response was not ok");
			}

			return response.json();
		},

		onSettled: () => {
			queryClient.invalidateQueries({ queryKey: ["todos"] });
		},
	});

	if (isLoading) {
		return <div>Loading...</div>;
	}
	if (isError) {
		return <div>Error loading todos</div>;
	}

	async function handleMutateTodoCompleted(id: string): Promise<void> {
		const todo = data.find((todo) => todo.id === id);

		if (!todo) {
			throw new Error("Todo not found");
		}

		await mutateTodo.mutateAsync(todo!);
	}

	return (
		<ul>
			{data?.map((todo) => (
				<li key={todo.id}>
					<span>{todo.task}</span>
					<button onClick={() => handleMutateTodoCompleted(todo.id)}>
						{todo.completed ? "✔️" : "❌"}
					</button>
				</li>
			))}
		</ul>
	);
}
