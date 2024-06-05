using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacoesController : ControllerBase
    {
        private readonly IObservacoesRepositorio _observacoesRepositorio;

        public ObservacoesController(IObservacoesRepositorio observacoesRepositorio)
        {
            _observacoesRepositorio = observacoesRepositorio;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ObservacoesModel>>> GetAllObservacoes()
        {
            List<ObservacoesModel> observacao = await _observacoesRepositorio.GetAll();
            return Ok(observacao);
        }

        [HttpGet("GetObservacoesId/{id}")]
        public async Task<ActionResult<ObservacoesModel>> GetObservacoesId(int id)
        {
            ObservacoesModel observacoes = await _observacoesRepositorio.GetById(id);
            return Ok(observacoes);
        }

        [HttpPost("CreateObservacoes")]
        public async Task<ActionResult<ObservacoesModel>> InsertObservacao([FromBody] ObservacoesModel observacoesModel)
        {
            ObservacoesModel observacoes = await _observacoesRepositorio.InsertObservacao(observacoesModel);
            return Ok(observacoes);
        }

        [HttpPut("UpdateObservacoes/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> UpdateObsevacao(int id, [FromBody] ObservacoesModel observacoesModel)
        {
            observacoesModel.ObservacaoId = id;
            ObservacoesModel observacao = await _observacoesRepositorio.UpdateObservacao(observacoesModel, id);
            return Ok(observacao);
        }

        [HttpDelete("DeleteObservacoes/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> DeleteObservacao(int id)
        {
            bool deleted = await _observacoesRepositorio.DeleteObservacao(id);
            return Ok(deleted);
        }

    }
}
