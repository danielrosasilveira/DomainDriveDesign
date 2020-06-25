﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using Infrastructure.Configuration;
using ApplicationApp.Interfaces;

namespace Web_DDD.Controllers
{
    
    public class ProductsController : Controller
    {
        //private readonly ContextBase _context;
        private readonly InterfaceProductApp _InterfaceProductApp;
        public ProductsController(InterfaceProductApp InterfaceProductApp)
        {
            _InterfaceProductApp = InterfaceProductApp;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _InterfaceProductApp.List());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _InterfaceProductApp.GetEntityById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Preco,Ativo,ID,Nome")] Product product)
        {
            if (ModelState.IsValid)
            {
                //await _InterfaceProductApp.Add(product);
                await _InterfaceProductApp.AddProduct(product);
                if (product.Notitycoes.Any())
                {
                    foreach(var item in product.Notitycoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                    return View(nameof(Create), product);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _InterfaceProductApp.GetEntityById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Preco,Ativo,ID,Nome")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //await _InterfaceProductApp.Update(product);                    
                    await _InterfaceProductApp.UpdateProduct(product);
                    if (product.Notitycoes.Any())
                    {
                        foreach (var item in product.Notitycoes)
                        {
                            ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                        }
                        return View(nameof(Edit), product);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExists(product.ID))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _InterfaceProductApp.GetEntityById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _InterfaceProductApp.GetEntityById(id);
            await _InterfaceProductApp.Delete(product);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExists(int id)
        {
            var objeto = await _InterfaceProductApp.GetEntityById(id);
            return objeto != null;
        }
    }
}
