using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Insta.Application.Models.Requests.Photos

{
    public class PhotoRequest
    {
       
            [Required] 
            public string BaseImage { get; set; } = null!;
              public string Texto { get; set; } = null!;
            public string Usuario { get; set;}= null!;
            
        
    }

}

