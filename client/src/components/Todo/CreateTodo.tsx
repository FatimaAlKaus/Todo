import * as React from "react";
import { Add } from "@mui/icons-material";
import { Box, TextField, Button } from "@mui/material";
interface CreateTodoProps {
    onCreate: (text: string) => void;
}
export const CreateTodo: React.FC<CreateTodoProps> = ({ onCreate }) => {
    const [text, setText] = React.useState<string>("");
    const [error, setError] = React.useState<boolean>(false);
    const onAdd = React.useCallback(() => {
        if (text) {
            onCreate(text);
            setText("");
        } else {
            setError(true);
        }
    }, [text, onCreate]);
    console.log("createTodo");
    return (
        <Box sx={{ display: "flex", margin: 5 }}>
            <TextField
                error={error}
                value={text}
                onKeyDown={(e) => {
                    if (e.key === "Enter") {
                        onAdd();
                    }
                }}
                onChange={(e) => {
                    setText(e.target.value);
                    setError(false);
                }}
            />
            <Button onClick={onAdd} variant="contained">
                <Add />
            </Button>
        </Box>
    );
};
