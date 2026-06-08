export interface ApiResponse<T> {
  data: T;
  message: string;
  errors: string[];
  timeStamp: string;
}
