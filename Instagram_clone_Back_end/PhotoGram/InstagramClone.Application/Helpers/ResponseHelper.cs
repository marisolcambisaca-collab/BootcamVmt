using InstagramClone.Application.Models.Responses;

namespace InstagramClone.Application.Helpers
{
    public static class ResponseHelper
    {
        public static GenericResponse<T> Create<T>(T data, List<string>? errors = null, string? message = null)
        {
            return new GenericResponse<T>
            {
                Data = data,
                Message = message ?? "Solicitud Realizadda Correctamente",
                Errors = errors ?? []
            };
        }
    }
}
