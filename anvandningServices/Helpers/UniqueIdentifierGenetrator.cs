using System.Diagnostics;
using anvandningServices.Models;

namespace anvandningServices.Helpers;

public static class UniqueIdentifierGenerator
{
    public static string GenerateUniqueId()
    {
        try
        {
              return Guid.NewGuid().ToString();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}
