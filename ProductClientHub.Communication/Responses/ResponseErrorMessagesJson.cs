namespace ProductClientHub.Communication.Responses
{
    public class ResponseErrorMessagesJson
    {
        private readonly object value;

        public  List<string> Errors { get; private set; } = new();

        public ResponseErrorMessagesJson(string message)
        {
            Errors = [message];
        }

        public ResponseErrorMessagesJson(List<string> messages)
        {
            Errors = messages;
        }

        public ResponseErrorMessagesJson(object value)
        {
            this.value = value;
            Errors = new(); // Garante que Errors nunca seja null
        }
    }
}
