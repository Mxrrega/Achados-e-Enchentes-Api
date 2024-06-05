using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class ObservacoesRepositorio : IObservacoesRepositorio
    {
        private readonly Contexto _dbContext;

        public ObservacoesRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ObservacoesModel>> GetAll()
        {
            return await _dbContext.Observacoes.ToListAsync();
        }

        public async Task<ObservacoesModel> GetById(int id)
        {
            return await _dbContext.Observacoes.FirstOrDefaultAsync(x => x.ObservacaoId == id);
        }

        public async Task<ObservacoesModel> InsertObservacao(ObservacoesModel observacoes)
        {
            await _dbContext.Observacoes.AddAsync(observacoes);
            await _dbContext.SaveChangesAsync();
            return observacoes;
        }

        public async Task<ObservacoesModel> UpdateObservacao(ObservacoesModel observacoes, int id)
        {
            ObservacoesModel observacao = await GetById(id);
            if (observacao == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                observacao.ObservacaoDescricao = observacoes.ObservacaoDescricao;
                observacao.ObservacaoLocal = observacoes.ObservacaoLocal;
                observacao.ObservacaoData = observacoes.ObservacaoData;
                observacao.PessoaId = observacoes.PessoaId;
                observacao.UsuarioId = observacoes.UsuarioId;
                _dbContext.Observacoes.Update(observacao);
                await _dbContext.SaveChangesAsync();
            }
            return observacao;

        }

        public async Task<bool> DeleteObservacao(int id)
        {
            ObservacoesModel observacao = await GetById(id);
            if (observacao == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Observacoes.Remove(observacao);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
