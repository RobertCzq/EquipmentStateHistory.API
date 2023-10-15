using Lego.EquipmentStateHistory.API.Infrastructure.Repository;
using Lego.EquipmentStateHistory.API.Models;
using Lego.EquipmentStateHistory.API.Services;
using Lego.EquipmentStateHistory.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lego.EquipmentStateHistory.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateHistoryController : ControllerBase
    {
        private readonly IStateHistoryRepository _stateHistoryRepository;
        private readonly IStateToColorConvertor _stateToColorConvertor;

        public StateHistoryController(IStateHistoryRepository stateHistoryRepository,
            IStateToColorConvertor stateToColorConvertor)
        {
            _stateHistoryRepository = stateHistoryRepository ?? throw new ArgumentNullException(nameof(stateHistoryRepository));
            _stateToColorConvertor = stateToColorConvertor ?? throw new ArgumentNullException(nameof(stateToColorConvertor));
        }

        [HttpGet("GetCurrentState/{equipmentId}")]
        public async Task<IActionResult> GetCurrent(long equipmentId)
        {
            var curentState = await _stateHistoryRepository.GetCurrentState(equipmentId);

            if (curentState == null)
            {
                return NotFound();
            }

            var currentStateViewModel = new EquipmentStateViewModel()
            {
                EquipmentId = curentState.EquipmentId,
                DateModified = curentState.DateModified,
                Color = _stateToColorConvertor.ConvertStateToColor(curentState.State)
            };

            return Ok(currentStateViewModel);
        }

        [HttpGet("GetEquipmentHistory/{equipmentId}")]
        public async Task<IActionResult> GetAll(long equipmentId)
        {
            var states = await _stateHistoryRepository.GetAll(equipmentId);

            if (!states.Any())
            {
                return NotFound();
            }

            var statesViewModels = states.Select(st =>
                new EquipmentStateViewModel()
                {
                    EquipmentId = st.EquipmentId,
                    DateModified = st.DateModified,
                    Color = _stateToColorConvertor.ConvertStateToColor(st.State)
                }).ToList();

            return Ok(statesViewModels);
        }

        [HttpPost("AddStateToHistory")]
        public async Task<IActionResult> AddState([FromBody] EquipmentState equipmentState)
        {
            var stateAdded = await _stateHistoryRepository.AddState(equipmentState);

            if (!stateAdded)
            {
                return Conflict();
            }

            return Created("", equipmentState);
        }
    }
}