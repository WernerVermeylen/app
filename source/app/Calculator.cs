﻿using System;
using System.Data;

namespace app
{
  public class Calculator
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection)
    {
      this.connection = connection;
    }

    public int add(int i, int i1)
    {
      if (i < 0 || i1 < 0) throw new ArgumentException("Not allowed to add a negative to a positive.");


      connection.Open();

      return i + i1;
    }
  }
}