const url = "http://localhost:5001/v1/todo/";

export const create = async (input: CreateTodoRequest) => {
    await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(input),
    });
};
export const update = async (input: UpdateTodoRequest) => {
    await fetch(url, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(input),
    });
};

export const get = async (id: number) => {
    const response = await fetch(url + id.toString(), {
        method: "GET",
    });
    return await response.json();
};

export const getAll = async () => {
    const response = await fetch(url, {
        method: "GET",
    });
    return await response.json();
};

export const remove = async (id: number) => {
    await fetch(url + "?id=" + id.toString(), {
        method: "DELETE",
    });
};

interface CreateTodoRequest {
    body: string;
}
interface UpdateTodoRequest {
    id: number;
    body: string;
}
