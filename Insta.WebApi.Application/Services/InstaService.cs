

    using Insta.Application.Interfaces.Services;
    using Insta.Application.Models.Requests.Photos;
    using Insta.Application.Helpers;

    namespace Insta.Application.Services
 
{

    public class se : IInstaService
    {
        public void PublicarContenido(PhotoRequest request)
        {
            if (string.IsNullOrEmpty(request.BaseImage))
            {
                Console.WriteLine("NO llegó imagen");
                return;
            }

            Console.WriteLine("Sí llegó imagen 🔥");


            //validacion

            var extension = "jpg" ; 

            if (!ValidacionPhotos.IsValid(extension))
            {
                Console.WriteLine("Formato no permitido ❌");
                return;
            }

        }
    }

}
