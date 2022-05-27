import { Delete } from "@mui/icons-material";
import { TextField, Box, Button } from "@mui/material";
import * as React from "react";

interface TodoProps {
    text?: string;
    onDelete: () => void;
}
export const Todo: React.FC<TodoProps> = ({ text, onDelete }) => {
    const [content, setContent] = React.useState<string>(text || "");
    console.log("change");
    return (
        <Box sx={{ display: "flex" }}>
            <TextField
                value={content}
                onChange={(e) => {
                    setContent(e.target.value);
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
