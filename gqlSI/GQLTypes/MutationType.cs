using gqlSI.Models;
using Microsoft.EntityFrameworkCore;

namespace gqlSI.GQLTypes
{
    public class MutationType
    {
        public async Task<Recipe> AddRecipeAsync([Service] AppDbContext context, Recipe recipe)
        {
            try
            {
                await context.Recipes.AddAsync(recipe);
                await context.SaveChangesAsync();
                return recipe;
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                Console.WriteLine($"Error adding recipe to the database: {ex.Message}");
                throw; // Re-throw the exception to propagate it further
            }
        }

        public async Task<Recipe?> UpdateRecipeAsync([Service] AppDbContext context,Recipe recipe)
        {
            //based on the id we will update the recipe
            
            context.Entry(recipe).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return recipe;
        }

        public async Task<Recipe?> DeleteRecipeAsync([Service] AppDbContext context, int id)
        {
            var recipe = await context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return null;
            }
            context.Recipes.Remove(recipe);
            await context.SaveChangesAsync();
            return recipe;
        }
    }
}
