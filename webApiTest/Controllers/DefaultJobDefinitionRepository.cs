using webApiTest.Model;

namespace webApiTest.Controllers;

// Sample hardcoded in-memory repo
public class DefaultJobDefinitionRepository : IJobDefinitionRepository
{
    public List<JobDefinition> _jobDefinitions;

    public DefaultJobDefinitionRepository()
    {
        _jobDefinitions = new List<JobDefinition>() { 
            new JobDefinition() 
            { 
                Source = "C://test/path/to/dll", 
                Name = "JobDef1", 
                Type = "NormalJob", 
                Parameters = new Dictionary<string, string>() },

            new JobDefinition() 
            {
                Source = "C://test/path/to/dll2",
                Name = "JobDef2",
                Type = "DelayedJob",
                Parameters = new Dictionary<string, string>() {
                    { "delay", "100"}
                } }
        };
    }

    public void Add(JobDefinition jobDefinition)
    {
        _jobDefinitions.Add(jobDefinition);
    }

    public JobDefinition? Get(string name)
    {
        return _jobDefinitions.FirstOrDefault(jd => jd.Name == name);
    }

    public IEnumerable<JobDefinition> GetAll()
    {
        return _jobDefinitions;
    }
}