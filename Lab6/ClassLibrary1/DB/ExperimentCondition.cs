using ClassLibrary1.Abstractions;
using Newtonsoft.Json;

namespace ClassLibrary1.DB;

public sealed class ExperimentCondition
{ // в ExperimentCondition - это (колода, 36)
    
    public int ExperimentConditionId { get; set; }   // [1, 100]
    
    // конструктор по умолчанию
    public ExperimentCondition(List<ACard> cards)
    {
        Cards = cards;
    }

    public ExperimentCondition()
    {
    }

    // это нужно для связывания 
    // public int ShellDeckId { get; set; }   // вопрос
    // [JsonObject(IsReference = true)]
    [JsonIgnore]
    public ICollection<ACard> Cards { get; set; } // CardForExperiment

}
