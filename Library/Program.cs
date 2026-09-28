
using System;
using System.Collections.Generic;

// Suggested and coded by ChatGPT
namespace Library
{
    internal class Program
    {
        private static readonly Library library = new Library();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("       LIBRARY MANAGEMENT SYSTEM");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.WriteLine("1. Books");
                Console.WriteLine("2. Authors");
                Console.WriteLine("3. Members");
                Console.WriteLine("4. Borrow / Return");
                Console.WriteLine("5. Exit");
                Console.WriteLine();

                int choice = ReadInt("Select an option: ");

                switch (choice)
                {
                    case 1:
                        BooksMenu();
                        break;

                    case 2:
                        AuthorsMenu();
                        break;

                    case 3:
                        MembersMenu();
                        break;

                    case 4:
                        BorrowReturnMenu();
                        break;

                    case 5:
                        return;

                    default:
                        ShowMessage("Invalid option.");
                        break;
                }
            }
        }

        // =========================
        // BOOKS
        // =========================

        private static void BooksMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============== BOOKS ===============");
                Console.WriteLine();
                Console.WriteLine("1. List all books");
                Console.WriteLine("2. Add book");
                Console.WriteLine("3. Remove book");
                Console.WriteLine("4. View book details");
                Console.WriteLine("5. Back");
                Console.WriteLine();

                int choice = ReadInt("Select an option: ");

                switch (choice)
                {
                    case 1:
                        ListBooks();
                        break;

                    case 2:
                        AddBook();
                        break;

                    case 3:
                        RemoveBook();
                        break;

                    case 4:
                        ViewBookDetails();
                        break;

                    case 5:
                        return;

                    default:
                        ShowMessage("Invalid option.");
                        break;
                }
            }
        }

        private static void ListBooks()
        {
            Console.Clear();
            Console.WriteLine("=============== BOOKS ===============");
            Console.WriteLine();

            List<Book> books = library.GetBooks();

            if (books.Count == 0)
            {
                ShowMessage("There are no books.");
                return;
            }

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. {books[i].GetName()} | " +
                    $"{books[i].GetAuthor().GetName()} | " +
                    $"{books[i].GetBookType()}");
            }

            Pause();
        }

        private static void AddBook()
        {
            Console.Clear();
            Console.WriteLine("=============== ADD BOOK ===============");
            Console.WriteLine();

            List<Author> authors = library.GetAuthors();

            if (authors.Count == 0)
            {
                ShowMessage("You must add an author first.");
                return;
            }

            string name = ReadString("Book name: ");
            int year = ReadInt("Publication year: ");

            Author author = SelectAuthor();

            if (author == null)
                return;

            BookType type = SelectBookType();

            try
            {
                Book book = new Book(name, year, author, type);
                library.AddBook(book);

                ShowMessage("Book added successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error: {ex.Message}");
            }
        }

        private static void RemoveBook()
        {
            Console.Clear();
            Console.WriteLine("============= REMOVE BOOK =============");
            Console.WriteLine();

            Book book = SelectBook();

            if (book == null)
                return;

            try
            {
                library.RemoveBook(book);

                ShowMessage("Book removed successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error: {ex.Message}");
            }
        }

        private static void ViewBookDetails()
        {
            Console.Clear();
            Console.WriteLine("=========== BOOK DETAILS ===========");
            Console.WriteLine();

            Book book = SelectBook();

            if (book == null)
                return;

            Console.WriteLine(book);
            Pause();
        }

        // =========================
        // AUTHORS
        // =========================

        private static void AuthorsMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("============== AUTHORS ==============");
                Console.WriteLine();
                Console.WriteLine("1. List all authors");
                Console.WriteLine("2. Add author");
                Console.WriteLine("3. Remove author");
                Console.WriteLine("4. View author details");
                Console.WriteLine("5. Manage awards");
                Console.WriteLine("6. Back");
                Console.WriteLine();

                int choice = ReadInt("Select an option: ");

                switch (choice)
                {
                    case 1:
                        ListAuthors();
                        break;

                    case 2:
                        AddAuthor();
                        break;

                    case 3:
                        RemoveAuthor();
                        break;

                    case 4:
                        ViewAuthorDetails();
                        break;

                    case 5:
                        ManageAwards();
                        break;

                    case 6:
                        return;

                    default:
                        ShowMessage("Invalid option.");
                        break;
                }
            }
        }

        private static void ListAuthors()
        {
            Console.Clear();
            Console.WriteLine("============== AUTHORS ==============");
            Console.WriteLine();

            List<Author> authors = library.GetAuthors();

            if (authors.Count == 0)
            {
                ShowMessage("There are no authors.");
                return;
            }

            for (int i = 0; i < authors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {authors[i].GetName()}");
            }

            Pause();
        }

        private static void AddAuthor()
        {
            Console.Clear();
            Console.WriteLine("============= ADD AUTHOR =============");
            Console.WriteLine();

            string name = ReadString("Name: ");
            int birthYear = ReadInt("Birth year: ");
            string nationality = ReadString("Nationality: ");
            Gender gender = SelectGender();

            try
            {
                Author author = new Author(
                    name,
                    birthYear,
                    nationality,
                    gender);

                library.AddAuthor(author);

                ShowMessage("Author added successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error: {ex.Message}");
            }
        }

        private static void RemoveAuthor()
        {
            Console.Clear();
            Console.WriteLine("=========== REMOVE AUTHOR ===========");
            Console.WriteLine();

            Author author = SelectAuthor();

            if (author == null)
                return;

            try
            {
                library.RemoveAuthor(author);

                ShowMessage("Author removed successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error: {ex.Message}");
            }
        }

        private static void ViewAuthorDetails()
        {
            Console.Clear();
            Console.WriteLine("========== AUTHOR DETAILS ==========");
            Console.WriteLine();

            Author author = SelectAuthor();

            if (author == null)
                return;

            Console.WriteLine(author);
            Console.WriteLine();

            List<Book> writtenBooks = author.GetWrittenBooks();

            if (writtenBooks.Count > 0)
            {
                Console.WriteLine("Books:");

                foreach (Book book in writtenBooks)
                {
                    Console.WriteLine($"- {book.GetName()}");
                }
            }

            Pause();
        }

        private static void ManageAwards()
        {
            Console.Clear();
            Console.WriteLine("=========== MANAGE AWARDS ===========");
            Console.WriteLine();

            Author author = SelectAuthor();

            if (author == null)
                return;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Author: {author.GetName()}");
                Console.WriteLine();
                Console.WriteLine("1. List awards");
                Console.WriteLine("2. Add award");
                Console.WriteLine("3. Remove award");
                Console.WriteLine("4. Remove all awards");
                Console.WriteLine("5. Back");
                Console.WriteLine();

                int choice = ReadInt("Select an option: ");

                switch (choice)
                {
                    case 1:
                        Console.Clear();

                        List<string> awards = author.GetAwards();

                        if (awards.Count == 0)
                        {
                            Console.WriteLine("No awards.");
                        }
                        else
                        {
                            foreach (string award in awards)
                            {
                                Console.WriteLine($"- {award}");
                            }
                        }

                        Pause();
                        break;

                    case 2:
                        string awardToAdd = ReadString("Award name: ");

                        try
                        {
                            author.AddAward(awardToAdd);
                            ShowMessage("Award added successfully.");
                        }
                        catch (Exception ex)
                        {
                            ShowMessage($"Error: {ex.Message}");
                        }

                        break;

                    case 3:
                        string awardToRemove = ReadString("Award name: ");

                        try
                        {
                            author.RemoveAward(awardToRemove);
                            ShowMessage("Award removed.");
                        }
                        catch (Exception ex)
                        {
                            ShowMessage($"Error: {ex.Message}");
                        }

                        break;

                    case 4:
                        author.RemoveAllAwards();
                        ShowMessage("All awards removed.");
                        break;

                    case 5:
                        return;

                    default:
                        ShowMessage("Invalid option.");
                        break;
                }
            }
        }

        // =========================
        // MEMBERS
        // =========================

        private static void MembersMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("============== MEMBERS ==============");
                Console.WriteLine();
                Console.WriteLine("1. List all members");
                Console.WriteLine("2. Add member");
                Console.WriteLine("3. Remove member");
                Console.WriteLine("4. View member details");
                Console.WriteLine("5. Change membership type");
                Console.WriteLine("6. Change membership status");
                Console.WriteLine("7. Back");
                Console.WriteLine();

                int choice = ReadInt("Select an option: ");

                switch (choice)
                {
                    case 1:
                        ListMembers();
                        break;

                    case 2:
                        AddMember();
                        break;

                    case 3:
                        RemoveMember();
                        break;

                    case 4:
                        ViewMemberDetails();
                        break;

                    case 5:
                        ChangeMembershipType();
                        break;

                    case 6:
                        ChangeMembershipStatus();
                        break;

                    case 7:
                        return;

                    default:
                        ShowMessage("Invalid option.");
                        break;
                }
            }
        }

        private static void ListMembers()
        {
            Console.Clear();
            Console.WriteLine("============== MEMBERS ==============");
            Console.WriteLine();

            List<LibraryMember> members = library.GetMembers();

            if (members.Count == 0)
            {
                ShowMessage("There are no members.");
                return;
            }

            for (int i = 0; i < members.Count; i++)
            {
                LibraryMember member = members[i];

                Console.WriteLine(
                    $"{i + 1}. {member.GetName()} | " +
                    $"{member.GetMembershipType()} | " +
                    $"{member.GetMembershipStatus()}");
            }

            Pause();
        }

        private static void AddMember()
        {
            Console.Clear();
            Console.WriteLine("============= ADD MEMBER =============");
            Console.WriteLine();

            string name = ReadString("Name: ");
            int birthYear = ReadInt("Birth year: ");
            string nationality = ReadString("Nationality: ");
            Gender gender = SelectGender();
            int joinYear = ReadInt("Join year: ");
            MembershipType type = SelectMembershipType();
            MembershipStatus status = SelectMembershipStatus();

            try
            {
                LibraryMember member = new LibraryMember(
                    name,
                    birthYear,
                    nationality,
                    gender,
                    joinYear,
                    type,
                    status);

                library.AddMember(member);

                ShowMessage("Member added successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error: {ex.Message}");
            }
        }

        private static void RemoveMember()
        {
            Console.Clear();
            Console.WriteLine("=========== REMOVE MEMBER ===========");
            Console.WriteLine();

            LibraryMember member = SelectMember();

            if (member == null)
                return;

            try
            {
                library.RemoveMember(member);

                ShowMessage("Member removed successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error: {ex.Message}");
            }
        }

        private static void ViewMemberDetails()
        {
            Console.Clear();
            Console.WriteLine("========== MEMBER DETAILS ==========");
            Console.WriteLine();

            LibraryMember member = SelectMember();

            if (member == null)
                return;

            Console.WriteLine($"Name: {member.GetName()}");
            Console.WriteLine($"Birth Year: {member.GetBirthYear()}");
            Console.WriteLine($"Age: {member.GetAge()}");
            Console.WriteLine($"Nationality: {member.GetNationality()}");
            Console.WriteLine($"Gender: {member.GetGender()}");
            Console.WriteLine($"Join Year: {member.GetJoinYear()}");
            Console.WriteLine($"Membership Type: {member.GetMembershipType()}");
            Console.WriteLine($"Membership Status: {member.GetMembershipStatus()}");
            Console.WriteLine(
                $"Borrowed Books: {member.GetBorrowedBooksNumber()} / {member.GetMaxBorrowedBooks()}");

            Pause();
        }

        private static void ChangeMembershipType()
        {
            Console.Clear();
            Console.WriteLine("======= CHANGE MEMBERSHIP TYPE =======");
            Console.WriteLine();

            LibraryMember member = SelectMember();

            if (member == null)
                return;

            MembershipType type = SelectMembershipType();

            try
            {
                member.SetMembershipType(type);
                ShowMessage("Membership type changed successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error: {ex.Message}");
            }
        }

        private static void ChangeMembershipStatus()
        {
            Console.Clear();
            Console.WriteLine("====== CHANGE MEMBERSHIP STATUS ======");
            Console.WriteLine();

            LibraryMember member = SelectMember();

            if (member == null)
                return;

            MembershipStatus status = SelectMembershipStatus();

            try
            {
                member.SetMembershipStatus(status);
                ShowMessage("Membership status changed successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error: {ex.Message}");
            }
        }

        // =========================
        // BORROW / RETURN
        // =========================

        private static void BorrowReturnMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== BORROW / RETURN ==========");
                Console.WriteLine();
                Console.WriteLine("1. Borrow a book");
                Console.WriteLine("2. Return a book");
                Console.WriteLine("3. Return all books");
                Console.WriteLine("4. Back");
                Console.WriteLine();

                int choice = ReadInt("Select an option: ");

                switch (choice)
                {
                    case 1:
                        BorrowBook();
                        break;

                    case 2:
                        ReturnBook();
                        break;

                    case 3:
                        ReturnAllBooks();
                        break;

                    case 4:
                        return;

                    default:
                        ShowMessage("Invalid option.");
                        break;
                }
            }
        }

        private static void BorrowBook()
        {
            Console.Clear();
            Console.WriteLine("============= BORROW BOOK =============");
            Console.WriteLine();

            LibraryMember member = SelectMember();

            if (member == null)
                return;

            Book book = SelectBook();

            if (book == null)
                return;

            try
            {
                member.BorrowBook(book);
                ShowMessage("Book borrowed successfully.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Error: {ex.Message}");
            }
        }

        private static void ReturnBook()
        {
            Console.Clear();
            Console.WriteLine("============= RETURN BOOK =============");
            Console.WriteLine();

            LibraryMember member = SelectMember();

            if (member == null)
                return;

            List<Book> borrowedBooks = member.GetBorrowedBooks();

            if (borrowedBooks.Count == 0)
            {
                ShowMessage("This member has no borrowed books.");
                return;
            }

            Console.WriteLine("Borrowed books:");
            Console.WriteLine();

            for (int i = 0; i < borrowedBooks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {borrowedBooks[i].GetName()}");
            }

            Console.WriteLine();

            int choice = ReadInt("Select a book: ");

            if (choice < 1 || choice > borrowedBooks.Count)
            {
                ShowMessage("Invalid selection.");
                return;
            }

            member.ReturnBook(borrowedBooks[choice - 1]);

            ShowMessage("Book returned successfully.");
        }

        private static void ReturnAllBooks()
        {
            Console.Clear();
            Console.WriteLine("=========== RETURN ALL BOOKS ===========");
            Console.WriteLine();

            LibraryMember member = SelectMember();

            if (member == null)
                return;

            member.ReturnAllBook();

            ShowMessage("All books returned.");
        }

        // =========================
        // SELECTION HELPERS
        // =========================

        private static Author SelectAuthor()
        {
            List<Author> authors = library.GetAuthors();

            if (authors.Count == 0)
            {
                ShowMessage("There are no authors.");
                return null;
            }

            Console.WriteLine("Select an author:");
            Console.WriteLine();

            for (int i = 0; i < authors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {authors[i].GetName()}");
            }

            Console.WriteLine();

            int choice = ReadInt("Author: ");

            if (choice < 1 || choice > authors.Count)
            {
                ShowMessage("Invalid selection.");
                return null;
            }

            return authors[choice - 1];
        }

        private static Book SelectBook()
        {
            List<Book> books = library.GetBooks();

            if (books.Count == 0)
            {
                ShowMessage("There are no books.");
                return null;
            }

            Console.WriteLine("Select a book:");
            Console.WriteLine();

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i].GetName()}");
            }

            Console.WriteLine();

            int choice = ReadInt("Book: ");

            if (choice < 1 || choice > books.Count)
            {
                ShowMessage("Invalid selection.");
                return null;
            }

            return books[choice - 1];
        }

        private static LibraryMember SelectMember()
        {
            List<LibraryMember> members = library.GetMembers();

            if (members.Count == 0)
            {
                ShowMessage("There are no members.");
                return null;
            }

            Console.WriteLine("Select a member:");
            Console.WriteLine();

            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {members[i].GetName()}");
            }

            Console.WriteLine();

            int choice = ReadInt("Member: ");

            if (choice < 1 || choice > members.Count)
            {
                ShowMessage("Invalid selection.");
                return null;
            }

            return members[choice - 1];
        }

        private static Gender SelectGender()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Male");
                Console.WriteLine("2. Female");

                int choice = ReadInt("Gender: ");

                if (choice == 1)
                    return Gender.Male;

                if (choice == 2)
                    return Gender.Female;

                Console.WriteLine("Invalid selection.");
            }
        }

        private static BookType SelectBookType()
        {
            BookType[] types = Enum.GetValues<BookType>();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Book type:");

                for (int i = 0; i < types.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {types[i]}");
                }

                int choice = ReadInt("Type: ");

                if (choice >= 1 && choice <= types.Length)
                    return types[choice - 1];

                Console.WriteLine("Invalid selection.");
            }
        }

        private static MembershipType SelectMembershipType()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Free");
                Console.WriteLine("2. Paid");

                int choice = ReadInt("Membership type: ");

                if (choice == 1)
                    return MembershipType.Free;

                if (choice == 2)
                    return MembershipType.Paid;

                Console.WriteLine("Invalid selection.");
            }
        }

        private static MembershipStatus SelectMembershipStatus()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Active");
                Console.WriteLine("2. Passive");

                int choice = ReadInt("Membership status: ");

                if (choice == 1)
                    return MembershipStatus.Active;

                if (choice == 2)
                    return MembershipStatus.Passive;

                Console.WriteLine("Invalid selection.");
            }
        }

        // =========================
        // INPUT HELPERS
        // =========================

        private static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Please enter a valid number.");
            }
        }

        private static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Input cannot be empty.");
            }
        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}