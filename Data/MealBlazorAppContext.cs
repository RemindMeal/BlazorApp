using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace MealBlazorApp.Data
{
    public sealed class MealBlazorAppContext : DbContext
    {
        public MealBlazorAppContext(DbContextOptions<MealBlazorAppContext> options) : base(options)
        {}
        
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeType> RecipeTypes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Presence> Participations { get; set; }
        public DbSet<Cooking> Cookings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)    
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>().HasKey(r => r.Id);
            modelBuilder.Entity<Recipe>().HasIndex(r => r.Name).IsUnique();

            // Meal <--> Recipe via Cooking
            modelBuilder.Entity<Cooking>().HasKey(x => new {x.MealId, x.RecipeId});
            modelBuilder.Entity<Cooking>()
                .HasOne(cooking => cooking.Meal)
                .WithMany(meal => meal.Cookings)
                .HasForeignKey(cooking => cooking.MealId);
            modelBuilder.Entity<Cooking>()
                .HasOne(cooking => cooking.Recipe)
                .WithMany(recipe => recipe.Cookings)
                .HasForeignKey(cooking => cooking.RecipeId);

            // Meal <--> Friend via Participation
            modelBuilder.Entity<Presence>().HasKey(p => new {p.MealId, p.FriendId});
            modelBuilder.Entity<Presence>()
                .HasOne(p => p.Friend)
                .WithMany(f => f.Presences)
                .HasForeignKey(p => p.FriendId);
            modelBuilder.Entity<Presence>()
                .HasOne(p => p.Meal)
                .WithMany(m => m.Presences)
                .HasForeignKey(p => p.MealId);

            // Recipe <--> RecipeType
            modelBuilder.Entity<Recipe>()
                .HasOne<RecipeType>(r => r.Type)
                .WithMany(t => t.Recipes)
                .IsRequired();

            // RecipeType
            modelBuilder.Entity<RecipeType>().HasKey(t => t.Id);
            modelBuilder.Entity<RecipeType>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<RecipeType>().Property(t => t.Name).IsRequired();
        }
    }
}