using System;

namespace DATest
{
    class Program
    {
        static void Main(string[] args)
        {
            DBAgent db = new DBAgent("Data Source=tcp:car-shopping-engine.database.windows.net,1433;Initial Catalog=car-shopping-engine;User Id=anpu6328@car-shopping-engine;Password=labasmuilasnamas1A?");
            db.Select();
            int newId = db.Insert("FAKE_BRAND", "FAKE_MODEL");
            db.Update(newId, "FAKE_BRAND_CHANGED", "FAKE_MODEL_CHANGED");
            db.Delete(newId);
        }
    }
}
