import { BrowserRouter, Route, Routes } from "react-router";
import "./App.css";
import { Admin } from "./components/admin/Admin";
import { AnotherAdminPage } from "./components/admin/AnotherAdminPage";
import { AnotherPage } from "./components/home/AnotherPage";
import { Home } from "./components/home/Home";
import { AdminLayout } from "./layouts/AdminLayout";
import { HeaderLayout } from "./layouts/MainLayout";

export function App() {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<HeaderLayout />}>
                        {" "}
                        {/* this is the parent/global component */}
                        {/* all components declared inside any layout component are their children */}
                        <Route path="/" element={<Home />} />
                        <Route path="/test" element={<AnotherPage />} />
                    </Route>
                    <Route path="/admin" element={<AdminLayout />}>
                        {" "}
                        {/* this is the parent/global component */}
                        {/* all components declared inside any layout component are their children */}
                        <Route path="/admin" element={<Admin />} />
                        <Route path="/admin/test" element={<AnotherAdminPage />} />
                    </Route>
                </Routes>
            </BrowserRouter>
        </>
    );
}
