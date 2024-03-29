﻿using CQRSCode.ReadModel;
using CQRSCode.WriteModel.Commands;
using CqrsFramework.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandSender _commandSender;
        private readonly IReadModelFacade _readmodel;

        public HomeController(ICommandSender commandSender, IReadModelFacade readmodel)
        {
            _readmodel = readmodel;
            _commandSender = commandSender;
        }

        public ActionResult Index()
        {
            ViewData.Model = _readmodel.GetInventoryItems();
            return View();
        }

        public ActionResult Details(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(string name, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new CreateInventoryItem(Guid.NewGuid(), name), cancellationToken);
            return RedirectToAction("Index");
        }

        public ActionResult ChangeName(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangeName(Guid id, string name, int version, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new RenameInventoryItem(id, name, version), cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Deactivate(Guid id, int version, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new DeactivateInventoryItem(id, version), cancellationToken);
            return RedirectToAction("Index");
        }

        public ActionResult CheckIn(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CheckIn(Guid id, int number, int version, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new CheckInItemsToInventory(id, number, version), cancellationToken);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(Guid id)
        {
            ViewData.Model = _readmodel.GetInventoryItemDetails(id);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Remove(Guid id, int number, int version, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new RemoveItemsFromInventory(id, number, version), cancellationToken);
            return RedirectToAction("Index");
        }
    }
}
