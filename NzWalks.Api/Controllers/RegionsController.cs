using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalks.Api.Custom_Action_Filters;
using NzWalks.Api.Data;
using NzWalks.Api.Models.Domain;
using NzWalks.Api.Models.DTO;
using NzWalks.Api.Repositories;

namespace NzWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
        [Authorize(Roles = "Reader")]
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
        [Authorize(Roles = "Reader")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            

            //Get region domain model from db

            var region = await regionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(region));

        }



        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequest)
        {

            
            

                //Map or convert dto to domain model

                var regionDomainModel = mapper.Map<Region>(addRegionRequest);


                //Use domain model to create region 

                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                //map domain model back to dto
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);


                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

           

             
        }



        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequest)
        {

           
            
                //map dto to domain model
                var regionDomainmodel = mapper.Map<Region>(updateRegionRequest);



                //Check if region exists
                regionDomainmodel = await regionRepository.UpdateAsync(id, regionDomainmodel);

                if (regionDomainmodel == null)
                {
                    return NotFound();
                }



                //map dto to domain model



                //convert domain model to dto



                return Ok(mapper.Map<RegionDto>(regionDomainmodel));

            


        }



        
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
          
            var regionDomainModel=await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }


        
            
            return Ok(mapper.Map<RegionDto>(regionDomainModel));


        }



    }
}
 