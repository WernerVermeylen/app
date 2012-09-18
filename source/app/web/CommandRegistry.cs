using System.Collections.Generic;

namespace app.web
{
  public class CommandRegistry : IFindCommands
  {
      private IEnumerable<IProcessOneRequest> commands;
      public CommandRegistry(IEnumerable<IProcessOneRequest> commands)
      {
          this.commands = commands;
      }

    public IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request)
    {
        foreach (var processOneRequest in commands)
        {
            if (processOneRequest.can_run(request)) 
                return processOneRequest;
        }

        return null;
    }
  }
}