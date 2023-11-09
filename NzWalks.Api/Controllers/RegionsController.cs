using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalks.Api.Data;
using NzWalks.Api.Models.Domain;
using NzWalks.Api.Models.DTO;
using NzWalks.Api.Repositories;

namespace NzWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext,IRegionRepository regionRepository,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


 

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var regionsDomain = await regionRepository.GetAllAsync();

            //Map domain Models to DTOs
           var regionsdto = mapper.Map<List<RegionDto>>(regionsDomain);
           
            return Ok(regionsdto);




            
            //or
            //  var regionsDomain = await regionRepository.GetAllAsync();
           // return Ok(mapper.Map<List<RegionDto>>(regionsDomain));


        }




        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);

            var region = await regionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);

        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequest)
        {
            //Map or convert dto to domain model
            var regiondomainmodel = new Region
            {
                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name,
                RegionImageUrl = addRegionRequest.RegionImageUrl

            };


            //Use domain model to create region 
            regiondomainmodel = await regionRepository.CreateAsync(regiondomainmodel);
         

            //map domain model back to dto
            var regionDto = new RegionDto
            {
                Id = regiondomainmodel.Id,
                Code = regiondomainmodel.Code,
                Name = regiondomainmodel.Name,
                RegionImageUrl = regiondomainmodel.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id },regionDto);
             
        }



        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequest)
        {
            //map dto to domain model
            var regionDomainmodel = new Region
            {
                Code = updateRegionRequest.Code,
                Name = updateRegionRequest.Name,
                RegionImageUrl = updateRegionRequest.RegionImageUrl
            };



            //Check if region exists
            regionDomainmodel=await regionRepository.UpdateAsync(id, regionDomainmodel);

            if (regionDomainmodel == null)
            {
                return NotFound();
            }



            //map dto to domain model
            regionDomainmodel.Code= updateRegionRequest.Code;
            regionDomainmodel.Name= updateRegionRequest.Name;
            regionDomainmodel.RegionImageUrl= updateRegionRequest.RegionImageUrl;


            await dbContext.SaveChangesAsync();


            //convert domain model to dto
            var regiondto = new Region
            {
                Id=regionDomainmodel.Id,
                Code = regionDomainmodel.Code,
                Name = regionDomainmodel.Name,
                RegionImageUrl = regionDomainmodel.RegionImageUrl
            };

            return Ok(regiondto);

        }


 

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
          
            var regionDomainModel=await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }


            


            var regiondto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            

            
            return Ok();






















            //or return deleted region back 
            //map domain model to dto
          /*  var regiondto = new Region
            {
           //  Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regiondto);
          */
        }



    }
}
 