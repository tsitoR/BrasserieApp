using AutoMapper;
using BrasserieManager.Services.GrossisteAPI.Models.Dto;
using BrasserieManager.Services.GrossisteAPI.Models;
using BrasserieManager.Services.GrossisteAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrasserieManager.Services.GrossisteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiereGrossisteController : ControllerBase
    {
        protected ResultDto _result;
        private readonly IBiereGrossisteRepository _biereGrossisteRepository;
        private readonly IMapper _mapper;
        public BiereGrossisteController(IBiereGrossisteRepository biereGrossisteRepository, IMapper mapper)
        {
            _result = new ResultDto();
            _biereGrossisteRepository = biereGrossisteRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<Object> Get()
        {
            try
            {
                IEnumerable<BiereGrossiste> biereGrossistes = await _biereGrossisteRepository.GetBiereGrossistesAsync();
                _result.Result = _mapper.Map<List<BiereGrossisteDto>>(biereGrossistes);
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
                BiereGrossiste result = await _biereGrossisteRepository.GetBiereGrossisteByIdAsync(id);
                _result.Result = _mapper.Map<BiereGrossisteDto>(result);
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
        [Route("byGrossiste/{id}")]
        public async Task<Object> GetByGrossisteId([FromForm] int id)
        {
            try
            {
                IEnumerable<BiereGrossiste> result = await _biereGrossisteRepository.GetBiereGrossistesByGrossisteAsync(id);
                _result.Result = _mapper.Map<IEnumerable<BiereGrossisteDetailsDto>>(result);
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
        public async Task<Object> Post([FromForm] BiereGrossisteDto biereGrossisteDto)
        {
            try
            {
                BiereGrossiste biereGrossiste = _mapper.Map<BiereGrossiste>(biereGrossisteDto);
                BiereGrossiste result = await _biereGrossisteRepository.CreateUpdateBiereGrossisteAsync(biereGrossiste);
                _result.Result = _mapper.Map<BiereGrossisteDto>(result);
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
        public async Task<Object> Put([FromForm] BiereGrossisteDto biereGrossisteDto)
        {
            try
            {
                BiereGrossiste biereGrossiste = _mapper.Map<BiereGrossiste>(biereGrossisteDto);
                BiereGrossiste result = await _biereGrossisteRepository.CreateUpdateBiereGrossisteAsync(biereGrossiste);
                _result.Result = _mapper.Map<BiereGrossisteDto>(result);
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
                bool result = await _biereGrossisteRepository.DeleteBiereGrossisteAsync(id);
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
