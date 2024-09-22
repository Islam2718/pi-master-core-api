using System.Collections.Generic;

namespace MyApiProject.Services
{
    public class PageService
    {
        private readonly List<string> pages = new List<string>
        {
            "Home", "About", "Privacy Policy"
        };

        public IEnumerable<string> GetPages() => pages;

        public string? GetPageById(int id) => (id >= 0 && id < pages.Count) ? pages[id] : null;

        public void AddPage(string page) => pages.Add(page);

        public void DeletePage(int id)
        {
            if (id >= 0 && id < pages.Count)
            {
                pages.RemoveAt(id);
            }
        }
    }
}
