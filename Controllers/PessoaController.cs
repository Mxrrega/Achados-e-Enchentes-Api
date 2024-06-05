using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PessoaModel>>> GetAllPessoa()
        {
            List<PessoaModel> pessoas = await _pessoaRepositorio.GetAll();
            return Ok(pessoas);
        }

        [HttpGet("GetPessoaId/{id}")]
        public async Task<ActionResult<PessoaModel>> GetPessoaId(int id)
        {
            PessoaModel pessoa = await _pessoaRepositorio.GetById(id);
            return Ok(pessoa);
        }

        [HttpPost("CreatePessoa")]
        public async Task<ActionResult<PessoaModel>> InsertPessoa([FromBody] PessoaModel pessoaModel)
        {
            PessoaModel pessoa = await _pessoaRepositorio.InsertPessoa(pessoaModel);
            return Ok(pessoa);
        }

        [HttpPut("UpdatePessoa/{id:int}")]
        public async Task<ActionResult<PessoaModel>> UpdatePessoa(int id, [FromBody] PessoaModel pessoaModel)
        {
            pessoaModel.PessoaId = id;
            PessoaModel pessoas = await _pessoaRepositorio.UpdatePessoa(pessoaModel, id);
            return Ok(pessoas);
        }

        [HttpDelete("DeletePessoa/{id:int}")]
        public async Task<ActionResult<PessoaModel>> DeletePessoa(int id)
        {
            bool deleted = await _pessoaRepositorio.DeletePessoa(id);
            return Ok(deleted);
        }
    }
}
