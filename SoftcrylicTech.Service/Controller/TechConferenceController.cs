using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftcrylicTech.Library.Services.Interfaces;
using SoftcrylicTech.Model;
using SoftcrylicTech.Service.ModelSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SoftcrylicTech.Service.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechConferenceController : ControllerBase
    {
        private readonly ILogger<TechConferenceController> _logger;
        private readonly ITechConferenceService _techConferenceService;

        public TechConferenceController(ILogger<TechConferenceController> logger, ITechConferenceService techConferenceService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _techConferenceService = techConferenceService ?? throw new ArgumentNullException(nameof(techConferenceService));
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(IList<EventModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet("Event")]
        public async Task<IActionResult> GetEventInformationAsync([FromQuery] string title)
        {
            try
            {
                _logger.LogInformation("Get event data based on Id.");
                var result = await _techConferenceService.GetEventAsync(title);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResonse = new ErrorResponse(ex);
                errorResonse.Detail = "Error to get the event details";
                _logger.LogInformation(ex, errorResonse.ErrorId);
                return StatusCode(StatusCodes.Status500InternalServerError, errorResonse);
            }
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(IList<EventModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost("Event/Save")]
        public async Task<IActionResult> SaveEventInformationAsync([FromBody] EventModel eventModel)
        {
            try
            {
                _logger.LogInformation("Event data are processing for save.");
                var result = await _techConferenceService.SaveEventAsync(eventModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResonse = new ErrorResponse(ex);
                errorResonse.Detail = " Error In save Event information";
                _logger.LogInformation(ex, errorResonse.ErrorId);
                return StatusCode(StatusCodes.Status500InternalServerError, errorResonse);
            }
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(IList<EventModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpPut("Event/Update")]
        public async Task<IActionResult> ModifyEventInformationAsync(EventModel eventModel)
        {
            try
            {
                if (eventModel.Id == 0 && eventModel.Id == null)
                    return BadRequest();

                _logger.LogInformation("Event data are processing for Update.");
                var result = await _techConferenceService.UpdateEventAsync(eventModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResonse = new ErrorResponse(ex);
                errorResonse.Detail = " Error In save Event information";
                _logger.LogInformation(ex, errorResonse.ErrorId);
                return StatusCode(StatusCodes.Status500InternalServerError, errorResonse);
            }
        }


        [Produces("application/json")]
        [ProducesResponseType(typeof(IList<EventModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpPut("Event/Delete")]
        public async Task<IActionResult> DeleteEventInformationAsync([Required(ErrorMessage = "Event Id is manadatory!")] int eventId)
        {
            try
            {
                if (eventId <= 0)
                    return BadRequest();

                _logger.LogInformation("Event data are processing for Update.");
                var result = await _techConferenceService.DeleteEventAsync(eventId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResonse = new ErrorResponse(ex);
                errorResonse.Detail = " Error In save Event information";
                _logger.LogInformation(ex, errorResonse.ErrorId);
                return StatusCode(StatusCodes.Status500InternalServerError, errorResonse);
            }
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(IList<EventModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost("Speaker/Save")]
        public async Task<IActionResult> SaveSpeakerInformationAsync([FromBody] SpeakerModel speakerModel)
        {
            try
            {
                _logger.LogInformation("Speaker data are processing for save.");
                var result = await _techConferenceService.SaveSpeakerAsync(speakerModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResonse = new ErrorResponse(ex);
                errorResonse.Detail = " Error In save Speaker information";
                _logger.LogInformation(ex, errorResonse.ErrorId);
                return StatusCode(StatusCodes.Status500InternalServerError, errorResonse);
            }
        }
    }
}
