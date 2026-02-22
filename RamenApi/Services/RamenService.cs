using RamenApi.Models;
using System.Text.Json;

namespace RamenApi.Services
{
    public class RamenService
    {
        private List<Ramen> _ramens;

        public RamenService()
        {
            LoadData();
        }

        private void LoadData()
        {
            _ramens = new List<Ramen>
    {
        new Ramen { Id = "1", Name = "Beef Ramen", Sale = false, Price = 19.99m, Photo = "https://www.elmundoeats.com/wp-content/uploads/2021/02/FP-Quick-30-minutes-chicken-ramen.jpg", Category = new List<string> { "popular", "all" } },
        new Ramen { Id = "2", Name = "Chicken Ramen", Sale = false, Price = 20.99m, Photo = "https://www.tablefortwoblog.com/wp-content/uploads/2022/02/beef-ramen-noodle-soup-photo-tablefortwoblog-3-scaled.jpg", Category = new List<string> { "popular", "all" } },
        new Ramen { Id = "3", Name = "Vegetarian Ramen", Sale = false, Price = 16.99m, Photo = "https://www.modernhoney.com/wp-content/uploads/2024/01/Homemade-Chicken-Ramen-1-crop-scaled.jpg", Category = new List<string> { "popular", "vegetarian", "all" } },
        new Ramen { Id = "4", Name = "Mohito Ramen", Sale = false, Price = 18.99m, Photo = "https://pinchofyum.com/wp-content/uploads/Coconut-Curry-Ramen-Square.jpg", Category = new List<string> { "popular", "vegetarian", "all" } },
        new Ramen { Id = "5", Name = "Tonkotsu Ramen", Sale = false, Price = 21.99m, Photo = "https://www.craftycookbook.com/wp-content/uploads/2023/04/tonkotsu.jpg", Category = new List<string> { "popular", "hot", "all" } },
        new Ramen { Id = "6", Name = "Egg Ramen", Sale = false, Price = 12.99m, Photo = "https://www.cooking-therapy.com/wp-content/uploads/2019/03/Soy-Braised-Eggs-4.jpg", Category = new List<string> { "popular", "vegetarian", "all" } },
        new Ramen { Id = "7", Name = "Shoyu Ramen", Sale = false, Price = 19.99m, Photo = "https://static01.nyt.com/images/2024/01/10/multimedia/ND-Shoyu-Ramen-qflv/ND-Shoyu-Ramen-qflv-mediumSquareAt3X.jpg", Category = new List<string> { "popular", "vegetarian", "all" } },
        new Ramen { Id = "8", Name = "Sesame Ramen", Sale = false, Price = 15.99m, Photo = "https://images.immediate.co.uk/production/volatile/sites/30/2021/05/Roast-broccoli-and-sesame-ramen-noodle-bowls-f57730e.jpg?quality=90&resize=556,505", Category = new List<string> { "vegetarian", "all" } },
        new Ramen { Id = "9", Name = "Shrimp Ramen", Sale = false, Price = 24.99m, Photo = "https://www.sizzlefish.com/cdn/shop/articles/20231004174603-shrimp-20ramen-20noodles-20main-20image.jpg?v=1696442815", Category = new List<string> { "popular", "hot", "all" } },
        new Ramen { Id = "10", Name = "Gok Ramen", Sale = false, Price = 20.99m, Photo = "https://keto-mojo.com/wp-content/uploads/2020/09/Ramen-with-Shirataki-Noodles.jpg", Category = new List<string> { "popular", "vegetarian", "all" } },
        new Ramen { Id = "11", Name = "Miso Ramen", Sale = false, Price = 16.99m, Photo = "https://www.kikkoman.eu/fileadmin/_processed_/b/e/csm_1101-recipe-page-Authentic-Japanese-soy-sauce-ramen_mobile_c83e83c70c.webp", Category = new List<string> { "popular", "hot", "vegetarian", "all" } },
        new Ramen { Id = "12", Name = "Gochujang Ramen", Sale = false, Price = 19.99m, Photo = "https://lindseyeatsla.com/wp-content/uploads/2021/03/Gochujang_Miso_Ramen_Noodles-4.jpg", Category = new List<string> { "popular", "hot", "all" } },
        new Ramen { Id = "13", Name = "Seafood Ramen", Sale = false, Price = 26.99m, Photo = "https://data.thefeedfeed.com/static/2020/06/11/15918884045ee24a140c006.jpg", Category = new List<string> { "popular", "all" } },
        new Ramen { Id = "14", Name = "Jeju Ramen", Sale = false, Price = 25.99m, Photo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTiYpgoFA95Zf0xMXXikqOJZzO-gcXyIO5upA&s", Category = new List<string> { "popular", "hot", "all" } },
        new Ramen { Id = "15", Name = "Pork Ramen", Sale = false, Price = 17.99m, Photo = "https://theflavoursofkitchen.com/wp-content/uploads/2019/08/Spicy-Pork-Ramen-2-2.jpg", Category = new List<string> { "popular", "hot", "all" } }
    };
        }



        public List<Ramen> GetAll()
        {
            return _ramens;
        }

        public Ramen? GetById(string id)
        {
            return _ramens.FirstOrDefault(r => r.Id == id);
        }

        public List<Ramen> GetByCategory(string category)
        {
            return _ramens.Where(r => r.Category.Contains(category, StringComparer.OrdinalIgnoreCase)).ToList();
        }

        public Ramen Add(Ramen ramen)
        {
            // Generate new ID
            var maxId = _ramens.Max(r => int.Parse(r.Id));
            ramen.Id = (maxId + 1).ToString();
            _ramens.Add(ramen);
            return ramen;
        }

        public bool Update(string id, Ramen ramen)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Name = ramen.Name;
            existing.Sale = ramen.Sale;
            existing.Price = ramen.Price;
            existing.Photo = ramen.Photo;
            existing.Category = ramen.Category;
            return true;
        }

        public bool Delete(string id)
        {
            var ramen = GetById(id);
            if (ramen == null) return false;
            _ramens.Remove(ramen);
            return true;
        }
    }
}