using System;

namespace CW.Services
{
    internal class HistoryEntry
    {
        public string Url { get; internal set; }
        public DateTime VisitedOn { get; internal set; }
    }
}