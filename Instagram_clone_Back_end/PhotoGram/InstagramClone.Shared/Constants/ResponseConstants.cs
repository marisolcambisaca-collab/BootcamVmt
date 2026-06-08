namespace InstagramClone.Shared.Constants
{
    public static class ResponseConstants
    {
        //SERVICES
        public const string USER_NOT_EXISTS = "El usuario no existe";
        public const string POST_NOT_EXISTS = "El post no existe.";

        //CREATE FIRST USER
        public static string ConfigurationPropertyNotFound(string property)
        {
            return $"Falta la propiedad '{property}' en la configuracion";
        }

        //MIDDLEWARE
        public static string ERROR_UNEXPECTED(string traceId)
        {
            return $"Ha ocurrido un error inesperado: contacte con soporte, mencionando el siguiente codigo de error: {traceId}";
        }

        //Auth
        public const string AUTH_TOKEN_NOT_FOUND = "el token no es correcto o expiro";
    }
}
