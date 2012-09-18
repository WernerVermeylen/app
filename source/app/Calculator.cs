using System;
using System.Data;

namespace app
{
  public class Calculator
  {
    private IDbConnection _connection;
    public Calculator(IDbConnection connection)
    {
        _connection = connection;
    }

    public int add(int i, int i1)
    {
        if(i < 0 || i1 < 0) throw new ArgumentException("Not allowed to add a negative to a positive.");

        if(_connection != null) _connection.Open();

        return i + i1;
    }
  }
}