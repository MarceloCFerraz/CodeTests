import { Outlet } from "react-router";
import { AdminHeader } from "../components/admin/AdminHeader";

export function AdminLayout() {
	return (
		<div>
			<AdminHeader />
			<Outlet />
		</div>
	);
}
