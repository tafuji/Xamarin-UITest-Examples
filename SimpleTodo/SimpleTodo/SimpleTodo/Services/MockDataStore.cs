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
                new Item { Id = Guid.NewGuid().ToString(), Text = "🐱 のご飯を買う", Description="カリカリを買う 😸", DueDate = DateTime.UtcNow.AddDays(0) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "テスト 📝 勉強をする", Description="数学で 💯 取れるように頑張る" ,DueDate = DateTime.UtcNow.AddDays(2)},
                new Item { Id = Guid.NewGuid().ToString(), Text = "病院 🏥 に行く", Description="肩こりがはげしい", DueDate = DateTime.UtcNow.AddDays(3) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ATM 🏧 でお金 💴 をおろす", Description="", DueDate = DateTime.UtcNow.AddDays(5) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "自転車 🚲 の空気を入れる", Description="朝 🌅 のうちにやっておく", DueDate = DateTime.UtcNow.AddDays(7) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ジムで 筋トレ 💪 をする", Description="ジョギング 🏃 もしたい", DueDate = DateTime.UtcNow.AddDays(10) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "お米を買う", Description="", DueDate = DateTime.UtcNow.AddDays(0) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "病院 🏥 に行く", Description="肩こりがはげしい", DueDate = DateTime.UtcNow.AddDays(3) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ジムで 筋トレ 💪 をする", Description="ジョギング 🏃 もしたい", DueDate = DateTime.UtcNow.AddDays(10) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ご飯を買う", Description="", DueDate = DateTime.UtcNow.AddDays(0) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ラーメン 🍜 を食べに行く", Description="🚉 駅前のラーメン店", DueDate = DateTime.UtcNow.AddDays(0) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "牛乳を買う", Description="🏪 コンビニによる", DueDate = DateTime.UtcNow.AddDays(0) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "テスト 📝 勉強をする", Description="数学で 💯 取れるように頑張る" ,DueDate = DateTime.UtcNow.AddDays(2)},
                new Item { Id = Guid.NewGuid().ToString(), Text = "本 📚 を買う", Description="技術書を買う", DueDate = DateTime.UtcNow.AddDays(0) },
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