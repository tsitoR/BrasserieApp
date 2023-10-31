using AutoMapper;
using BrasserieManager.Services.GrossisteAPI.Models.Dto;
using BrasserieManager.Services.GrossisteAPI.Models;
using BrasserieManager.Services.GrossisteAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BrasserieManager.Services.GrossisteAPI.Services;
using BrasserieManager.Services.BrasserieAPI.Repository;

namespace BrasserieManager.Services.GrossisteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiereGrossisteController : ControllerBase
    {
        protected ResultDto _result;
        private readonly IBiereGrossisteRepository _biereGrossisteRepository;
        private readonly IBiereRepository _biereRepository;
        private readonly IMapper _mapper;
        public BiereGrossisteController(IBiereGrossisteRepository biereGrossisteRepository, IBiereRepository biereRepository, IMapper mapper)
        {
            _result = new ResultDto();
            _biereGrossisteRepository = biereGrossisteRepository;
            _biereRepository = biereRepository;
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
        [Route("commande")]
        public async Task<Object> PostCommande([FromBody] CommandeDto commandeDto)
        {
            try
            {
                CommandeService cs = new(_biereGrossisteRepository, _biereRepository);
                Commande commande = _mapper.Map<Commande>(commandeDto);
                IEnumerable<BiereGrossiste> biereGrossistes = await _biereGrossisteRepository.GetBiereGrossistesByGrossisteAsync(commandeDto.GrossisteId);
                IEnumerable<BiereCommande> biereCommandes = _mapper.Map<IEnumerable<BiereCommande>>(commandeDto.BiereCommandes);
                var result = await cs.DevisCommande(biereCommandes, commandeDto.GrossisteId, commande, biereGrossistes);
                _result.Result = new
                {
                    commandeDetails = commande,
                    listCommande = biereCommandes,
                    commandeStatus = result
                };
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
