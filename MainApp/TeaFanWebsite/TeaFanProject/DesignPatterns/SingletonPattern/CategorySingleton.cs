using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Data;
using TeaFanProject.Entities;

namespace TeaFanProject.DesignPatterns.SingletonPattern
{
    public sealed class CategorySingleton
    {
        static volatile CategorySingleton Instance;
        static List<Category> categories { get; set;} = new List<Category>();
        private CategorySingleton() { }
        public static void Init(ApplicationDbContext context)
        {
            categories = context.Categories.ToList();
        }
        public static CategorySingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CategorySingleton();
            }
            return Instance;
        }
        public List<Category> GetCategory() => categories;
    }
}
