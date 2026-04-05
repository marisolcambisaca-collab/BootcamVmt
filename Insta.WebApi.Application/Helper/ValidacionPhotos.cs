    

    namespace Insta.Application.Helpers
    {
        public static class ValidacionPhotos
        {
            public static bool IsValid(string tipoPhoto)
            {
                if (tipoPhoto == "jpg" || tipoPhoto == "png")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
