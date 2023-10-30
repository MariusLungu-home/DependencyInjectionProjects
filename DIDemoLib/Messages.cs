namespace DIDemoLib
{
    public class Messages : IMessages
    {
        public string SayHello()
        {
            return "Hello from DIDemoLib";
        }

        public string SayGoodbye() 
        {
            return "Goodbye, farewell and good day from DIDemoLib";
        }
    }
}