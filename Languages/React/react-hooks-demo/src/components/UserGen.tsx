import { useEffect, useState } from "react";
import type { NewUserResponse } from "../models/NewUserResponse";
import type { User } from "../models/User";

export function UserGen() {
	const [users, setUsers] = useState<User[]>([]);

	useEffect(() => {
		GenNewUsers();
	}, []);

	async function GenNewUsers() {
		const response = await fetch("https://randomuser.me/api/");
		const data = (await response.json()) as NewUserResponse;

		console.log(data);

		setUsers(data.results);
	}

	return (
		<div className="card">
			<h2>
				Calling an API with <code>useEffect</code>
			</h2>
			{users.map((u) => {
				return (
					<div key={`${u.id}-div`}>
						<p>
							{u.name.first} {u.name.last} ({u.gender})
						</p>
						<p>{u.email}</p>
					</div>
				);
			})}
		</div>
	);
}
