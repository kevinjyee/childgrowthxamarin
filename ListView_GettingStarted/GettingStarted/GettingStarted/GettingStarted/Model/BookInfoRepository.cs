using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted
{
    public class BookInfoRepository
    {
        private ObservableCollection<BookInfo> bookInfo;

        #region Properties

        public ObservableCollection<BookInfo> BookInfo
        {
            get { return bookInfo; }
            set { this.bookInfo = value; }
        }

        #endregion

        #region Constructor

        public BookInfoRepository()
        {
            GenerateBookInfo();
        }

        #endregion

        #region Properties

        internal void GenerateBookInfo()
        {
            bookInfo = new ObservableCollection<BookInfo>();
            bookInfo.Add(new BookInfo() { BookName = "Object-Oriented Programming in C#", BookDescription = "Object-oriented programming is the de facto programming paradigm" });
            bookInfo.Add(new BookInfo() { BookName = "C# Code Contracts", BookDescription = "Code Contracts provide a way to convey code assumptions" });
            bookInfo.Add(new BookInfo() { BookName = "Machine Learning Using C#", BookDescription = "You’ll learn several different approaches to applying machine learning" });
            bookInfo.Add(new BookInfo() { BookName = "Neural Networks Using C#", BookDescription = "Neural networks are an exciting field of software development" });
            bookInfo.Add(new BookInfo() { BookName = "Visual Studio Code", BookDescription = "It is a powerful tool for editing code and serves for end-to-end programming" });
            bookInfo.Add(new BookInfo() { BookName = "Android Programming", BookDescription = "It is provides a useful overview of the Android application lifecycle" });
            bookInfo.Add(new BookInfo() { BookName = "iOS Succinctly", BookDescription = "It is for developers looking to step into frightening world of iPhone" });
            bookInfo.Add(new BookInfo() { BookName = "Visual Studio 2015", BookDescription = "The new version of the widely-used integrated development environment" });
            bookInfo.Add(new BookInfo() { BookName = "Xamarin.Forms", BookDescription = "Its creates mappings from its C# classes and controls directly" });
            bookInfo.Add(new BookInfo() { BookName = "Windows Store Apps", BookDescription = "Windows Store apps present a radical shift in Windows development" });
            bookInfo.Add(new BookInfo() { BookName = "Agile Software Development", BookDescription = "Learning new development processes can be difficult" });
            bookInfo.Add(new BookInfo() { BookName = "Assembly Language", BookDescription = "Assembly language is as close to writing machine code" });
            bookInfo.Add(new BookInfo() { BookName = "Cryptography in .NET", BookDescription = "Cryptography is used throughout software to protect all kinds of information" });
            bookInfo.Add(new BookInfo() { BookName = "Entity Framework Code First", BookDescription = "Follow author Ricardo Peres as he introduces the newest development mode" });
            bookInfo.Add(new BookInfo() { BookName = "Localization for .NET", BookDescription = "Learn to write applications that support different languages and cultures" });
        }

        #endregion
    }
}
