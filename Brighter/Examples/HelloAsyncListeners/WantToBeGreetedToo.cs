﻿using System;
using System.Threading;
using System.Threading.Tasks;
using paramore.brighter.commandprocessor;

namespace HelloAsyncListeners
{
    public class WantToBeGreetedToo : RequestHandlerAsync<GreetingEvent>
    {
        public override async Task<GreetingEvent> HandleAsync(GreetingEvent @event, CancellationToken? ct = null)
        {
            var api = new IpFyApi(new Uri("https://api.ipify.org"));

            var result = await api.GetAsync(ct);

            // Simulated exceptions
            if (@event.Name.ToLower().Equals("devil"))
            {
                throw new ArgumentException("Devil's greeting will not be handled by Want-to-be-greeted-too.");
            }

            Console.WriteLine("Want-to-be-greeted-too received hello from {0}", @event.Name);
            Console.WriteLine(result.Success ? "Want-to-be-greeted-too has public IP addres is {0}" : "Call to IpFy API failed : {0}",
                result.Message);

            return await base.HandleAsync(@event, ct).ConfigureAwait(base.ContinueOnCapturedContext);
        }
    }
}
