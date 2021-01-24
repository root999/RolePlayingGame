import { Character } from "./character";

export class ServiceResponse<T> {
    text(): any {
      throw new Error('Method not implemented.');
    }
    data: T;
    success: boolean;
    message?: any;
}
