﻿using System;
using System.Collections.Generic;
using System.Linq;
using app.web.core.stubs;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> all_commands;
    MissingCommandCreation_Behaviour missing_command_creation;

    public CommandRegistry(IEnumerable<IProcessOneRequest> all_commands,
                           MissingCommandCreation_Behaviour missingCommandhaBehaviour)
    {
      this.all_commands = all_commands;
      this.missing_command_creation = missingCommandhaBehaviour;
    }

    public CommandRegistry():this(new StubSetOfCommands(),() =>
    {
      throw new NotImplementedException("You don't have this command");
    })
    {
    }

    public IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request)
    {
      return all_commands.SingleOrDefault(process => process.can_run(request))
        ?? missing_command_creation();
    }
  }
}