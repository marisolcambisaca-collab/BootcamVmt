export type UserType = 'REGULAR' | 'CONTENT_CREATOR' | 'BUSINESS_ACCOUNT' | 'ADMINISTRATOR';

export interface UserDTO {
  idUser: string;
  nameUser: string;
  nameUnUser: string;
  email: string;
  visibility: boolean;
  typeUser: string;
  createdAt: string;
}

export interface LoginRequest {
  email: string;
  password: string;
}

export interface CreateUserRequest {
  nameUser: string;
  email: string;
  password: string;
  rewritePassword: string;
  typeUser: UserType;
  visibility: boolean;
}

export interface GetUsersParams {
  limit?: number;
  offset?: number;
  nameUser?: string;
  id?: string;
}

export interface AuthToken {
  token: string;
  userId: string;
  email: string;
  role: string;
}
