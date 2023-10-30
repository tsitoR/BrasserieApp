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
    public class BiereController : ControllerBase
    {
        protected ResultDto _result;
        private readonly IBiereRepository _biereRepository;
        private readonly IMapper _mapper;
        public BiereController(IBiereRepository biereRepository, IMapper mapper)
        {
            _result = new ResultDto();
            _biereRepository = biereRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<Object> Get()
        {
            try
            {
                IEnumerable<Biere> bieres = await _biereRepository.GetBieresAsync();
                _result.Result = _mapper.Map<List<BiereDetailsDto>>(bieres);
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
                Biere result = await _biereRepository.GetBiereByIdAsync(id);
                _result.Result = _mapper.Map<BiereDto>(result);
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
        [Route("byBrasserie/{id}")]
        public async Task<Object> GetByBrasserieId([FromForm] int id)
        {
            try
            {
                IEnumerable<Biere> result = await _biereRepository.GetBiereByBrasserieAsync(id);
                _result.Result = _mapper.Map<IEnumerable<BiereDetailsDto>>(result);
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
        public async Task<Object> Post([FromForm] BiereDto biereDto)
        {
            try
            {
                Biere biere = _mapper.Map<Biere>(biereDto);
                Biere result = await _biereRepository.CreateUpdateBiereAsync(biere);
                _result.Result = _mapper.Map<BiereDto>(result);
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
        public async Task<Object> Put([FromForm] BiereDto biereDto)
        {
            try
            {
                Biere biere = _mapper.Map<Biere>(biereDto);
                Biere result = await _biereRepository.CreateUpdateBiereAsync(biere);
                _result.Result = _mapper.Map<BiereDto>(result);
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
                bool result = await _biereRepository.DeleteBiereAsync(id);
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
