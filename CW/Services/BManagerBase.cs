using CW.Models;
using System.Collections.Generic;

namespace CW.Services
{
    public class BManagerBase
    {
        protected List<Bookmark> _bookmarks = new List<Bookmark>();

        // Retrieve all bookmarks
        public List<Bookmark> GetAllBookmarks()
        {
            return _bookmarks;
        }
    }
}