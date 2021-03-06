﻿using Diadoc.Api.Proto;

namespace Diadoc.Console.Command
{
	public class ActOnCounteragentCommand : ConsoleCommandBase
	{
		public ActOnCounteragentCommand(ConsoleContext consoleContext, string command = "counteragent") : base(consoleContext, command, CommandType.AuthenticationRequired)
		{
			Usage = "-a|-b [ <organizationId> ]";
			Description = "Perform operation on CA";
		}

		protected override void PerformRunCommand(string[] args)
		{
			if (args.Length < 2)
				throw new UsageException();

			var action = args[0];
			var orgId = args[1];

			System.Console.WriteLine("Comment:");
			var comment = System.Console.ReadLine();

			switch (action)
			{
				case "-a":
			        ConsoleContext.DiadocApi.AcquireCounteragent(ConsoleContext.CurrentToken, ConsoleContext.CurrentOrgId,
			            new AcquireCounteragentRequest
			            {
			                OrgId = orgId,
			                MessageToCounteragent = comment
			            });
					return;
				case "-b":
					ConsoleContext.DiadocApi.BreakWithCounteragent(ConsoleContext.CurrentToken, ConsoleContext.CurrentOrgId, orgId, comment);
					return;
			}
		}
	}
}
