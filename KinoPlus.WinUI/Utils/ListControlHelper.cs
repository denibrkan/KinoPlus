using eProdaja.WinUI;

namespace KinoPlus.WinUI.Utils
{
    public static class ListControlHelper
    {
        public static async Task loadControlEntity<T>(ListControl control, string endpoint, string displayMember)
        {
            List<T>? entities;
            var cacheEntities = Cache.GetList<T>();
            if (!cacheEntities.Any())
            {
                var service = new APIService(endpoint);
                entities = await service.Get<List<T>>();
                if (entities != null)
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
            control.SelectedIndex = -1;
        }
    }
}
