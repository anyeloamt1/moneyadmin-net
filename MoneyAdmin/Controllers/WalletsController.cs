﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MoneyAdmin.Data.Entities;
using MoneyAdmin.Data.Repositories.Base;
using MoneyAdmin.Extensions;
using MoneyAdmin.ViewModel;

namespace MoneyAdmin.Controllers
{
    public class WalletsController : BaseController
    {
        private readonly IGenericRepository<Wallet> _repository;

        public WalletsController(IGenericRepository<Wallet> repository)
        {
            _repository = repository;
        }

        //
        // GET: /Wallets/

        public ActionResult Index()
        {
            var wallets = _repository.RecentWallets()
                .Where(ByCurrentUserPredicate<Wallet>());
            
            var walletsVm = Mapper.Map<IEnumerable<WalletViewModel>>(wallets);

            return View(walletsVm);
        }

        //
        // GET: /Wallets/Details/5

        public ActionResult Details(int id)
        {
            return View("Partials/Wallets/_Create");
        }

        //
        // GET: /Wallets/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Wallets/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Wallets/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Wallets/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Wallets/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Wallets/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
