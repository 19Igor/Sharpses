using ClassLibrary1.Abstractions;

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
    public ICollection<ACard> Cards { get; set; } // CardForExperiment

}


// изначально
// не понимаю, зачем нужна *RefId To ExperimentCondition.
// 1. ExperimentCondition(ID, List<CardForExperiment>)
// 2. CardForExperiment(Number, Color, *RefId To ExperimentCondition) - видимо, представления в бд
