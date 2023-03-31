namespace webApiTest.Model;

/**
 * Model Properties need to be {get; set;} 
 * para ma automatically serialize ng WebAPI controllers
 * literal DTO
 */
public class JobDefinition
{
    public string? Source { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public Dictionary<string, string>? Parameters { get; set; }
}
