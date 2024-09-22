namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
     
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesServices _gamesService;
        public GamesController( ICategoriesService categoriesService, IDevicesService devicesService, IGamesServices gamesService)
        {

            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }

        public IActionResult Index()
        {
            
                var games = _gamesService.GetAll();
                return View(games);
            

        }

        public IActionResult Details(int id)
        {   
          var game=_gamesService.GetById(id);

            if (game is null)
            {
                return NotFound();
            }
            return View(game); 
        
        }
            [HttpGet]
        public IActionResult create() 
        {

            creategameformviewmodel ViewModel = new()
            {

                categories = _categoriesService.GetSelectLists(),

                devices = _devicesService.GetSelectLists(),


            };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create(creategameformviewmodel model)
        {
            if (!ModelState.IsValid) 
            {
                model.categories = _categoriesService.GetSelectLists();
                model.devices = _devicesService.GetSelectLists();
                return View(model);
            }
            await _gamesService.create(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gamesService.GetById(id);

            if (game is null)
            {
                return NotFound();
            }
            EditGameFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                description = game.description,
                categoryid = game.categoryid,
                selecteddevices = game.devices.Select(d => d.devicesid).ToList(),
                categories = _categoriesService.GetSelectLists(),
                devices = _devicesService.GetSelectLists(),
                currentcover=game.cover

            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.categories = _categoriesService.GetSelectLists();
                model.devices = _devicesService.GetSelectLists();
                return View(model);
            }

         var game= await _gamesService.Edit(model);
            if (game is null)
                return BadRequest();


            return RedirectToAction(nameof(Index));
        }
       [HttpDelete]
        public IActionResult Delete(int id)
        {
            return BadRequest();

            var isDeleted=_gamesService.Delete(id);

            return isDeleted ? Ok(): BadRequest();
        }

    }
}
