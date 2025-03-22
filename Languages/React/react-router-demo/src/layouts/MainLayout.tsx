import { Outlet } from "react-router";
import { Header } from "../components/home/Header";

export function HeaderLayout() {
    return (
        <div>
            <Header />
            <Outlet />
        </div>
    );
}
