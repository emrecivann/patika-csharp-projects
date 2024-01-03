using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace ConsoleTodo;

public class CardOperations : ICardOperations
{
    BoardOperations operations = new();
    public void Add()
    {
        System.Console.WriteLine("Başlık Giriniz:");
        string header = Console.ReadLine();
        System.Console.WriteLine("İçerik Giriniz:");
        string content = Console.ReadLine();
        System.Console.WriteLine("Büyüklük seçiniz => XS(1),S(2),M(3),L(4),XL(5):");
        Size size = (Size)Enum.Parse(typeof(Size), Console.ReadLine());
        System.Console.WriteLine("Kişi seçiniz:");
        int teamMemberKey = int.Parse(Console.ReadLine());

        Board.TodoList.Add(new Card
        {
            Header = header,
            Content = content,
            Size = size,
            TeamMember = TeamMembers.TeamMember[teamMemberKey]
        });
    }

    public void Delete()
    {
        System.Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız: ");
        string header = Console.ReadLine();

        // Check if the lists contain a Card object with the matching header
        bool cardExists = Board.TodoList.Any(card => card.Header == header) ||
                          Board.InProgressList.Any(card => card.Header == header) ||
                          Board.DoneList.Any(card => card.Header == header);

        if (cardExists)
        {
            // Card exists, perform deletion logic here
            Board.TodoList.RemoveAll(card => card.Header == header);
            Board.InProgressList.RemoveAll(card => card.Header == header);
            Board.DoneList.RemoveAll(card => card.Header == header);
            System.Console.WriteLine("Kart başarıyla silindi.");
        }
        else
        {
            System.Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            System.Console.WriteLine(" * Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
            string userChoice = Console.ReadLine();
            if (userChoice == "1") return;
            else if (userChoice == "2") Delete();
            else System.Console.WriteLine("Geçersiz input girişi yaptınız.");
        }
    }

    public void List()
    {
        operations.ListTodoLine();
        operations.ListInProgessLine();
        operations.ListDoneLine();
    }

    public void Move()
    {
        System.Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor. Lütfen kart başlığını yazınız: ");
        string header = Console.ReadLine();

        bool cardExists = Board.TodoList.Any(card => card.Header == header) ||
                         Board.DoneList.Any(card => card.Header == header) ||
                        Board.InProgressList.Any(card => card.Header == header);
        if (cardExists)
        {
            Card? movingCard;

            Card? todoListCard = Board.TodoList.FirstOrDefault(card => card.Header == header);
            Card? inProgressListCard = Board.InProgressList.FirstOrDefault(card => card.Header == header);
            Card? doneListCard = Board.DoneList.FirstOrDefault(card => card.Header == header);

            if (todoListCard is not null)
            {
                movingCard = todoListCard;
                Board.TodoList.Remove(todoListCard);
            }

            else if (inProgressListCard is not null)
            {
                movingCard = inProgressListCard;
                Board.InProgressList.Remove(inProgressListCard);
            }
            else
            {
                movingCard = doneListCard;
                Board.DoneList.Remove(doneListCard);
            }

            System.Console.WriteLine("Mevcut kartı hangi listeye taşımak istiyorsunuz?\n*To-do listesi için : (1)\nIn Progress listesi için : (2)\nDone listesi için : (3)\nİptal etmek için : (0)");
            string listNumber = Console.ReadLine();
            switch (listNumber)
            {
                case "0":
                    return;
                case "1":
                    Board.TodoList.Add(movingCard);
                    break;
                case "2":
                    Board.InProgressList.Add(movingCard);
                    break;
                case "3":
                    Board.DoneList.Add(movingCard);
                    break;
                default:
                    System.Console.WriteLine("Geçersiz input girişi yaptınız.");
                    break;
            }
        }
        else
        {
            System.Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            System.Console.WriteLine(" * Taşımayı sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
            string userChoice = Console.ReadLine();
            if (userChoice == "1") return;
            else if (userChoice == "2") Move();
            else System.Console.WriteLine("Geçersiz input girişi yaptınız.");
        }
    }
}