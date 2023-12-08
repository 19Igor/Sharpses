using ClassLibrary1.Abstractions;

namespace ClassLibrary1.DB;

public class CardForExperiment : ACard
{
    // этот класс будет работать с ShellDeck
    
    // возможно здесь будет ругаться на то, что Id уже указал в родительском классе 
    // public int CardForExperimentId { get; set; }

    public CardForExperiment(string color) : base(color)
    {
    }
    
    // конструктор по умолчанию      Здесь тоже может быть ошибка
    public CardForExperiment() : base(string.Empty)
    {
    }
    
    // связывание
    // public int ExperimentConditionId { get; set; }
    // public ExperimentCondition ExperimentCondition { get; set; }
}