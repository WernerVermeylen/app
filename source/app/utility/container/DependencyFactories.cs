using System;
using System.Collections.Generic;
using System.Linq;

namespace app.utility.container
{
  public class DependencyFactories : IFindFactoriesForDependencies
  {
    IEnumerable<ICreateOneDependency> possible_factories;
    MissingFactory_Behaviour missing_factory_behaviour;

    public DependencyFactories(IEnumerable<ICreateOneDependency> possible_factories, MissingFactory_Behaviour missing_factory_behaviour)
    {
      this.possible_factories = possible_factories;
      this.missing_factory_behaviour = missing_factory_behaviour;
    }

    public ICreateOneDependency get_factory_that_can_create(Type dependency)
    {
        try
        {
            return possible_factories.First(x => x.can_create(dependency));
        }
        catch
        {
            throw missing_factory_behaviour(dependency);
        }
    }

  }
}