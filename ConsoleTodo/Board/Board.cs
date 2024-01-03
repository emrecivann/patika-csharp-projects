namespace ConsoleTodo;

public static class Board
{
    public static List<Card> TodoList { get; set; }
    public static List<Card> InProgressList { get; set; }
    public static List<Card> DoneList { get; set; }

    static Board()
    {
        TodoList = new List<Card>();
        InProgressList = new List<Card>();
        DoneList = new List<Card>();
    }
}