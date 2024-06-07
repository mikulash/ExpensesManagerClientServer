import './App.css';
import {Button} from "./components/ui/button.tsx";
import {Link} from "react-router-dom";

function App() {
    return (
        <div>
            <h1 id="tabelLabel">Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            <div> heelo world</div>
            <Button><Link to={"login"}>login</Link></Button>
        </div>
    );
}

export default App;
