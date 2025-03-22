import { Logos } from "../Logos";
import { Nav } from "../Nav";

export function Header() {
    return (
        <div>
            <Logos/>
            <h1>This is your /home header</h1>
            <Nav />
        </div>
    );
}
