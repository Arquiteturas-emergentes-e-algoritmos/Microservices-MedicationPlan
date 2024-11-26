using MedicationPlan.Application.Command;
using MedicationPlan.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicationPlan.WebApi.Controllers;

[ApiController]
[Route("/v1/medication")]
public class MedicationPlanController : ControllerBase
{

    [Route("healthcheck")]
    [HttpPost]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public IActionResult PostAddMedication()
    {
        return Ok("Alive");
    }

    [Route("")]
    [HttpPost]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult PostAddMedication
    ([FromBody] AddMedicationCommand command, [FromServices] MedicationPlanService handler)
    {
        try
        {
            if (!ModelState.IsValid || !command.Validate())
                return BadRequest();

            handler.Handle(command);

            return Ok("Adicionado com sucesso");
        }

        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("")]
    [HttpGet]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult GetMedications([FromBody] GetMedicationPlanCommand command, [FromServices] MedicationPlanService handler)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var medications = handler.Handle(command);
            return Ok(medications);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("")]
    [HttpPut]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult UpdateMedication([FromBody] UpdateMedicationCommand command, [FromServices] MedicationPlanService handler)
    {
        try
        {
            if (!ModelState.IsValid || !command.Validate())
                return BadRequest();

            handler.Handle(command);
            return Ok("Atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
    [Route("")]
    [HttpDelete]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteMedication([FromServices] MedicationPlanService handler, [FromBody] DeleteMedicationCommand command)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();

            handler.Handle(command);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

}
