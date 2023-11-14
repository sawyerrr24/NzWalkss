using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalks.Api.Custom_Action_Filters;
using NzWalks.Api.Models.Domain;
using NzWalks.Api.Models.DTO;
using NzWalks.Api.Repositories;

namespace NzWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository )
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }






        // Create Walk
        //Post:/api/walks

        [HttpPost]
        [ValidateModel]

        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequest)
        {
            
                //Map dto to domain model
                var walksDomainmodel = mapper.Map<Walk>(addWalkRequest);


                await walkRepository.CreateAsync(walksDomainmodel);

                //map domain model to dto
                return Ok(mapper.Map<WalkDto>(walksDomainmodel));

        }

        //Get walks
        //Get:/api/walks
        //Get:/api/walks?/filterOn=Name&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery )
        {
            var walksDomainmodel=await walkRepository.GetAllAsync(filterOn, filterQuery);

            //map domain to dto
            return Ok(mapper.Map<List<WalkDto>>(walksDomainmodel));

        }


        //Get walk by id
        //Get /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainmodel=await walkRepository.GetByIdAsync(id);  

            if(walkDomainmodel == null)
            {
                return NotFound();
            }

            //map domain model to dto
            return Ok(mapper.Map<WalkDto>(walkDomainmodel));

        }



        //update walk by id
        //Put /api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id,UpdateWalkRequestDto updateWalkRequest)
        {
            
                //map dto to domain model
                var walkDomainmodel = mapper.Map<Walk>(updateWalkRequest);

                walkDomainmodel = await walkRepository.UpdateAsync(id, walkDomainmodel);

                if (walkDomainmodel == null)
                {
                    return NotFound();
                }

                //map domain model to dto
                return Ok(mapper.Map<WalkDto>(walkDomainmodel));

         
        }

        //delete a walk by id
        //delete /api/walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
           var deletedWalkdomain = await walkRepository.DeleteAsync(id);

            if(deletedWalkdomain == null)
            {
                return NotFound();
            }

            //Map domain model to dto
            return Ok(mapper.Map<WalkDto> (deletedWalkdomain)); 

        }


    }
}
