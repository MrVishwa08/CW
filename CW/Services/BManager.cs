using CW.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BookmarkManager
{
    private List<Bookmark> bookmarks;
    private readonly string filePath = "bookmarks.txt";

    public BookmarkManager()
    {
        bookmarks = new List<Bookmark>();
        LoadBookmarks();
    }

    public void AddBookmark(string name, string url)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(url))
            return;

        // Prevent duplicate names
        if (bookmarks.Any(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            return;

        bookmarks.Add(new Bookmark { Name = name.Trim(), Url = url.Trim() });
        SaveBookmarks();
    }

    public void DeleteBookmark(string name)
    {
        var bookmark = bookmarks.FirstOrDefault(b =>
            b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (bookmark != null)
        {
            bookmarks.Remove(bookmark);
            SaveBookmarks();
        }
    }

    public List<Bookmark> GetAllBookmarks()
    {
        return bookmarks;
    }

    private void LoadBookmarks()
    {
        bookmarks.Clear();
        if (!File.Exists(filePath)) return;

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split('|');
            if (parts.Length == 2)
            {
                bookmarks.Add(new Bookmark { Name = parts[0], Url = parts[1] });
            }
        }
    }

    private void SaveBookmarks()
    {
        File.WriteAllLines(filePath, bookmarks.Select(b => $"{b.Name}|{b.Url}"));
    }
}
