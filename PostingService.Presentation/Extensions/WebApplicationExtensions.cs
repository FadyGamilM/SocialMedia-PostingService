using PostingService.Presentation.Abstractions;

namespace PostingService.Presentation.Extensions;

public static class WebApplicationExtensions
{
    public static void RegisterWebApplicationServices(this WebApplication app)
    {
        // scan the Presentation assembly 
        var endpointsDefinitions = typeof(Program).Assembly
            .GetTypes()
            // for all types / modules that implement the IEndpointsDefinitions interface
            // and not abstract class 
            // and also not interface
            // because we need to create instance of each one of these modules
            .Where(
                t => t.IsAssignableTo(typeof(IEndpointsDefinitions))
                &&
                !t.IsAbstract
                &&
                !t.IsInterface
             )
            // projection to select them and create an instance of each of them
            .Select(Activator.CreateInstance)
            // cast all these objects (created instances) to the interface
            .Cast<IEndpointsDefinitions>();

        // now we have an IEnumerable of objects that implement the IEndpointsDefinitions interface
        // so lets loop through each object instance and register its endpoints to the app instance
        foreach(var ResourceEndpointsDef in endpointsDefinitions)
        {
            ResourceEndpointsDef.RegisterEndpoints(app);
        }

    }
}
