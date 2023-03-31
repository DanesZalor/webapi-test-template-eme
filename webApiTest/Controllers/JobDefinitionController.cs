using Microsoft.AspNetCore.Mvc;
using webApiTest.Model;

namespace webApiTest.Controllers;

/*
* Route is automatically set as the classname without Controller suffix https://address:port/jobdefinition
* if it doesnt end with "Controller", it will use the full classname instead
*/  
[Route("[controller]")]
[ApiController]
public class JobDefinitionController : ControllerBase
{
    private IJobDefinitionRepository _jobDefinitionRepository;
    public JobDefinitionController(IJobDefinitionRepository jobDefRepo)
    {
        _jobDefinitionRepository = jobDefRepo ?? throw new ArgumentNullException(nameof(jobDefRepo));
    }

    [HttpPost]
    public ActionResult Add(JobDefinition jobDefinition)  // Post request body is automatically serialized to JobDefinitionModel  
    {
        if (string.IsNullOrWhiteSpace(jobDefinition.Name)) 
            return BadRequest($"name not provided");

        if (_jobDefinitionRepository.Get(jobDefinition.Name) != null)
            return BadRequest("jobDefinition already exists");
        
        _jobDefinitionRepository.Add(jobDefinition);

        // for some reason, "Created" Response requires a createdAtUrl
        return Created("https://test.address.com", jobDefinition);
    }

    [HttpGet]
    public ActionResult<IEnumerable<JobDefinition>> GetAll() 
    {
        return Ok(value: _jobDefinitionRepository.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<JobDefinition> Get(string name) 
    {
        var jobDefinition = _jobDefinitionRepository.Get(name);

        if(jobDefinition == null) return NotFound();

        return Ok(jobDefinition);
    }
}
