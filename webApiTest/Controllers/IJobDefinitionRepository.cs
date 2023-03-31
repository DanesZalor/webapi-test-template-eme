using webApiTest.Model;

namespace webApiTest.Controllers;

public interface IJobDefinitionRepository 
{
    void Add(JobDefinition jobDefinition);
    JobDefinition? Get(string name); 
    IEnumerable<JobDefinition> GetAll();
}
