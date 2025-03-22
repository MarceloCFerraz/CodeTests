import { Logos } from "../Logos";
import { Nav } from "../Nav";

export function AdminHeader() {
    return (
        <div>
            <Logos />
            <h1>Now you're on /admin land</h1>
            <Nav />
        </div>
    );
}
