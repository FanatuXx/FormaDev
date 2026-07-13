export type Task = {
    id: number;
    title: string;
    description: string;
    priority: TaskPriority;
    imageUrl?: string;
    done: boolean;
};

export enum TaskPriority {
    LOW = "LOW",
    MEDIUM = "MEDIUM",
    HIGH = "HIGH",
}