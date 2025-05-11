# 📚 Library Management System

A console-based C# application that allows library staff to manage books, members, loans, and reviews. It uses a multi-layer architecture (UI, Service, Repository, Model).

---

## ✅ Features

* Add, update, delete, and view books
* Borrow and return books
* Add and delete book reviews
* View all books borrowed/returned by a member
* View all reviews of a specific book
* Search for books using given filters (title, author)
* JSON-based file persistence (not currently working)
* Simple console UI

---

## New Functionality Development

### Book Review System

As an enhancement to the core library system, a book review feature has been introduced. This allows members to share feedback and rate the books they have borrowed. The system includes the following capabilities:

- **Add Review**: Members can rate a book (1 to 5 stars) and write a textual review ONLY after borrowing and returning it.
- **Delete Review**: Members can delete their ONLY own reviews.
- **View Reviews**: All reviews associated with a book can be viewed.
- **Member Review History**: A member’s personal review history can be retrieved and displayed.

This addition improves user engagement and provides insights into book popularity and member preferences.

---

## 🛠 Requirements

* [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) or later
* IDE: Visual Studio / JetBrains Rider / Visual Studio Code

---

## 📁 Project Structure

```
LibraryManagementSystem/
│
├── Model/              # Domain models: Book, Member, Staff, Loan, Review
├── Repository/         # IRepository<T> interface, InMemoryRepository<T> and FileRepository<T>
├── Service/            # Business logic (LibraryService.cs)
├── UI/                 # Console UI (LibraryUI.cs)
├── Program.cs          # Entry point
├── README.md           # Project instructions
```

---

## ⚙️ Configuration Steps

1. **Clone the Repository**

   ```bash
   git clone https://github.com/mihaivaidos/SiemensDotNetProblem.git
   cd SiemensDotNetProblem
   ```

2. **Open the Project**

   Open the folder using your preferred IDE (Visual Studio / Rider / VS Code).

3. **Build the Project**

   * In Visual Studio / Rider: `Build → Build Solution`
   * Or in terminal:

     ```bash
     dotnet build
     ```

---

## ▶️ How to Run

### Option 1: Using IDE (Visual Studio / Rider)

* Set `Program.cs` as the startup project
* Run the project (F5 or Run button)

### Option 2: Using .NET CLI

```bash
dotnet run
```

---

## 🧯 Application Navigation

```
=== Library Management System ===
1. Manage Books
2. Manage Members
3. Borrow a book
4. Return a book
5. Review a book
6. Delete a review
7. View the reviews of a book
8. Search books by title
9. View member's active loans
10. View member's loan history
0. Exit
```

Book Management Menu:

```
=== Manage Books ===
1. Add Book
2. Update Book
3. Delete Book
4. View All Books
5. Back to Main Menu
```

---

## 💾 Data Persistence (NOT WORKING)

All data is saved automatically in the files using JSON serialization. The application uses a generic `FileRepository<T>` that implements `IRepository<T>` for all models.

---

## 🧪 Example Use Cases

* Borrow a book
* Return a loan
* Add reviews and delete them
* View books by title or by author
* See all activity for a specific member (borrows, returns, reviews)

---

## ❓ Troubleshooting

* **Missing `Data` folder?** It is not currently available because of the problems with the FileRepository and Data persistance (lack of experience in C#)
* **Input errors?** Make sure all inputs are the correct type.

---
