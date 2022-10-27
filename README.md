# MiniService
Simple Magic Onion Grpc WebPack Service with Blazor Webassembly client.

To add services with Dto's just add Dto:

public class Person
{
    [Key(0)]
    public string FirstName { get; set; }
    [Key(1)]
    public string LastName { get; set; }
}
