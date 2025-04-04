import { NavLink } from "react-router";

export function Nav() {
	const links = [
		{
			path: "/",
			name: "Home",
		},
		{
			path: "/test",
			name: "Another Page",
		},
		{
			path: "/admin",
			name: "Admin Home",
		},
		{
			path: "/admin/test",
			name: "Another Admin Page",
		},
	];
	return (
		<nav>
			{links.map((l) => {
				return (
					<NavLink
						to={l.path}
						className={({ isActive }) =>
							(isActive ? "active" : "") + " navLink"
						}
					>
						{l.name}
					</NavLink>
				);
			})}
		</nav>
	);
}
