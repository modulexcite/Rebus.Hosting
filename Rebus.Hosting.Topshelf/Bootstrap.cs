using Topshelf;

namespace Rebus.Hosting.Topshelf
{
    public class Bootstrap
    {
        public static void Run()
        {
            HostFactory.Run(c =>
            {
                c.Service<RebusEndpoint>(s =>
                {
                    s.ConstructUsing(() => new RebusEndpoint());
                    s.WhenStarted((endpoint, control) => endpoint.Start(control));
                    s.WhenStopped((endpoint, control) => endpoint.Start(control));
                });
            });
        }
    }

    public class RebusEndpoint : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return false;
        }
    }
}
