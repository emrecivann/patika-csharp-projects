namespace ConsoleTodo;

public class BoardOperations : IBoardOperations
{
    public void ListTodoLine()
    {
        System.Console.WriteLine("To-do Line");
        System.Console.WriteLine("********************");
        if (Board.TodoList.Count == 0)
        {
            System.Console.WriteLine("To-do Line is empty\n");
        }
        else
        {
            foreach (var card in Board.TodoList)
            {
                System.Console.WriteLine($"Başlık: {card.Header}\nİçerik: {card.Content}\nAtanan Kişi: {card.TeamMember}\nBüyüklük: {card.Size}\n-");
            }
            System.Console.WriteLine();
        }
    }

    public void ListInProgessLine()
    {
        System.Console.WriteLine("In Progress Line");
        System.Console.WriteLine("********************");
        if (Board.InProgressList.Count == 0)
        {
            System.Console.WriteLine("In Progress Line is empty\n");
        }
        else
        {
            foreach (var card in Board.InProgressList)
            {
                System.Console.WriteLine($"Başlık: {card.Header}\nİçerik: {card.Content}\nAtanan Kişi: {card.TeamMember}\nBüyüklük: {card.Size}\n-");
            }
            System.Console.WriteLine();
        }
    }

    public void ListDoneLine()
    {
        System.Console.WriteLine("Done Line");
        System.Console.WriteLine("********************");
        if (Board.DoneList.Count == 0)
        {
            System.Console.WriteLine("Done Line is empty\n");
        }
        else
        {
            foreach (var card in Board.DoneList)
            {
                System.Console.WriteLine($"Başlık: {card.Header}\nİçerik: {card.Content}\nAtanan Kişi: {card.TeamMember}\nBüyüklük: {card.Size}\n-");
            }
            System.Console.WriteLine();
        }
    }
}