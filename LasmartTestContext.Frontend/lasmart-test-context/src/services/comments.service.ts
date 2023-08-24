import { AxiosResponse } from "axios";
import $api from "../http";
import { AddNewCommentDto } from "../dto/addNewCommentDto";
import { Comment } from "../models/comment.model";

export class CommentsService {
        /**
         * Добавить новый комментарий
         * @param comment Объект нового комментария
         */
        static addNewComment(comment: AddNewCommentDto): Promise<AxiosResponse> {
            return $api.post('/comments', JSON.stringify(comment));
        }
        /**
         * Изменить свойства комментария
         * @param comment Объект изменённого комментария
         */
        static updateComment(comment: Comment): Promise<AxiosResponse> {
            return $api.put('/comments', JSON.stringify(comment));
        }
}