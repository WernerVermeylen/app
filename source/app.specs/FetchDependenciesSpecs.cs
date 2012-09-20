using Machine.Specifications;
using app.utility.container;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(IFetchDependencies))]
  public class FetchDependenciesSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_fetching_dependencies : concern
    {
      Establish c = () =>
      {
        GetDependencyInstance_Behaviour create_instance = () => new System.Text.StringBuilder();
      };
      Because b = () =>
        result = Dependencies.fetch.an<System.String>();

      It should_return_an_instance_of_the_given_type = () =>
        result.ShouldBeOfType<System.Text.StringBuilder>();

      static System.String result;
    }
  }
}
