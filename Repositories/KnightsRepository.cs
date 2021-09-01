using Dapper;
using System.Collections.Generic;
using System.Data;
using knightTale.Models;
using System.Linq;

namespace knightTale.Repositories
{
  public class KnightsRepository
  {

    private readonly IDbConnection _db;

    public KnightsRepository(IDbConnection db)
    {
      _db = db;
    }
    // NOTE  Lists are the most dynamic of the IEnumerables. But it does create a convienence if you want to use a sort, filter, or find. 
    internal List<Knight> Get()
    {
      string sql = "SELECT * FROM knights;";
      // NOTE Query is gonna hit the database and given the sql statement i'm going to try and turn it into a knight object, and push inside an IEnumerable. 
      return _db.Query<Knight>(sql).ToList();
    }
    // NOTE GET BY ID
    internal Knight Get(int id)
    {
      // NOTE Dapper is designed to take inputs and sanitize them. Dapper uses @ to signify that that object has a variable on it called ID. I want you to inject that variable safely right there. 
      string sql = "SELECT * FROM knights WHERE id = @id";
      // NOTE Query is gonna hit the database and given the sql statement i'm going to try and turn it into a knight object, and push inside an IEnumerable. Query First or Default returns a single object or null if not found. 
      return _db.QueryFirstOrDefault<Knight>(sql, new { id });
    }

    internal Knight Create(Knight newKnight)
    {
      // NOTE The last insert id gives the created object the last id available. 
      string sql = @"INSERT INTO knights (name, kingdom, age) VALUES (@Name, @Kingdom, @Age); SELECT LAST_INSERT_ID();";
      // NOTE Execute says you have to perform actions. Dont Do this. Doing this would create the knight, but it won't create the ID because that Id will be 0 when created, but the get will be different. So this isn't good. 
      // NOTE Fire off request and we are expecting this result back to be an integer. Because it is a second statement in the select last, I need to go get the information of what was created and assign it an id, then I can return that knight. So if there were other values we were finding we'd populate the id and then populate those things. 
      newKnight.Id = _db.ExecuteScalar<int>(sql, newKnight);
      return newKnight;
    }

    internal Knight Update(Knight updatedKnight)
    {
      string sql = @"UPDATE knights SET name=@Name, kingdom=@Kingdom, age=@Age WHERE id=@Id;";
      _db.Execute(sql, updatedKnight);
      return updatedKnight;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM knights WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}