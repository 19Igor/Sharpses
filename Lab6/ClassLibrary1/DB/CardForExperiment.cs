using ClassLibrary1.Abstractions;

namespace ClassLibrary1.DB;

public class CardForExperiment : ACard
{
    // этот класс будет работать с ShellDeck
    
    // public int CardForExperimentId { get; set; }

    public CardForExperiment(string color) : base(color)
    {
    }
    
    // конструктор по умолчанию      Здесь тоже может быть ошибка
    public CardForExperiment() : base(string.Empty)
    {
    }
}