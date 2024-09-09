using MyStore_Entity_Week4.Models;

namespace MyStore_Entity_Week4.ViewModels
{
    public class ItemsViewModel(IEnumerable<Item> items, string? currentViewName)
    {
        public IEnumerable<Item> Items = items;
        public string? CurrentViewName = currentViewName;
    }
}