using System;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/formapagamento")]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly DataContext _context;
        public FormaPagamentoController(DataContext context)
        {
            _context = context;
        }

        //POST: api/formapagamento/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] FormaPagamento formapagamento)
        {
            _context.formapagamento.Add(formapagamento);
            _context.SaveChanges();
            return Created("", formapagamento);
        }

        //GET: api/produto/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.formapagamento
            .Include(p => p.Tipo)
            .ToList());


        //DELETE: /api/produto/delete/bolacha
        [HttpDelete]
        [Route("delete/{tipo}")]
        public IActionResult Delete([FromRoute] string tipo)
        {
            //Expressão lambda
            //Buscar um objeto na tabela de produtos com base no nome
            FormaPagamento formapagamento = _context.Formapagamento.FirstOrDefault(formapagamento => formapagamento.Tipo == tipo);

            if (formapagamento == null)
            {
                return NotFound();
            }
            _context.formaspagamento.Remove(formapagamento);
            _context.SaveChanges();
            return Ok(_context.formaspagamento.ToList());
        }
    }
}