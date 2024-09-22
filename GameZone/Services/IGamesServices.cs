namespace GameZone.Services
{
    public interface IGamesServices
    {
        IEnumerable<Game> GetAll();
        Game ? GetById(int id);   
        Task create(creategameformviewmodel model);
        Task<Game?> Edit(EditGameFormViewModel model);
        bool Delete(int id);
    }
}
