namespace InstagramClone.Shared.Constants
{
    public static class ConfigurationConstants
    {
        //DATABASE
        public const string CONNECTION_STRING_DATABASE = "ConnectionStrings:Database";

        //DATOS PRIMER USUARIO
        public const string FIRST_APP_TIME_USER_NAMEUSER = "FirstAppTime:User:NameUser";
        public const string FIRST_APP_TIME_USER_EMAIL = "FirstAppTime:User:Email";
        public const string FIRST_APP_TIME_USER_PASSWORD = "FirstAppTime:User:Password";
        public const string FIRST_APP_TIME_USER_IDTYPEUSER = "FirstAppTime:User:IdTypeUser";

        //DATOS PARA JWT BEARER TOKENS
        public const string JWT_ISSUER = "Jwt:Issuer";
        public const string JWT_AUDIENCE = "Jwt:Audience";
        public const string JWT_PRIVATE_KEY = "Jwt:PrivateKey";
        public const string JWT_EXPIRATION_IN_MINUTES = "Jwt:ExpirationInMinutes";

        //ROLES PARA EL AUTHORIZE
        public const string AUTHORIZE_ADMINISTRATOR = "0CC3091A-95A4-4230-ADB6-AF49D89790BB";
        public const string AUTHORIZE_REGULAR = "2724189B-BCA3-4C40-8A55-5526D2E64A70";
        public const string AUTHORIZE_CONSTANT_CREATOR = "BF197505-7EEB-4FB3-B004-212A67D82018";
        public const string AUTHORIZE_BUSINESS_ACCOUNT = "4C325113-B485-46F3-9783-CCB7362E8EC1";

        //DATOS CORS
        public const string CORS_ORIGINS = "Cors:AllowedOrigins";
    }
}
