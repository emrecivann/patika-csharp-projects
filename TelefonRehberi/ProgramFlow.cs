using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TelefonRehberi
{
    public class ProgramFlow
    {
        int choice;
        Operations operations = new();
        public void Flow()
        {
            do
            {
                System.Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
                System.Console.WriteLine("(0)Çıkış\n(1) Yeni Numara Kaydetmek \n(2) Varolan Numarayı Silmek \n(3) Varolan Numarayı Güncelleme \n(4) Rehberi Listelemek \n(5) Rehberde Arama Yapmak \n");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        System.Console.WriteLine("İşlem sonlandırılmıştır.");
                        return;
                    case 1:
                        operations.Add();
                        break;
                    case 2:
                        operations.Delete();
                        break;
                    case 3:
                        operations.Update();
                        break;
                    case 4:
                        operations.List();
                        break;
                    case 5:
                        operations.Search();
                        break;
                    default:
                        System.Console.WriteLine("Lütfen geçerli bir seçenek giriniz.");
                        Flow();
                        break;
                }
            } while (true);
        }
    }
}