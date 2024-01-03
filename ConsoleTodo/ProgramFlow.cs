namespace ConsoleTodo;

public class ProgramFlow
{
    CardOperations operations = new();
    public void Flow()
    {
        do
        {
            System.Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz: ");
            System.Console.WriteLine("*******************************************");
            System.Console.WriteLine("(1) Board Listelemek \n(2) Board'a Kart Eklemek \n(3) Board'dan Kart Silmek \n(4) Kart Taşımak \n(0) Çıkış");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                    System.Console.WriteLine("Uygulamadan çıkılıyor.");
                    return;
                case "1":
                    operations.List();
                    break;
                case "2":
                    operations.Add();
                    break;
                case "3":
                    operations.Delete();
                    break;
                case "4":
                    operations.Move();
                    break;
                default:
                    System.Console.WriteLine("Geçersiz karakter girdiniz, lütfen tekrar deneyin.");
                    Flow();
                    break;
            }
        } while (true);
    }
}