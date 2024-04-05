using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class CategoryFactory
{
	public static Category Create(CategoryEntity category)
	{
		try
		{
			return new Category
			{
				Id = category.Id,
				CategoryName = category.CategoryName
			};
		}
		catch (Exception) { }
		return null!;
	}

    public static IEnumerable<Category> Create(List<CategoryEntity> entities)
    {

        List<Category> categories = new List<Category>();
        try
        {
            foreach (var entity in entities)
			{
				categories.Add(Create(entity));
			}
        }
        catch (Exception) { }
        return categories;
    }
}
