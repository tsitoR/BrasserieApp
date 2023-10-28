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
    public class GrossisteController : ControllerBase
    {
        protected ResultDto _result;
        private readonly IGrossisteRepository _grossisteRepository;
        private readonly IMapper _mapper;
        public GrossisteController(IGrossisteRepository grossisteRepository, IMapper mapper)
        {
            _result = new ResultDto();
            _grossisteRepository = grossisteRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<Object> Get()
        {
            try
            {
                IEnumerable<Grossiste> grossistes = await _grossisteRepository.GetGrossistesAsync();
                _result.Result = _mapper.Map<List<GrossisteDto>>(grossistes);
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
                Grossiste result = await _grossisteRepository.GetGrossisteByIdAsync(id);
                _result.Result = _mapper.Map<GrossisteDto>(result);
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
        public async Task<Object> Post([FromForm] GrossisteDto grossisteDto)
        {
            try
            {
                Grossiste grossiste = _mapper.Map<Grossiste>(grossisteDto);
                Grossiste result = await _grossisteRepository.CreateUpdateGrossisteAsync(grossiste);
                _result.Result = _mapper.Map<GrossisteDto>(result);
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
        public async Task<Object> Put([FromForm] GrossisteDto grossisteDto)
        {
            try
            {
                Grossiste grossiste = _mapper.Map<Grossiste>(grossisteDto);
                Grossiste result = await _grossisteRepository.CreateUpdateGrossisteAsync(grossiste);
                _result.Result = _mapper.Map<GrossisteDto>(result);
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
                bool result = await _grossisteRepository.DeleteGrossisteAsync(id);
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
