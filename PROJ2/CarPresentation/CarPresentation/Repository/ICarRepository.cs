using CarPresentation.Models;

namespace CarPresentation.Repository
{
    public interface ICarRepository
    {
        CarForm FindCarDetails(string model,  string langCode);
    }
}