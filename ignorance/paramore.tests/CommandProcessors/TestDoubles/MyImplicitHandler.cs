using Paramore.Services.CommandHandlers;

namespace Paramore.Tests.CommandProcessors.TestDoubles
{
    internal class MyImplicitHandler : RequestHandler<MyCommand>
    {
        [MyLoggingHandler(step:1)]
        public override MyCommand Handle(MyCommand request)
        {
            return base.Handle(request);
        }
    }
}