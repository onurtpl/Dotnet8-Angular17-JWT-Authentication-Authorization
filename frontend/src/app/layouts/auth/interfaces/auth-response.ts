export interface AuthResponse {
    accessToken: string;
    refreshToken: string;
    refreshTokenExpire: string;
    roles: string[];
}
