import React from "react";
import "./App.css";
import { Todo } from "./components/Todo/Todo";

function App() {
    return (
        <div className="App">
            <Todo text="hee" onDelete={() => {}} />
        </div>
    );
}

export default App;
