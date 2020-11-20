using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroClientes.Dados.Contexto;
using CadastroClientes.Dominio.Entidades;
using CadastroClientes.Dominio.DTO;
using CadastroClientes.Dominio.Servicos.Api;
using CadastroClientes.Dominio.Interfaces.Repositorio;

namespace CadastroClientes.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Context _context;
        private readonly IRepositorioBase<Cliente> _repositorio;

        public ClientesController(Context context, IRepositorioBase<Cliente> repositorio)
        {
            _context = context;
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            return View(_repositorio.List());
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var cliente = _repositorio.GetById(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,DataNascimento,Sexo,Cep,Logradouro,Numero,Complemento,Bairro,Uf,Cidade,Id")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Insert(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _repositorio.GetById(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Nome,DataNascimento,Sexo,Cep,Logradouro,Numero,Complemento,Bairro,Uf,Cidade,Id")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repositorio.Update(cliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _repositorio.GetById(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repositorio.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _repositorio.GetById(id) != null;
        }

        public async Task<EnderecoDTO> ObterDadosCep(string cep)
        {
            return await ConsultarCep.ObterDados(cep);
        }
    }
}
