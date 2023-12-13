using gqlSI.Models;
using Microsoft.EntityFrameworkCore;

namespace gqlSI.GQLTypes
{
    public class QueryType
    {
        public async Task<List<Recipe>> AllRecipesAsync([Service] AppDbContext context)
        {
            return await context.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipe([Service] AppDbContext context, int id)
        {
            return await context.Recipes.FindAsync(id);
        }
    }
}
