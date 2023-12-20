using ClassLibrary1.DB;
using ClassLibrary1.Implementations;
using Newtonsoft.Json;

namespace ClassLibrary1.Abstractions;

public abstract class ACard
{
    public int ACardId { get; set; }
    public string Color { get; set; }
    
    protected ACard(string color)
    {
        Color = color;
    }
    
    // связывание!
    [JsonIgnore]
    public int ExperimentConditionId { get; set; }
    [JsonIgnore]
    public ExperimentCondition? ExperimentCondition { get; set; }
    
}