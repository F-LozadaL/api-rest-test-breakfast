using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{

    //using a Dictionary as substitude for the DB implementation
    private static readonly Dictionary<Guid, Breakfast> _breakfasts= new();
    public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
    {
        //You would use a repository or entityframerecord to store in the DB
        // BUT instead we'll use a Dictionary
        _breakfasts.Add(breakfast.Id, breakfast);

        return Result.Created;

    }

    public ErrorOr<Deleted> DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id)
    {

        if(_breakfasts.TryGetValue(id, out var breakfast)){
            return breakfast;
        }

        return Errors.Breakfast.NotFound;
    }

    public ErrorOr<UpsertedBreakfast> UpsertBreakfast(Breakfast breakfast)
    {

        var IsNewlyCreated = !_breakfasts.ContainsKey(breakfast.Id);

        _breakfasts[breakfast.Id]= breakfast; 

        return new UpsertedBreakfast(IsNewlyCreated);
    }
}