using eProdaja.WinUI;

namespace KinoPlus.WinUI.Utils
{
    public static class ListControlHelper
    {
        public static async Task loadControlEntity<T>(ListControl control, string endpoint, string displayMember, bool selectDefault = false, object? queryObject = null)
        {
            List<T>? entities;
            var cacheEntities = Cache.GetList<T>();
            if (!cacheEntities.Any() || queryObject != null)
            {
                var service = new APIService(endpoint);
                entities = await service.Get<List<T>>(queryObject);
                if (entities != null && queryObject == null)
                {
                    cacheEntities.AddRange(entities);
                }
            }
            else
            {
                entities = cacheEntities;
            }
            control.ValueMember = "Id";
            control.DisplayMember = displayMember;
            control.DataSource = entities;
            if (!selectDefault)
                control.SelectedIndex = -1;
        }
    }
}