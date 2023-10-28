using AutoMapper;
using BrasserieManager.Services.BrasserieAPI.Models;
using BrasserieManager.Services.BrasserieAPI.Models.Dto;
using BrasserieManager.Services.BrasserieAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrasserieManager.Services.BrasserieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrasserieController : ControllerBase
    {

        protected ResultDto _result;
        private readonly IBrasserieRepository _brasserieRepository;
        private readonly IMapper _mapper;
        public BrasserieController(IBrasserieRepository brasserieRepository, IMapper mapper)
        {
            _result = new ResultDto();
            _brasserieRepository = brasserieRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<Object> Get()
        {
            try
            {
                IEnumerable<Brasserie> brasseries = await _brasserieRepository.GetBrasseriesAsync();
                _result.Result = _mapper.Map<List<BrasserieDto>>(brasseries);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _result;
        }

        [HttpPost]
        [Route("details/{id}")]
        public async Task<Object> GetById([FromForm] int id)
        {
            try
            {
                Brasserie result = await _brasserieRepository.GetBrasserieByIdAsync(id);
                _result.Result = _mapper.Map<BrasserieDto>(result);
            }
            catch (Exception e)
            {
                _result.IsSuccess = false;
                _result.ErrorMessages
                     = new List<string>() { e.ToString() };
            }
            return _result;
        }

        [HttpPost]
        public async Task<Object> Post([FromForm] BrasserieDto brasserieDto)
        {
            try
            {
                Brasserie brasserie = _mapper.Map<Brasserie>(brasserieDto);
                Brasserie result = await _brasserieRepository.CreateUpdateBrasserieAsync(brasserie);
                _result.Result = _mapper.Map<BrasserieDto>(result);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _result;
        }

        [HttpPut]
        public async Task<Object> Put([FromForm] BrasserieDto brasserieDto)
        {
            try
            {
                Brasserie brasserie = _mapper.Map<Brasserie>(brasserieDto);
                Brasserie result = await _brasserieRepository.CreateUpdateBrasserieAsync(brasserie);
                _result.Result = _mapper.Map<BrasserieDto>(result);
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _result;
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<Object> Delete([FromForm] int id)
        {
            try
            {
                bool result = await _brasserieRepository.DeleteBrasserieAsync(id);
                _result.Result = result;
            }
            catch (Exception ex)
            {
                _result.IsSuccess = false;
                _result.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _result;
        }
    }
}
