using System;
using System.Collections.Generic;
using knightTale.Models;
using knightTale.Repositories;

namespace knightTale.Services
{
  public class KnightsService
  {
    private readonly KnightsRepository _repo;

    public KnightsService(KnightsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Knight> Get()
    {
      return _repo.Get();
    }

    internal Knight Get(int id)

    {
      Knight knight = _repo.Get(id);
      if (knight == null)
      {
        throw new Exception("Invalid Id");
      }
      return knight;
    }

    internal Knight Create(Knight newKnight)
    {
      Knight knight = _repo.Create(newKnight);
      if (knight == null)
      {
        throw new Exception("invalid Id");
      }
      return knight;
    }

    internal Knight Edit(Knight updatedKnight)
    {
      // NOTE Find the original before edits
      Knight original = Get(updatedKnight.Id);
      // NOTE Checks each value on the incomming object, and if it exists, allow it to continue, if it does not, set it to the original value. This makes sure that if a value is not passed, it doesn't change that value. 
      updatedKnight.Name = updatedKnight.Name != null ? updatedKnight.Name : original.Name;
      updatedKnight.Kingdom = updatedKnight.Kingdom != null ? updatedKnight.Kingdom : original.Kingdom;
      updatedKnight.Age = updatedKnight.Age != 0 ? updatedKnight.Age : original.Age;
      return _repo.Update(updatedKnight);
    }

    internal void Delete(int id)
    {
      Knight original = Get(id);
      _repo.Delete(id);
    }
  }
}