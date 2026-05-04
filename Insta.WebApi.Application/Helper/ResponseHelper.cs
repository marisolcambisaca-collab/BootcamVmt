using Insta.Application.Models.Requests.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insta.Application.Helper
{
    public static class ResponseHelper
    {
        public static GenericResponse<T> Create<T>(T data, List<string>? errors = null, string? message = null)
        {
            var response = new GenericResponse<T>
            { 
                Data = data,
                Message = message ?? "Solicitud realizada correctamente",
                Errors = errors ?? []
            };

            return response;
        }



    }
}
