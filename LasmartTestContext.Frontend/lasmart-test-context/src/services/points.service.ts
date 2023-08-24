import { AxiosResponse } from "axios";
import $api from "../http";
import { Point } from "../models/point.model";
import { GetAllPointsResponseDto } from "../dto/responseDto/getAllPoints.responseDto";
import { AddNewPointDto } from "../dto/addNewPointDto";

export class PointsService{
    /**
     * Получить список всех точек
     */
    static getAllPoints(): Promise<AxiosResponse<GetAllPointsResponseDto>> {
        return $api.get<GetAllPointsResponseDto>('/points');
    }
    /**
     * Добавить новую точку
     * @param point Объект новой точки
     */
    static addNewPoint(point: AddNewPointDto): Promise<AxiosResponse> {
        return $api.post('/points', JSON.stringify(point));
    }
    /**
     * Изменить свойства точки
     * @param point Объект изменённой точки
     */
    static updatePoint(point: Point): Promise<AxiosResponse> {
        return $api.put('/points', JSON.stringify(point));
    }
    /**
     * Удалить точку
     * @param pointId Идентификатор точки
     */
    static deletePoint(pointId: number): Promise<AxiosResponse> {
        return $api.delete(`/points/${pointId}`);
    }
}