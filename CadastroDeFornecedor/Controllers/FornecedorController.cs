using CadastroDeFornecedor.Models;
using CadastroDeFornecedor.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CadastroDeFornecedor.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly iFornecedorRepositorio _fornecedorRepositorio;
        public FornecedorController(iFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }
        public IActionResult Index()
        {
            List<FornecedorModel> contatos = _fornecedorRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorID(id);
            return View(fornecedor);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorID(id);
            return View(fornecedor);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _fornecedorRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cadastro Deletado Com Sucesso! ";
                }
                else

                    TempData["MensagemErro"] = "Não Foi Possível Deletar Fornecedor! ";

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não Foi Possível Deletar Fornecedor, Detalhe do Erro:{erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Adicionar(fornecedor);
                    TempData["MensagemSucesso"] = "Cadastro Realizado Com Sucesso! ";
                    return RedirectToAction("Index");
                }
                return View(fornecedor);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não Foi Possível Realizar o Cadastro do Fornecedor, Detalhe do Erro:{erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(FornecedorModel fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Atualizar(fornecedor);
                    TempData["MensagemSucesso"] = "Alteração Realizada Com Sucesso! ";
                    return RedirectToAction("Index");
                }
                return View("Editar", fornecedor);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não Foi Possível Realizar a Atualização  do Fornecedor, Detalhe do Erro:{erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}
