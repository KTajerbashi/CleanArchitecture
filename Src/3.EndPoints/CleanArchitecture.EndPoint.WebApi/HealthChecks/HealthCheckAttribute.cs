namespace CleanArchitecture.EndPoint.WebApi.HealthChecks;

//[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
//public class HealthCheckAttribute : Attribute
//{
//    public string Name { get; }
//    public string[] Tags { get; }
//    public int TimeoutInSeconds { get; set; } = 5;

//    public HealthCheckAttribute(string name, params string[] tags)
//    {
//        Name = name ?? throw new ArgumentNullException(nameof(name));
//        Tags = tags ?? Array.Empty<string>();
//    }
//}