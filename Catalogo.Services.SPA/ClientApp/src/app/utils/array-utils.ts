import { Entity } from "../models/model-base";

export abstract class ArrayUtils {
    static removeEntityOfList(list: Entity[], id: number) {
        const index = list.findIndex(l => l.id === id);
        list.splice(index, 1);
    }
}