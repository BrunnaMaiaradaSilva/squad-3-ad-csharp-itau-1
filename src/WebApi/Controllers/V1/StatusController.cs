﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;

namespace TryLog.WebApi.Controllers.V1
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;
        public StatusController(IStatusService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todos os Status registrados
        /// </summary>
        /// <returns></returns>
        // GET: api/Status
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.SelectAll());
        }

        /// <summary>
        /// Retorna o Status solicitado por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Status/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var status = _service.Get(id);

            if (status is null)
                return NoContent();

            return Ok(status);
        }

        /// <summary>
        /// Cria um novo Status
        /// </summary>
        /// <param name="statusViewModel"></param>
        /// <returns></returns>
        // POST: api/Status
        [HttpPost]
        public IActionResult Post([FromBody] StatusViewModel statusViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var status = _service.Add(statusViewModel);

            if (status is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { status.Id }, status);
        }

        /// <summary>
        /// Altera um Status existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusViewModel"></param>
        /// <returns></returns>
        // PUT: api/Status/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StatusViewModel statusViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            statusViewModel.Id = id;
            bool resultUpdate = _service.Update(statusViewModel);

            if (!resultUpdate)
                return NoContent();

            return Ok();
        }

        /// <summary>
        /// Remove um Status existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
