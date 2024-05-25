namespace Kumojin.Events.Api.Builder.Extensions;

public static class CorsPoliciesExtension
{
    public static void AddCorsPolicies(this IServiceCollection services)
    {
        services.AddCors(o => {
            o.AddPolicy("EventFrontedPolicy", policy => {
                policy.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });
    }
}
