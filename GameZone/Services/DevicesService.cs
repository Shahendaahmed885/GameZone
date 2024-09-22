namespace GameZone.Services
{
    public class DevicesService : IDevicesService
    {
        private readonly ApplicationDBContext _dbContext;

        public DevicesService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SelectListItem> GetSelectLists()
        {
            return _dbContext.devices
                 .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                 .OrderBy(d => d.Text)
                 .AsNoTracking()
                 .ToList();

        }
    }
}
