namespace InstagramClone.Shared.Constants
{
    public static class ValidationConstants
    {
        //VALIDACIONES GENERALES
        public const string REQUIRED = "Este campo es requerido";
        public const string MAX_LENGTH = "Ha sobrepasado los {1} de {0}";
        public const string MIN_LENGTH = "El minimo de caracteres es {1} para el {0}";
        public const string EMAIL_ADDRESS = "Este campo requiere una direccion de correo";
        public const string PASSWORDS_MUST_MATCH = "Ambos campos {0} y {1} deben coincidir";
        public const string VALIDATION_MESSAGE = "Uno o mas validaciones  necesitan atencion";
        //VALIDACIONES POSTS
        public const string INVALID_LATITUDE = "La {0} debe estar entre {1} y {2}";
        public const string INVALID_LONGITUDE = "La {0} debe estar entre {1} y {2}";

    }
}
