using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleTodo.Models;

namespace SimpleTodo.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "🐱 のご飯を買う", Description="This is an item description.", DueDate = DateTimeOffset.UtcNow.AddDays(0) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." ,DueDate = DateTimeOffset.UtcNow.AddDays(2)},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description.", DueDate = DateTimeOffset.UtcNow.AddDays(3) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description.", DueDate = DateTimeOffset.UtcNow.AddDays(5) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description.", DueDate = DateTimeOffset.UtcNow.AddDays(7) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description.", DueDate = DateTimeOffset.UtcNow.AddDays(10) },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}