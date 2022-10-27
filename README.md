# MiniService
Simple Magic Onion Grpc WebPack Service with Blazor Webassembly client. And a shared contracts projects for Service Interfaces and Dto's

To add services with Dto's just add Dto's in MiniService.Contract project:

```C#
public class Person
{
    [Key(0)]
    public string FirstName { get; set; }
    [Key(1)]
    public string LastName { get; set; }
}
