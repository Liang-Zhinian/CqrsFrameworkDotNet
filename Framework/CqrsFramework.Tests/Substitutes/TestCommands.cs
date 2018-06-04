using System;
using System.Threading.Tasks;
using CqrsFramework.Commands;
using CqrsFramework.Domain.Exception;

namespace CqrsFramework.Tests.Substitutes
{
    public class TestAggregateDoSomething : ICommand
    {
        public Guid Id { get; set; }
        public int ExpectedVersion { get; set; }
        public bool LongRunning { get; set; }
    }

    public class TestAggregateDoSomethingHandler : ICommandHandler<TestAggregateDoSomething> 
    {
        public void Handle(TestAggregateDoSomething message)
        {
            if (message.LongRunning)
                Task.Delay(50);
            if(message.ExpectedVersion != TimesRun)
                throw new ConcurrencyException(message.Id);
            TimesRun++;
        }

        public int TimesRun { get; set; }
    }
	public class TestAggregateDoSomethingElseHandler : ICommandHandler<TestAggregateDoSomething>
    {
        public void Handle(TestAggregateDoSomething message)
        {
            //return Task.CompletedTask;
        }
    }
}