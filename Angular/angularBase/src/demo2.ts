type Task = {
    id: number,
    title: string,
    done: boolean,
    priority: number
};

const myFirstTask: Task = {
    id: 1,
    title: 'Je dois le faire',
    done: false,
    priority: 5
};

function isUrgent(task: Task): boolean {
    return task.priority > 8;
}

isUrgent(myFirstTask);