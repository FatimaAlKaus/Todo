import { Delete } from "@mui/icons-material";
import { TextField, Box, Button } from "@mui/material";
import * as React from "react";
import { update } from "../../api/todo";
import { Todo as Model } from "../../model/todo";

interface TodoProps {
    todo: Model;
    onDelete: () => void;
}
export const Todo: React.FC<TodoProps> = ({ todo, onDelete }) => {
    const [content, setContent] = React.useState<string>(todo.body || "");
    console.log("change");
    return (
        <Box sx={{ display: "flex" }}>
            <TextField
                value={content}
                onChange={(e) => {
                    setContent(e.target.value);
                    if (!e.target.value) {
                        onDelete();
                    } else {
                        update({ body: e.target.value, id: todo.id });
                    }
                }}
            />
            <Button
                onClick={onDelete}
                color="error"
                sx={{ marginLeft: 0.5 }}
                variant="contained"
            >
                <Delete />
            </Button>
        </Box>
    );
};
