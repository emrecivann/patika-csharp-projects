using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    public class Operations : IOperations
    {
        public void Add()
        {
            System.Console.WriteLine("Lütfen isim giriniz:");
            string name = Console.ReadLine();
            System.Console.WriteLine("Lütfen soyisim giriniz:");
            string surname = Console.ReadLine();
            System.Console.WriteLine("Lütfen telefon numarası giriniz:");
            string phoneNumber = Console.ReadLine();
            Storage.PhoneBook.Add(new Person
            {
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber
            });
        }

        public void Delete()
        {
            System.Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string nameOrSurname = Console.ReadLine();
            Person? nameSearch = Storage.PhoneBook.FirstOrDefault(NameOrSurname => NameOrSurname.Name.Equals(nameOrSurname));
            Person? surnameSearch = Storage.PhoneBook.FirstOrDefault(NameOrSurname => NameOrSurname.Surname.Equals(nameOrSurname));
            if (nameSearch == null && surnameSearch == null)
            {
                System.Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1) return;
                if (choice == 2) Delete();
            }
            else
            {
                Person deletePerson;
                if (surnameSearch is not null) deletePerson = surnameSearch;
                else deletePerson = nameSearch;

                System.Console.WriteLine($"{deletePerson.Name} {deletePerson.Surname} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)");
                string choice = Console.ReadLine();
                if (choice.ToLower().Trim() == "y")
                {
                    Storage.PhoneBook.Remove(deletePerson);
                }
                else if (choice.ToLower().Trim() == "n")
                {
                    return;
                }
                else
                {
                    System.Console.WriteLine("Lütfen 'y' veya 'n' karakterleriyle seçiminizi yapınız.");
                    Delete();
                }
            }
        }

        public void Update()
        {
            System.Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
            string nameOrSurname = Console.ReadLine();
            Person? nameSearch = Storage.PhoneBook.FirstOrDefault(NameOrSurname => NameOrSurname.Name.Equals(nameOrSurname));
            Person? surnameSearch = Storage.PhoneBook.FirstOrDefault(NameOrSurname => NameOrSurname.Surname.Equals(nameOrSurname));
            if (nameSearch == null && surnameSearch == null)
            {
                System.Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\n* Güncellemeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1) return;
                if (choice == 2) Update();
            }
            else
            {
                Person updatePerson;
                if (surnameSearch is not null) updatePerson = surnameSearch;
                else updatePerson = nameSearch;

                System.Console.WriteLine("Kişinin yeni ismini giriniz:");
                string newName = Console.ReadLine();
                System.Console.WriteLine("Kişinin yeni soyismini giriniz:");
                string newSurname = Console.ReadLine();
                System.Console.WriteLine("Kişinin yeni numarasını giriniz:");
                string newPhoneNumber = Console.ReadLine();
                updatePerson.Name = newName;
                updatePerson.Surname = newSurname;
                updatePerson.PhoneNumber = newPhoneNumber;

                System.Console.WriteLine("İşlem tamamlanmıştır");
            }
        }

        public void List()
        {
            System.Console.WriteLine("Telefon Rehberi");
            System.Console.WriteLine("******************");
            foreach (var person in Storage.PhoneBook)
            {
                System.Console.WriteLine($"İsim: {person.Name}\nSoyisim: {person.Surname} \nTelefon Numarası:{person.PhoneNumber}\n");
            }
        }

        public void Search()
        {
            System.Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            System.Console.WriteLine("*****************************************");
            System.Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)\nTelefon numarasına göre arama yapmak için: (2)");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                System.Console.WriteLine("Lütfen rehberde aramak istediğiniz kişinin adını ya da soyadını giriniz:");
                string nameOrSurname = Console.ReadLine();
                Person? nameSearch = Storage.PhoneBook.FirstOrDefault(NameOrSurname => NameOrSurname.Name.Equals(nameOrSurname));
                Person? surnameSearch = Storage.PhoneBook.FirstOrDefault(NameOrSurname => NameOrSurname.Surname.Equals(nameOrSurname));
                if (nameSearch == null && surnameSearch == null)
                {
                    System.Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\n* Aramayı sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                    int choice2 = int.Parse(Console.ReadLine());
                    if (choice2 == 1) return;
                    if (choice2 == 2) Search();
                }
                else
                {
                    Person searchPerson;
                    if (nameSearch is not null)
                    {
                        searchPerson = nameSearch;
                        foreach (var person in Storage.PhoneBook)
                        {
                            if (person.Name == nameOrSurname)
                            {
                                System.Console.WriteLine($"İsim: {person.Name}\nSoyisim:{person.Surname}\nTelefon Numarası:{person.PhoneNumber}");
                            }
                        }
                    }
                    else if (surnameSearch is not null)
                    {
                        searchPerson = surnameSearch;
                        foreach (var person in Storage.PhoneBook)
                        {
                            if (person.Surname == nameOrSurname)
                            {
                                System.Console.WriteLine($"İsim: {person.Name}\nSoyisim:{person.Surname}\nTelefon Numarası:{person.PhoneNumber}");
                            }
                        }
                    }
                    System.Console.WriteLine("Arama sonuçlarınız");
                    System.Console.WriteLine("*********************");

                }
            }
            else if (choice == "2")
            {
                System.Console.WriteLine("Lütfen rehberdearamak istediğiniz kişinin telefon numarasını giriniz:");
                string phoneNumber = Console.ReadLine();
                Person? phoneNumberSearch = Storage.PhoneBook.FirstOrDefault(NameOrSurname => NameOrSurname.PhoneNumber.Equals(phoneNumber));
                if (phoneNumberSearch is not null)
                {
                    System.Console.WriteLine("Arama sonuçlarınız");
                    System.Console.WriteLine("*********************");
                    foreach (var person in Storage.PhoneBook)
                    {
                        if (person.PhoneNumber == phoneNumber)
                        {
                            System.Console.WriteLine($"İsim: {person.Name}\nSoyisim:{person.Surname}\nTelefon Numarası:{person.PhoneNumber}");
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\n* Aramayı sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                    int choice2 = int.Parse(Console.ReadLine());
                    if (choice2 == 1) return;
                    if (choice2 == 2) Search();
                }
            }
            else
            {
                System.Console.WriteLine("Lütfen arama kriterini seçmek için '1' veya '2' giriniz. \nÇıkmak için '0' giriniz. \nYeniden aramak için herhangi bir tuşa basınız.");
                string terminateOrContinue = Console.ReadLine();
                if (terminateOrContinue is "0") return;
                else Search();
            }
        }
    }
}