using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalks.Api.Models.Domain;
using NzWalks.Api.Models.DTO;
using NzWalks.Api.Repositories;

namespace NzWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }


        //Post: /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto requestDto)
        {
            ValidateFileUpload(requestDto);


            if(ModelState.IsValid)
            {
                //convert dto to domain model
                var imageDomainModel = new Image
                {
                    File = requestDto.File,
                    FileExtenxsion = Path.GetExtension(requestDto.File.FileName),
                    FileSizeInBytes = requestDto.File.Length,
                    FileName = requestDto.FileName,
                    FileDescription = requestDto.FileDescription
                };






                //User repo to upload image
                await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);

            }

            return BadRequest(ModelState);

        }



        private void ValidateFileUpload(ImageUploadRequestDto requestDto)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if(allowedExtensions.Contains(Path.GetExtension(requestDto.File.FileName))==false)
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }


            if(requestDto.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB please upload a smaller size file.");
            }

        }
        
    }
}
