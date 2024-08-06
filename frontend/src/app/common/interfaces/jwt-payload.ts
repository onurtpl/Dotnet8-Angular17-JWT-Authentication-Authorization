export interface JwtPayload {
    email: string;
    name: string;
    fullname: string;
    nameid: string;
    aud: string;  // Audience
    iss: string;  // Issuer
    role: string[];
    nbf: number;  // Not Before
    exp: number;  // Expiry
    iat: number;  // Issued At
}
