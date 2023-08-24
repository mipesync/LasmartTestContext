import { CircleConfig } from "konva/lib/shapes/Circle";
import { Point } from "../models/point.model";
import { KonvaEventObject } from "konva/lib/Node";

export function mapPointToCircleConfigArray(points?: Point[]): CircleConfig[] {
    if (!points){
        return [];
    }

    let configs: CircleConfig[] = [];
    
    points.forEach(point => {
        configs.push({
            id: point.id.toString(),
            x: point.x,
            y: point.y,
            fill: point.color,
            radius: point.radius,
        });
    });

    return configs;
}

export function mapPointToCircleConfig(point: Point): CircleConfig {
    let config: CircleConfig = {
            id: point.id.toString(),
            x: point.x,
            y: point.y,
            fill: point.color,
            radius: point.radius,
        };

    return config;
}

export function mapCircleConfigToPoint(event: KonvaEventObject<MouseEvent>): Point {
    let point: Point = {
        id: Number.parseInt(event.target.getAttr('id')),
        x: event.target.getAttr('x'),
        y: event.target.getAttr('y'),
        color: event.target.getAttr('fill'),
        radius: event.target.getAttr('radius'),
    }

    return point;
}