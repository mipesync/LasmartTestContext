/**
 * Получить случайный цвет
 */
export function randomiseColor(): string {
    const colors: string[] = [
        '#8c8ecf', '#cf8cb4', '#b48ccf', '#cf8c8c', 
        '#cfcb8c', '#a6cf8c', '#8dcecf', 
    ];

    return colors[Math.floor(Math.random() * colors.length)];
}