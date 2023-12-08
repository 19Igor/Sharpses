namespace MvcMovie.Controller;

public class HelloWorldController : Microsoft.AspNetCore.Mvc.Controller
{
    // https://localhost:1234/HelloWorld
    // GET: /HelloWorld/
    public string Index()
    {
        return "This is my default action...";
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}
