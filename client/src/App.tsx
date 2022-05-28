import { Add } from "@mui/icons-material";
import { Box, Button, TextField, Typography, useTheme } from "@mui/material";
import React, { useCallback, useEffect, useMemo, useState } from "react";
import { create, getAll, remove } from "./api/todo";
import "./App.css";
import { CreateTodo } from "./components/Todo/CreateTodo";
import { Todo } from "./components/Todo/Todo";
import { Todo as todo } from "./model/todo";

function App() {
    const [todos, setTodos] = useState<todo[]>([]);
    const [isFetching, setIsFetching] = useState(false);
    const theme = useTheme();
    const createTodo = useCallback(
        async (text: string) => {
            if (isFetching) return;
            setIsFetching(true);
            await create({ body: text });
            setIsFetching(false);
        },
        [isFetching]
    );
    const deleteTodo = useCallback(
        async (id: number) => {
            if (isFetching) return;
            // update state
            setIsFetching(true);
            // send the actual request
            await remove(id);
            // once the request is sent, update state again
            setIsFetching(false);
        },
        [isFetching]
    );
    useEffect(() => {
        (async () => {
            const todos: todo[] = await getAll();
            setTodos(todos.reverse());
        })();
    }, [deleteTodo, createTodo]);
    console.log("app");
    return (
        <div className="App">
            <Box
                sx={{
                    display: "flex",
                    flexDirection: "column",
                    justifyContent: "center",
                    alignItems: "center",
                }}
            >
                <CreateTodo onCreate={createTodo} />
                <Box
                    visibility={todos.length === 0 ? "hidden" : "visible"}
                    className="Todos"
                    sx={{
                        height: 545,
                        overflowY: "scroll",
                        border: "solid",
                        borderColor: theme.palette.primary.main,
                    }}
                >
                    {todos.map((x) => (
                        <Todo
                            key={x.id}
                            todo={x}
                            onDelete={() => deleteTodo(x.id)}
                        />
                    ))}
                </Box>
                <Typography>{todos.length}</Typography>
            </Box>
        </div>
    );
}

export default App;
