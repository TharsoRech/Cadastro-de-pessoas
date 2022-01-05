using Cadastro_de_pessoas.Data;
using Cadastro_de_pessoas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cadastro_de_pessoas.Controllers
{
    [Route("api/Pessoas")]
    [ApiController]
    public class APiPessoasController : ControllerBase
    {
        private readonly AppliccationContext _context;


        public APiPessoasController(AppliccationContext context, IPessoaRepository pessoaRepository)
        {
            _context = context;

        }
        // GET: api/<APiPessoasController>
        [HttpGet]
        public async Task <ActionResult<string>> ObterPessoas()
        {
            //String json = JsonConvert.SerializeObject(_context.Pessoas, Formatting.Indented);
            if (_context.Pessoas == null)
            {
                return NotFound();
            }

            return Ok(_context.Pessoas);
        }

        // GET api/<APiPessoasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> ObterPessoa(string id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        // POST api/<APiPessoasController>
        [HttpPost]
        public async Task<ActionResult<Pessoa>> CriarPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                if (PessoaExists(pessoa.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPessoa", new { id = pessoa.Id }, pessoa);

        }

        // PUT api/<APiPessoasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarPessoa(string id, Pessoa pessoa)
        {
            if (id != pessoa.Id.ToString())
            {
                return BadRequest();
            }

            _context.Entry(pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!PessoaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<APiPessoasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPessoa(string id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id.ToString());
            if (pessoa == null)
            {
                return NotFound();
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool PessoaExists(string id)
        {
            return _context.Pessoas.Any(e => e.Id.ToString() == id.ToString());
        }

    }
}
