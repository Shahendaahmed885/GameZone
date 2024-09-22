
namespace GameZone.Services
{
    public class GamesServices : IGamesServices
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagespath;
        public GamesServices(ApplicationDBContext dbContext, 
            IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
            _imagespath=$"{_webHostEnvironment.WebRootPath}{FileSettings.Imagespath}";
        }

        public IEnumerable<Game> GetAll()
          {
            return _dbContext.Games
                .Include(g=>g.category)
                .Include(g=>g.devices)
                .ThenInclude(d=>d.devices)
                .AsNoTracking()
                .ToList();
           
           }
        public Game ? GetById(int id)
        {
            return _dbContext.Games
               .Include(g => g.category)
               .Include(g => g.devices)
               .ThenInclude(d => d.devices)
               .AsNoTracking()
               .SingleOrDefault(g=>g.Id==id);
        }

        public async Task create(creategameformviewmodel model)
        {
            var covername = await savecover(model.cover);
            


            Game game = new()
            {
                Name=model.Name,
                description=model.description,
                categoryid=model.categoryid,
                cover=covername,
                devices= model.selecteddevices.Select(d=>new Gamedevices {devicesid=d}).ToList(),

            };

            _dbContext.Add(game);
            _dbContext.SaveChanges();
        }

        public async Task<Game?> Edit(EditGameFormViewModel model)
        {
            var game = _dbContext.Games
             .Include(g => g.devices)
             .SingleOrDefault(g => g.Id == model.Id);



            if (game == null)
                return null;
            var hasnewcover = model.cover is not null;
            var oldcover = game.cover;


            game.Name = model.Name;
            game.description = model.description;
            game.categoryid = model.categoryid;
            game.devices = model.selecteddevices.Select(d => new Gamedevices { devicesid = d }).ToList();
            if (hasnewcover)
            {
                game.cover=await savecover(model.cover!);
            }

           var effectedrows= _dbContext.SaveChanges();   
            

            if(effectedrows > 0)
            {
                if(hasnewcover) 
                {
                    var cover = Path.Combine(_imagespath, oldcover);
                    File.Delete(cover);
                }
                return game;
            }
            else
            {

                var cover = Path.Combine(_imagespath, game.cover);
                File.Delete(cover);

                return null;

            }
        }

        public bool Delete(int id)
        {
          var isDeleted=false;

            var game =_dbContext.Games.Find(id);
            if (game is null)
                return isDeleted;

            _dbContext.Games.Remove(game);
            var effectedrow = _dbContext.SaveChanges();
            if (effectedrow > 0)
            {
                isDeleted = true;
                var cover=Path.Combine(_imagespath, game.cover);
                File.Delete(cover);
            }

            return isDeleted;

        }


        private async  Task<string> savecover(IFormFile cover)
        {
            var covername = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), _imagespath, covername);
            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
            return covername;

        }

        
    }
}
